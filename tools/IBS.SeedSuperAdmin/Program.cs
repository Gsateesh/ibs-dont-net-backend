using IBS.Infrastructure;
using IBS.Infrastructure.Configuration;
using IBS.Infrastructure.Persistence;
using IBS.Modules.UsersAccess.Application.Abstractions;
using IBS.Modules.UsersAccess.Domain.Entities;
using IBS.Modules.UsersAccess.Domain.Enums;
using IBS.Modules.UsersAccess.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// IBS.SeedSuperAdmin - bootstraps the single Super Admin account (spec section 6.1).
//
// This tool is the only place in the codebase allowed to insert an Employee row with a
// non-null PasswordHash. Every other path creates the row with no password and requires
// the person to activate it themselves.
//
// The password is typed here by whoever will actually be the Super Admin. It is never
// generated on their behalf, never written to a log or to source control, and never known
// to a second party - so no forced reset is needed afterwards.
//
//   dotnet run --project tools/IBS.SeedSuperAdmin -- --print-hash-only
//   dotnet run --project tools/IBS.SeedSuperAdmin

var printHashOnly = args.Contains("--print-hash-only", StringComparer.OrdinalIgnoreCase);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true)
    .AddJsonFile("appsettings.Development.json", optional: true)
    // The same appsettings.Local.json the API reads, so this targets the database the app uses.
    .AddIbsLocalSettings()
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .Build();

Console.WriteLine("IBS - Super Admin bootstrap");
Console.WriteLine(new string('-', 40));

// Say which database this will write to before asking for anything. Getting the wrong
// environment is the one mistake worth catching before a password is typed, not after.
var target = configuration.GetConnectionString("IbsDatabase");
Console.WriteLine(target is null
    ? $"Settings:  none found ({LocalSettings.FileName} is missing)"
    : $"Settings:  {LocalSettings.Find() ?? "environment"}");
Console.WriteLine($"Database:  {DescribeTarget(target)}");
Console.WriteLine();

var email = Prompt("Email: ");
var firstName = Prompt("First name: ");
var lastName = Prompt("Last name: ");
var password = PromptPassword("Password (min 10 chars): ");
var confirm = PromptPassword("Confirm password: ");

if (password != confirm)
{
    Console.Error.WriteLine("Passwords do not match. Nothing was written.");
    return 1;
}

if (password.Length < 10)
{
    Console.Error.WriteLine("Password must be at least 10 characters. Nothing was written.");
    return 1;
}

var services = new ServiceCollection();

if (printHashOnly)
{
    // No database needed: hash and print, for a manual INSERT against a locked-down environment.
    var hasher = new IBS.Infrastructure.Security.IdentityPasswordHasher();
    Console.WriteLine();
    Console.WriteLine("PasswordHash:");
    Console.WriteLine(hasher.Hash(password));
    Console.WriteLine();
    Console.WriteLine("Insert it yourself with IsSuperAdmin = 1 and Status = 2 (Active).");
    return 0;
}

services.AddSingleton<IConfiguration>(configuration);
services.AddLogging();
services.AddIbsInfrastructure(configuration);

await using var provider = services.BuildServiceProvider();
using var scope = provider.CreateScope();

var db = scope.ServiceProvider.GetRequiredService<IbsDbContext>();
var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

await db.Database.MigrateAsync();

if (await db.Employees.AnyAsync(e => e.IsSuperAdmin))
{
    Console.Error.WriteLine("A Super Admin already exists. There can only be one; nothing was written.");
    return 1;
}

var normalisedEmail = email.Trim().ToLowerInvariant();

if (await db.Employees.AnyAsync(e => e.Email == normalisedEmail))
{
    Console.Error.WriteLine($"An account already exists for {normalisedEmail}. Nothing was written.");
    return 1;
}

var superAdmin = new Employee
{
    FirstName = firstName.Trim(),
    LastName = lastName.Trim(),
    Email = normalisedEmail,
    EmployeeCode = "EMP-0001",
    DateOfJoining = DateOnly.FromDateTime(DateTime.UtcNow),
    EmploymentType = EmploymentType.FullTime,
    DesignationId = LookupSeed.SuperAdminDesignationId,
    DepartmentId = LookupSeed.DefaultDepartmentId,
    BranchId = LookupSeed.DefaultBranchId,
    Status = EmployeeStatus.Active,
    PasswordHash = passwordHasher.Hash(password),
    // Not forced: the person choosing the password here is the person who will use it.
    MustChangePassword = false,
    IsSuperAdmin = true,
    CreatedAt = DateTimeOffset.UtcNow
};

db.Employees.Add(superAdmin);

db.AuditLogs.Add(new AuditLog
{
    Action = "employee.super_admin_seeded",
    TargetType = nameof(Employee),
    TargetId = superAdmin.Id,
    ActorEmployeeId = null,
    Timestamp = DateTimeOffset.UtcNow
});

await db.SaveChangesAsync();

Console.WriteLine();
Console.WriteLine($"Super Admin created: {superAdmin.Email}");
Console.WriteLine("No password was stored anywhere but the hash column. Sign in to continue.");
return 0;

static string Prompt(string label)
{
    Console.Write(label);
    var value = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(value))
    {
        Console.Write(label);
        value = Console.ReadLine();
    }

    return value;
}

static string PromptPassword(string label)
{
    Console.Write(label);

    // Masking needs a real console. When input is piped (a deployment script, a CI step),
    // read the line plainly rather than failing.
    if (Console.IsInputRedirected)
    {
        return Console.ReadLine() ?? string.Empty;
    }

    var buffer = new System.Text.StringBuilder();

    while (true)
    {
        var key = Console.ReadKey(intercept: true);

        if (key.Key == ConsoleKey.Enter)
        {
            Console.WriteLine();
            return buffer.ToString();
        }

        if (key.Key == ConsoleKey.Backspace && buffer.Length > 0)
        {
            buffer.Length--;
            continue;
        }

        if (!char.IsControl(key.KeyChar))
        {
            buffer.Append(key.KeyChar);
        }
    }
}

/// <summary>
/// Renders the target as server and database only. The connection string holds a password,
/// so it is never printed whole.
/// </summary>
static string DescribeTarget(string? connectionString)
{
    if (string.IsNullOrWhiteSpace(connectionString))
    {
        return "not configured";
    }

    var parts = connectionString.Split(';', StringSplitOptions.RemoveEmptyEntries);

    string? Value(params string[] keys) => parts
        .Select(p => p.Split('=', 2))
        .Where(kv => kv.Length == 2 && keys.Contains(kv[0].Trim(), StringComparer.OrdinalIgnoreCase))
        .Select(kv => kv[1].Trim())
        .FirstOrDefault();

    var server = Value("Server", "Data Source") ?? "unknown server";
    var database = Value("Database", "Initial Catalog") ?? "unknown database";

    return $"{database} on {server}";
}
