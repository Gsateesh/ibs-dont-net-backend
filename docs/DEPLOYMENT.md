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
| `UsersAccess__AppBaseUrl` | `https://ibs-api-dev.azurewebsites.net` - your own App Service's URL. This is what invite and reset links point at, so it must match exactly. |
| `WEBSITE_RUN_FROM_PACKAGE` | `1` - makes the app run directly from the deployed zip, the standard fast path for .NET on App Service. |

Click **Save** at the top, then **Continue** through the restart prompt.

**Why `ASPNETCORE_ENVIRONMENT` matters here, specifically:** your spec (section 2) wants EF Core migrations to apply automatically on startup in Dev/Test, and `Program.cs` already does exactly that when the environment is `Development` - so the *first* deploy will create the schema on its own, no extra step. On Prod, migrations are meant to be an explicit, deliberate action, never automatic against live data - so if you set `ASPNETCORE_ENVIRONMENT=Production`, you must run `dotnet ef database update` yourself, pointed at the Prod connection string, before that App Service will have a usable schema. I can run that one command for you when you're ready for the Prod pass, or hand you the exact line to run yourself.

## Part D - Storage Account (optional, for photo/document uploads)

Skip this if you don't need employee photo or document uploads to work yet - everything else (sign-in, Team, Add Person, permissions, audit log) works without it.

1. Portal search bar -> **Storage accounts** -> **+ Create**.
2. Same resource group, **Standard** performance, **LRS** redundancy (Dev) or **GRS** (Prod, per spec).
3. After it's created, go to **Security + networking > Access keys**, copy a **Connection string**.
4. Add one more Application Setting on the App Service:

| Name | Value |
|---|---|
| `Storage__ConnectionString` | the connection string you just copied |

---

## Rotate the SQL password before you go further

The password used in earlier testing this session went through chat in plaintext. If you're standing up a brand-new SQL Server here with a fresh admin password, that's already solved - just don't reuse the old one.

---

## Deploying the code itself

Creating resources and deploying code are two different actions - everything above stands up empty infrastructure with no app running on it yet. You have two options for this part:

**Option 1 - I run it for you.** Once you've done `az login` in your own browser session (I can't do this step; it needs your credentials), tell me and I'll build, publish and zip-deploy the app to whichever App Service you've created, the same way I've been running it locally all session.

**Option 2 - fully manual, via the Portal.** App Service -> **Deployment Center** -> **Local Git** or **ZIP Deploy**, then upload a zip you build yourself:

```bash
cd frontend-angular-app
npx ng build
rm -rf ../backend-service-dot-net-app/src/IBS.Api/wwwroot/*
cp -r dist/frontend-angular-app/browser/* ../backend-service-dot-net-app/src/IBS.Api/wwwroot/
cd ../backend-service-dot-net-app
dotnet publish src/IBS.Api -c Release -o ./publish
cd publish && zip -r ../ibs-deploy.zip . && cd ..
```

Then drag `ibs-deploy.zip` onto the **Deployment Center > ZIP Deploy** panel, or use **Advanced Tools (Kudu) > Zip Push Deploy**.

## Smoke test

Once code is deployed:

```bash
curl -s -o /dev/null -w "%{http_code}\n" "https://ibs-api-dev.azurewebsites.net/"
curl -s -o /dev/null -w "%{http_code}\n" "https://ibs-api-dev.azurewebsites.net/swagger/v1/swagger.json"
curl -s -o /dev/null -w "%{http_code}\n" "https://ibs-api-dev.azurewebsites.net/api/employees"
```

The last one should be `401` - signed out, same as locally. Then open the URL in a browser.

## First account

A fresh SQL database has no employees yet - the seed tool needs to run once against it:

```bash
ConnectionStrings__IbsDatabase="<the same connection string you put in the App Service>" \
  dotnet run --project tools/IBS.SeedSuperAdmin
```

Run this from your own machine, not on the App Service - the tool needs an interactive console for the password prompt.

## The session-cookie gap still applies, Key Vault or not

App Service restarts routinely - a deploy, a scale event, a nightly recycle. Each one can hand a fresh instance a *new* Data Protection key ring unless told to persist it, which silently logs out everyone signed in. Without Key Vault, the fix is simpler than before - just persist the keys to the Storage Account from Part D, no Key Vault wrapping needed:

```csharp
builder.Services.AddDataProtection()
    .PersistKeysToAzureBlobStorage(
        new Uri("https://<storage-account>.blob.core.windows.net/dataprotection/keys.xml"),
        new DefaultAzureCredential());
```

This still needs the App Service's Managed Identity to have **Storage Blob Data Contributor** on the storage account (Storage Account -> **Access control (IAM)** -> **Add role assignment**), which is a Portal step too, not a code-only fix. Say the word and I'll wire the code side in.

## What this leaves out

- **Custom domain / certificate** - the default `*.azurewebsites.net` domain and its built-in TLS cover both Dev and Prod for now.
- **Azure Communication Services (email)** - still optional; invite and reset links show up in the UI instead.
- **CI/CD** - every deploy is a manual action, as you've chosen.
