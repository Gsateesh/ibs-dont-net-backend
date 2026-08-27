using IBS.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IBS.Infrastructure.Persistence;

/// <summary>
/// Used only by the EF Core tooling, so <c>dotnet ef migrations add</c> can build the model
/// without starting the web host. Reads the same connection string the API uses.
/// </summary>
public sealed class IbsDbContextFactory : IDesignTimeDbContextFactory<IbsDbContext>
{
    public IbsDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            // The git-ignored appsettings.Local.json at the repository root, so a connection string
            // written once works for the API, for dotnet-ef and for the seed tool alike.
            .AddIbsLocalSettings()
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("IbsDatabase")
                               ?? @"Server=(localdb)\MSSQLLocalDB;Database=IBS;Trusted_Connection=True;TrustServerCertificate=True";

        var builder = new DbContextOptionsBuilder<IbsDbContext>();
        builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(typeof(IbsDbContext).Assembly.FullName));

        return new IbsDbContext(builder.Options);
    }
}
