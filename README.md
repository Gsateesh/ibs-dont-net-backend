# IBS Backend Service

ASP.NET Core Web API for IBS, built to
[IBS-Backend-Service-Specification.docx](docs/IBS-Backend-Service-Specification.docx).
This pass covers **Module 1 - user management**: the data model, the access-control rules,
the account lifecycle, and the full API surface from section 7 of the spec.

- **.NET 10**, C#, EF Core 10 code-first with migrations
- **Modular monolith**: one deployable, six module folders, boundaries enforced by project
  references rather than by convention
- **SQL Server** (Azure SQL), **Blob Storage** for files, **Azure Communication Services**
  for email, **Application Insights** for telemetry
- **JWT bearer auth**: the Angular app is hosted separately on its own Azure Static Web App,
  so a cookie could never cover both origins. A token sent in an `Authorization` header
  authenticates the same way on every environment

> **This README is the API only.** The Angular app lives in the sibling
> `frontend-angular-app` folder and has its own README covering its setup, build and release.
> Nothing here builds, bundles or deploys the frontend.

## Running it locally

**Two values have no default, and the API aborts at startup without either of them:**

| Value | Why it fails fast |
| --- | --- |
| `Jwt:SigningKey` | Validated by `[Required, MinLength(32)]` on `JwtOptions`, so a blank or weak key cannot silently sign forgeable tokens. |
| `Storage:ConnectionString` | **There is no local-disk fallback.** `AddIbsInfrastructure` throws when it is missing. The old fallback wrote to a folder that App Service wipes on every deploy, so a misconfigured environment looked healthy right up until the files vanished - see the comment in [`InfrastructureRegistration.cs`](src/IBS.Infrastructure/InfrastructureRegistration.cs). |

Both go in **`appsettings.Local.json`** at the root of this folder - git-ignored, and read by
all three entry points: the API, `dotnet ef`, and the seed tool.

```json
{
  "Jwt": {
    "SigningKey": "<any random string of 32 characters or more>"
  },
  "Storage": {
    "ConnectionString": "UseDevelopmentStorage=true"
  }
}
```

`UseDevelopmentStorage=true` points at [Azurite](https://learn.microsoft.com/azure/storage/common/storage-use-azurite),
the local storage emulator - run it and uploads work offline. Any non-empty string satisfies
the startup check, so a real storage account connection string works here too.

**Email, by contrast, genuinely is optional.** With `Email:ConnectionString` blank the API
registers `LoggingEmailSender` and invite links appear in the console instead of being sent.

Then:

```bash
dotnet tool restore
dotnet run --project src/IBS.Api
```

Open **https://localhost:7080/swagger**.

On `Development` the API applies pending migrations on startup, so there is no separate
database step for a fresh clone. To apply them by hand instead:

```bash
dotnet dotnet-ef database update --project src/IBS.Infrastructure --startup-project src/IBS.Api
```

`appsettings.Local.json` overrides `appsettings.Development.json`, which ships pointing at
LocalDB and supplies the dev `Jwt:Issuer` / `Jwt:Audience`, so a connection string is only
needed when you want a database other than LocalDB:

```json
{
  "ConnectionStrings": {
    "IbsDatabase": "Server=tcp:your-server.database.windows.net,1433;Initial Catalog=your-db;User ID=...;Password=...;Encrypt=True;"
  }
}
```

The API logs which database it opened at startup, so a connection string that quietly fell
back to LocalDB is obvious rather than mysterious.

### The one setting the local frontend depends on

`ng serve` proxies `/api` to `https://localhost:7080`, so the frontend needs nothing from you
here beyond the API being up. One setting does matter, though: **`UsersAccess:AppBaseUrl` is
the frontend's origin, not this API's.** Invite and password-reset links are built as
`{AppBaseUrl}{ActivationPath}?token=...`, and `/activate` is an Angular route - this API's
`wwwroot` is empty and serves no UI. For local work that means:

```json
{
  "UsersAccess": {
    "AppBaseUrl": "http://localhost:4200"
  }
}
```

Leave it at the shipped `https://localhost:7080` and the links generate fine but land on
nothing.

## Configuration reference

Every setting below is read from `appsettings.json` then `appsettings.{Environment}.json`
then `appsettings.Local.json` then environment variables, last one winning. In Azure they are
App Service Application Settings, where a nested key is written with a **double underscore**:
`ConnectionStrings__IbsDatabase`, `Jwt__SigningKey`.

| Setting | What it is |
| --- | --- |
| `ConnectionStrings:IbsDatabase` | Azure SQL / LocalDB connection string. Required. |
| `Jwt:SigningKey` | HMAC-SHA256 secret, 32+ characters. **Required - the API refuses to start without it.** Different per environment, so a key leaked from Dev cannot forge Prod tokens. |
| `Jwt:Issuer`, `Jwt:Audience` | Written into and validated on every token. Required. |
| `Jwt:AccessTokenLifetime` | Default `00:30:00`. There is no refresh token, so this is the full re-authentication interval, not a rolling window. |
| `Cors:AllowedOrigins` | Array of frontend origins allowed to call this API. **Split hosting needs the Static Web App's origin in here**, or every browser call fails preflight. Empty is correct only for same-origin. |
| `UsersAccess:AppBaseUrl` | The **frontend** origin that invite and reset links point at. See above. |
| `Storage:ConnectionString` | Blob Storage for employee photos and documents. **Required in every environment - startup aborts without it, there is no local-disk fallback.** `UseDevelopmentStorage=true` for Azurite locally. |
| `Email:ConnectionString` | Azure Communication Services. Optional - blank falls back to logging invite links to the console. |
| `ApplicationInsights:ConnectionString` | Telemetry. Registered only when set, so a dev machine skips it. |
| `KeyVault:Uri` | Optional. When set, Key Vault is added as a configuration source and supplies the secrets above. The current Azure setup uses App Service Application Settings instead - see [docs/DEPLOYMENT.md](docs/DEPLOYMENT.md). |

## Targeting a different environment (Dev, Prod, ...)

Every environment - your machine, Dev, Prod - is just a connection string. Migrations and the
seed tool both read `ConnectionStrings:IbsDatabase` the normal way, so pointing either at a
different database is a one-off environment variable, never a code change:

```bash
ConnectionStrings__IbsDatabase="Server=tcp:<server>.database.windows.net,1433;Initial Catalog=<database>;Persist Security Info=False;User ID=<user>;Password=<password>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" dotnet dotnet-ef database update --project src/IBS.Infrastructure --startup-project src/IBS.Api
```

The same pattern seeds the Super Admin on that environment - see
[Creating the first account](#creating-the-first-account) below.

**This is deliberately a manual, one-off command, not something that runs automatically.**
Applying migrations to Prod is meant to be an explicit action taken by a person who means to
take it - never bundled into a routine deploy, and never triggered by `dotnet run` the way
Dev/Test's startup auto-migration is. Each environment also gets its own SQL Server with its
own credentials, not a shared login across Dev and Prod - see
[docs/DEPLOYMENT.md](docs/DEPLOYMENT.md) for the full Azure setup.

## Creating the first account

There is no registration endpoint and no default password anywhere in the codebase. The
single Super Admin is created by a console tool, which is the only place allowed to write a
password hash directly:

```bash
dotnet run --project tools/IBS.SeedSuperAdmin
```

It prompts for an email, a name and a password, and writes one row with `IsSuperAdmin = 1`.
Pass `--print-hash-only` to print a hash for a manual `INSERT` instead, when the target
database is not reachable from your machine.

Every other account is created through `POST /api/employees`, which stores **no** password
at all: the person sets their own through the emailed invite link, and nobody else ever
knows it.

## How access works

There are no roles. What someone can do is decided entirely by their `EmployeePermission`
rows, with one bypass - the `IsSuperAdmin` flag, checked first and short-circuiting every
check. Designation is descriptive and grants nothing.

Two rules are worth knowing before reading the code:

1. **The Super Admin account is protected.** `manage_users` reaches every account except
   that one; only the Super Admin may mutate their own. Enforced by `CanManageAccount` on
   every mutating endpoint.
2. **High-impact permissions cannot be self-granted.** Granting `manage_permissions` or
   `view_sensitive_data` requires the actor to already hold `manage_permissions`. Without
   this, any `manage_users` holder could grant themselves the permission those two were
   split apart to protect.

Both live in the service layer, never only in the UI, and both are covered by
`PermissionChecker` and `PermissionService`.

A token stays cryptographically valid until it expires, so `JwtBearerEvents.OnTokenValidated`
re-checks the account's live status on every request. A suspended account therefore loses
access on its next call, not at its next sign-in.

## Project layout

```
src/
  IBS.Api/                   Web API host: controllers, Swagger, auth, middleware
  IBS.Modules.UsersAccess/   This spec: Domain / Application / Infrastructure
  IBS.Modules.Sales/         Leads
  IBS.Modules.Design/        Placeholder
  IBS.Modules.Delivery/      Placeholder
  IBS.Modules.Procurement/   Placeholder
  IBS.Modules.Finance/       Placeholder
  IBS.SharedKernel/          Permission codes, audit contract, base types, clock
  IBS.Infrastructure/        DbContext, migrations, Key Vault / Storage / Email wrappers
tools/
  IBS.SeedSuperAdmin/        One-off bootstrap console app
```

Modules never reference each other. Each one talks to its own slice of the database through
an interface (`IUsersAccessDbContext`) that `IBS.Infrastructure` implements, so the boundary
is real from day one and a module could be extracted later without unpicking it.

## API documentation

Swagger UI is at `/swagger`, generated from the XML doc comments on the controllers and
DTOs. Two custom filters keep it honest:

- every non-anonymous operation is documented with its bearer-token requirement plus its
  401 and 403 responses;
- the permission an endpoint requires is read off the `[RequiresPermission]` attribute the
  controller already carries, so the documentation cannot drift away from the rule.

Call `POST /api/auth/login` first, then paste the token it returns into Swagger's
**Authorize** box to exercise everything else.

## Deployment

The full Azure setup - SQL Server, App Service, Application Settings - is in
[docs/DEPLOYMENT.md](docs/DEPLOYMENT.md). Beyond that:

- **Secrets**: the connection string, the JWT signing key, the ACS connection string and the
  storage key are App Service Application Settings and never appear in `appsettings.json`.
  Setting `KeyVault:Uri` switches them to Key Vault instead, with no code change.
- **Always Encrypted**: `EmployeeStatutory.Pan`, `.Aadhaar` and `.BankDetails` are the
  columns intended for SQL Server Always Encrypted. Provision the column master and column
  encryption keys per environment and enable `Column Encryption Setting=Enabled` on the
  connection string; the model maps them as ordinary strings so no code change is needed.
- **Migrations on Prod**: run `dotnet ef database update` as a deploy step, or generate a
  script with `dotnet ef migrations script`. Startup migration is Development-only.
- **Ordering**: when shipping both halves, release this API **first**. The frontend is built
  against the API's contract, so API-first avoids the breaking direction - a new frontend
  calling an endpoint the old API does not have yet.

### Releasing to the App Service

There is no pipeline: you build the folder here, then upload it by hand with an FTP client.

**1. Publish**

```bash
dotnet publish backend-service-dot-net-app/src/IBS.Api -c Release -o backend-service-dot-net-app/publish
```

Run this from the repository root. Warnings about XML comments in `LeadDtos.cs` are
pre-existing and expected. Build errors mean stop - do not upload a partial folder.

**2. Upload**

The files to release are here:

```
C:\Users\Gsate\Desktop\personal\IBS\backend-service-dot-net-app\publish
```

Use **WinSCP** or **FileZilla** to upload the **contents** of that folder - not the folder
itself, or you will end up with `/site/wwwroot/publish` and the app will not start - to:

```
/site/wwwroot
```

FTPS credentials come from the App Service: **Deployment Center -> FTPS credentials**, which
gives you the endpoint, username and password.

Restart the App Service afterwards so it picks up the new files.

**3. Verify**

```bash
curl -s -o /dev/null -w "%{http_code}\n" "https://ibs-backend-service-dev-g8fkexgwc7hdefg6.centralindia-01.azurewebsites.net/swagger/v1/swagger.json"
```

Run this only *after* the upload completes - before that it returns 200 from the old build and
tells you nothing. The host above is dev; each environment's API URL is recorded in the
frontend's `src/environments/environment.*-split.ts`.

### If the upload appears to do nothing

**`WEBSITE_RUN_FROM_PACKAGE=1` and FTP upload are incompatible.** While that app setting is
`1`, the App Service mounts a read-only filesystem from a package and ignores whatever is in
`/site/wwwroot`. Your files transfer, the FTP client reports success, and the old build keeps
serving - with no error anywhere to explain it.

Earlier versions of `docs/DEPLOYMENT.md` told you to set this to `1`, so an App Service
provisioned before that was corrected may still have it on. Check it in the App Service under
**Environment variables**: set `WEBSITE_RUN_FROM_PACKAGE` to `0` or delete it, then restart.

### Republishing

`dotnet publish` overwrites in place rather than clearing the folder first, so files dropped
from the project linger in `publish/`. Fine for a routine release. If you have renamed or
removed assemblies, delete the `publish` folder and republish before uploading.

## Not in this pass

Attendance and leave, the client portal (its own account type), quotations as a record of
their own, and the Design, Delivery, Procurement and Finance modules - folders reserved,
nothing built. Multi-tenancy is deliberately absent: this is one company with several
branches.
