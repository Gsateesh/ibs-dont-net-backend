# Deploying IBS to Azure - Portal walkthrough, no Key Vault

This supersedes the earlier CLI/Key-Vault draft of this file. What changed:

- **No Key Vault.** Connection strings go straight into the App Service's Application Settings, the same way you already override them locally with `ConnectionStrings__IbsDatabase=...`. Zero code changes - `Program.cs` already reads environment variables last, so whatever you set in the Portal wins.
- **You create every resource by hand** in the Azure Portal. Nothing in this document runs a command against your subscription unless you choose to and ask for it.
- **Covers both Dev and Prod.** The two environments are the same recipe with different SKUs - each Portal section below has a callout for what to pick differently on Prod.
- **Separate SQL Servers per environment, deliberately.** Not one server with two databases - each environment gets its own server, its own admin login, its own resource group. Costs nothing extra (Azure SQL bills per database, not per server); the reason is blast radius - a leaked Dev credential should never be able to touch Prod.

## How the config mapping works (read this once)

Two settings your app needs are nested, e.g. `ConnectionStrings:IbsDatabase`. .NET's environment-variable configuration provider maps a double underscore to that colon, so in the Portal you enter the key as:

```
ConnectionStrings__IbsDatabase
```

with two underscores, and the value is the exact same connection string you already use in `appsettings.Local.json`. Same idea for `UsersAccess__AppBaseUrl`. A flat setting like `ASPNETCORE_ENVIRONMENT` needs no special handling - enter it exactly as named.

Every value below is entered the same way: **App Service > Configuration > Application settings > + New application setting**, one name and one value per row, then **Save** at the top once you're done adding them.

---

## Part A - Create the Azure SQL Server and Database

1. Portal search bar -> **SQL databases** -> **+ Create**.
2. **Basics** tab:
   - **Resource group**: **Create new**, name it `rg-ibs-dev` (or `rg-ibs-prod` for the Prod pass later).
   - **Database name**: `ibs-dev` (or `ibs-prod`).
   - **Server**: **Create new**.
     - Server name: something globally unique, e.g. `sql-ibs-<yourname>-dev`.
     - Location: **Central India**, matching your spec.
     - Authentication method: **Use SQL authentication**.
     - Server admin login / password: pick and **write these down** - you need them for the connection string in Part C.
   - **Want to use SQL elastic pool?**: No.
   - **Compute + storage**:
     - Dev: click **Configure database**, choose **Serverless**, General Purpose, and lower the vCores to the smallest offered (1). This is the free-tier-eligible tier your spec calls for on Dev/Test.
     - Prod: choose **Provisioned**, General Purpose, **Standard-series (Gen5)**, and pick a size around **S1 (DTU-based)** if you switch the pricing model to DTU - or the closest vCore equivalent. Prod also wants **Zone redundancy** off (Central India may not support it) and automated backups, which Azure SQL gives you by default.
3. **Networking** tab:
   - Connectivity method: **Public endpoint**.
   - **Allow Azure services and resources to access this server**: **Yes**. This is what lets your App Service reach the database without you managing individual IP rules.
4. **Security** tab: leave Microsoft Defender for SQL off for now (it costs extra); nothing else to change.
5. **Review + create** -> **Create**. Takes a few minutes.

When it's done, open the **SQL server** resource (not the database) and copy its **Server name**, something like `sql-ibs-yourname-dev.database.windows.net`. You'll need it in Part C.

## Part B - Create the App Service

1. Portal search bar -> **App Services** -> **+ Create** -> **Web App**.
2. **Basics** tab:
   - **Resource group**: the same `rg-ibs-dev` from Part A.
   - **Name**: globally unique, e.g. `ibs-api-dev` - this becomes `https://ibs-api-dev.azurewebsites.net`.
   - **Publish**: **Code**.
   - **Runtime stack**: **.NET 10 (STS)** - if 10 isn't listed yet in your region, pick **.NET 8 (LTS)** and say so; the app targets net10.0 today and would need a one-line retarget to run on 8.
   - **Operating System**: **Linux**.
   - **Region**: **Central India**.
   - **Linux Plan**: **Create new**.
     - Dev: **Basic B1**.
     - Prod: **Standard S1** (this tier is what unlocks autoscale and deployment slots, both called for in your spec).
3. **Deployment** tab: leave **Continuous deployment** off - you're deploying by hand.
4. **Networking** tab: defaults are fine.
5. **Monitoring** tab: **Enable Application Insights** -> **Yes**, create a new one in the same resource group. This gives you the logging your spec asks for, with no extra setup.
6. **Review + create** -> **Create**.

---

## Part C - Configure the App Service

Open the new App Service -> left sidebar -> **Settings** -> **Configuration** -> **Application settings** tab -> **+ New application setting**, once per row below.

| Name | Value |
|---|---|
| `ConnectionStrings__IbsDatabase` | `Server=tcp:<your-sql-server>.database.windows.net,1433;Initial Catalog=ibs-dev;Persist Security Info=False;User ID=<admin-login>;Password=<admin-password>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;` |
| `ASPNETCORE_ENVIRONMENT` | `Development` for the Dev app, `Production` for the Prod app - see the callout below, this genuinely changes behaviour. |
| `Jwt__SigningKey` | A random secret of **32 characters or more**. **The API will not start without this** - it is validated at startup. Generate a different one per environment; a key leaked from Dev must not be able to forge Prod tokens. |
| `Jwt__Issuer` | e.g. `ibs-dev` (or `ibs-prod`). Must be set - it is validated on every token. |
| `Jwt__Audience` | Same value as the issuer is fine, e.g. `ibs-dev`. Must be set. |
| `Cors__AllowedOrigins__0` | The **Static Web App's** origin, e.g. `https://<swa-name>.azurestaticapps.net`. The frontend is hosted separately, so without this every browser call to the API fails its CORS preflight. Add `__1`, `__2` rows for further origins. |
| `UsersAccess__AppBaseUrl` | The **frontend's** origin - the Static Web App, *not* this App Service. Invite and reset links are built as `{AppBaseUrl}/activate?token=...`, and `/activate` is an Angular route; this API's `wwwroot` is empty and serves no UI. Point it here and the links land on nothing. |
| `Storage__ConnectionString` | The storage account's connection string. **Required - the API crash-loops on startup without it.** Create the account in Part D first; this row is here so the required settings are all in one list. |
| `WEBSITE_RUN_FROM_PACKAGE` | `0`, or leave it unset entirely - **do not set this to `1`**. See the callout below. |

Click **Save** at the top, then **Continue** through the restart prompt.

**Why `ASPNETCORE_ENVIRONMENT` matters here, specifically:** your spec (section 2) wants EF Core migrations to apply automatically on startup in Dev/Test, and `Program.cs` already does exactly that when the environment is `Development` - so the *first* deploy will create the schema on its own, no extra step. On Prod, migrations are meant to be an explicit, deliberate action, never automatic against live data - so if you set `ASPNETCORE_ENVIRONMENT=Production`, you must run `dotnet ef database update` yourself, pointed at the Prod connection string, before that App Service will have a usable schema. I can run that one command for you when you're ready for the Prod pass, or hand you the exact line to run yourself.

**Why `WEBSITE_RUN_FROM_PACKAGE` must stay off:** the release route for this API is an FTP upload of the published files to `/site/wwwroot` - see "Releasing to the App Service" in the README. While this setting is `1`, App Service mounts a read-only filesystem from a deployed package and ignores `/site/wwwroot` completely. Uploaded files transfer, the FTP client reports success, and the old build keeps serving, with nothing anywhere reporting an error. Set it to `1` only if you deliberately switch to zip deploy, and be aware that FTP uploads stop taking effect the moment you do.

## Part D - Storage Account (REQUIRED - do this before you deploy)

> **This is not optional, and an earlier version of this document wrongly said it was.** The API calls `AddIbsInfrastructure` at startup, which **throws and kills the process** when `Storage__ConnectionString` is missing. There is no local-disk fallback: it was removed deliberately, because it wrote to a folder App Service wipes on every deploy, so uploads looked fine until the files silently vanished.
>
> Skipping this part does not cost you photo uploads. It costs you the whole API - it will crash-loop on startup, and on an F1 plan the restart churn will burn through the daily CPU quota and leave the app stuck in **Quota exceeded**, where the Start button does nothing.

1. Portal search bar -> **Storage accounts** -> **+ Create**.
2. Same resource group, **Standard** performance, **LRS** redundancy (Dev) or **GRS** (Prod, per spec).
3. After it's created, go to **Security + networking > Access keys**, copy a **Connection string**.
4. Add one more Application Setting on the App Service:

| Name | Value |
|---|---|
| `Storage__ConnectionString` | the connection string you just copied |

---

## Deploying the code itself

Creating resources and deploying code are two different actions - everything above stands up empty infrastructure with no app running on it yet.

**This App Service hosts the API and nothing else.** The Angular app is a separate deploy to its own Static Web App; it is never built into this project's `wwwroot`. See the frontend README for that half.

The documented route is an FTP upload of the published output - build it, then upload it by hand:

```bash
dotnet publish src/IBS.Api -c Release -o ./publish
```

Full steps, including the `WEBSITE_RUN_FROM_PACKAGE` trap, are under **Releasing to the App Service** in the [backend README](../README.md).

If you would rather use ZIP Deploy than FTP, zip the *contents* of `publish/` and drop the zip on **Deployment Center > ZIP Deploy**, or use **Advanced Tools (Kudu) > Zip Push Deploy** - but note that switching to zip deploy means FTP uploads stop taking effect, per the callout in Part C.

## Smoke test

Once code is deployed:

```bash
curl -s -o /dev/null -w "%{http_code}\n" "https://ibs-api-dev.azurewebsites.net/swagger/v1/swagger.json"
curl -s -o /dev/null -w "%{http_code}\n" "https://ibs-api-dev.azurewebsites.net/api/employees"
```

The first should be `200`, the second `401` - signed out, same as locally. Don't smoke-test `/`: this App Service serves no UI, so the root has nothing to return. The site people visit is the Static Web App.

## First account

A fresh SQL database has no employees yet - the seed tool needs to run once against it:

```bash
ConnectionStrings__IbsDatabase="<the same connection string you put in the App Service>" \
  dotnet run --project tools/IBS.SeedSuperAdmin
```

Run this from your own machine, not on the App Service - the tool needs an interactive console for the password prompt.

## Restarts and the signing key

App Service restarts routinely - a deploy, a scale event, a nightly recycle - and it may run more than one instance. Bearer tokens survive all of that **as long as every instance signs with the same `Jwt__SigningKey`**, which an Application Setting guarantees: one value, read by every instance at startup.

The consequence worth remembering runs the other way. **Changing `Jwt__SigningKey` invalidates every token already issued**, signing everyone out at once. That is exactly the right response to a suspected leak, and a reason not to churn the value otherwise.

There is no Data Protection key ring to persist here - that was a requirement of the earlier cookie-based auth, which this API no longer uses.

## What this leaves out

- **Custom domain / certificate** - the default `*.azurewebsites.net` domain and its built-in TLS cover both Dev and Prod for now.
- **Azure Communication Services (email)** - still optional; invite and reset links show up in the UI instead.
- **CI/CD** - every deploy is a manual action, as you've chosen.
