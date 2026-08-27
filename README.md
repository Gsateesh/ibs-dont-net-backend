# IBS Backend Service

ASP.NET Core Web API for IBS, built to
[IBS-Backend-Service-Specification.docx](docs/IBS-Backend-Service-Specification.docx).
This pass covers **Module 1 - user management**: the data model, the access-control rules,
the account lifecycle, and the full API surface from section 7 of the spec.

- **.NET 10**, C#, EF Core 10 code-first with migrations
- **Modular monolith**: one deployable, six module folders, boundaries enforced by project
  references rather than by convention
- **SQL Server** (Azure SQL), **Blob Storage** for files, **Azure Communication Services**
  for email, **Key Vault** for secrets, **Application Insights** for telemetry
- **Cookie session auth** - the Angular app is served from the same origin, so no token
  ever sits in browser storage

## Running it locally

Nothing in Azure is required. With no email or storage connection string configured, the
app falls back to a logging email sender (invite links appear in the console) and local
disk storage.

```bash
dotnet tool restore
dotnet dotnet-ef database update --project src/IBS.Infrastructure --startup-project src/IBS.Api
dotnet run --project src/IBS.Api
```

Then open **https://localhost:7080/swagger**.

Connection strings and other local settings live in **`appsettings.Local.json`** at the
repository root - git-ignored, and read by all three entry points: the API, `dotnet ef`, and
the seed tool. It overrides `appsettings.Development.json`, which ships pointing at LocalDB
so a fresh clone runs with no setup.

```json
{
  "ConnectionStrings": {
    "IbsDatabase": "Server=tcp:your-server.database.windows.net,1433;Initial Catalog=your-db;User ID=...;Password=...;Encrypt=True;"
  }
}
```

The app logs which database it opened at startup, so a connection string that quietly fell
back to LocalDB is obvious rather than mysterious. On Dev/Test migrations are applied on
startup; in every other environment they are an explicit deploy step, never applied silently
against live data.

## Targeting a different environment (Dev, Prod, ...)

Every environment - your machine, Dev, Prod - is just a connection string. Migrations and the
seed tool both read `ConnectionStrings:IbsDatabase` the normal way, so pointing either at a
different database is a one-off environment variable, never a code change:

```bash
ConnectionStrings__IbsDatabase="Server=tcp:<server>.database.windows.net,1433;Initial Catalog=<database>;Persist Security Info=False;User ID=<user>;Password=<password>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" \
  dotnet dotnet-ef database update --project src/IBS.Infrastructure --startup-project src/IBS.Api
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

## Project layout

```
src/
  IBS.Api/                   Web API host: controllers, Swagger, auth, wwwroot (Angular build)
  IBS.Modules.UsersAccess/   This spec: Domain / Application / Infrastructure
  IBS.Modules.Sales/         Placeholder - registration hook only
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

- every non-anonymous operation is documented with the session-cookie requirement plus its
  401 and 403 responses;
- the permission an endpoint requires is read off the `[RequiresPermission]` attribute the
  controller already carries, so the documentation cannot drift away from the rule.

Sign in through `POST /api/auth/login` in the UI first; the session cookie is then sent
automatically with everything else on the page.

## Notes for deployment

- **Secrets**: set `KeyVault:Uri` and give the App Service a managed identity. Connection
  strings, the ACS connection string and the storage key are then read from Key Vault and
  never appear in `appsettings.json`.
- **Always Encrypted**: `EmployeeStatutory.Pan`, `.Aadhaar` and `.BankDetails` are the
  columns intended for SQL Server Always Encrypted. Provision the column master and column
  encryption keys per environment and enable `Column Encryption Setting=Enabled` on the
  connection string; the model maps them as ordinary strings so no code change is needed.
- **Migrations on Prod**: run `dotnet ef database update` as a deploy step, or generate a
  script with `dotnet ef migrations script`. Startup migration is Development-only.
- **Frontend**: deployed separately to its own Azure Static Web App, not bundled into this
  API's `wwwroot` - Dev and Prod are both split-hosted (Static Web App + a separate App
  Service for the API, no shared origin). The frontend repo's `environment.*-split.ts` files
  carry the API's URL for each environment.

### Building the package for FTP / zip deploy

This API is deployed on its own - the Angular app is a separate deploy to its Static Web
App, not part of this package:

```bash
dotnet publish src/IBS.Api -c Release -o ./publish
```

Upload the **contents** of `./publish` (not the folder itself) to `/site/wwwroot` on the
target App Service - via FTPS (Deployment Center > FTPS credentials for the endpoint and
login), or zip the folder and push it through Kudu's `/api/zipdeploy`. Restart the App
Service afterwards so it picks up the new files.

## Not in this pass

Attendance and leave, the client portal (its own account type), and the Sales, Design,
Delivery, Procurement and Finance modules - folders reserved, nothing built. Multi-tenancy
is deliberately absent: this is one company with several branches.
