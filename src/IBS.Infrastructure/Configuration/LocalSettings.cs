using Microsoft.Extensions.Configuration;

namespace IBS.Infrastructure.Configuration;

/// <summary>
/// Loads <c>appsettings.Local.json</c> from the repository root for every entry point - the API,
/// the EF design-time factory and the seed tool alike.
/// <para>
/// Console tools run with the working directory set whereever the user happened to be, so the
/// file is found by walking up from the compiled output instead. That is what makes
/// <c>dotnet run --project tools/IBS.SeedSuperAdmin</c> work from anywhere.
/// </para>
/// <para>
/// The file is git-ignored: it holds real connection strings for local development. In Azure the
/// same values come from Key Vault and this file does not exist (spec section 1).
/// </para>
/// </summary>
public static class LocalSettings
{
    /// <summary>Name of the local override file.</summary>
    public const string FileName = "appsettings.Local.json";

    /// <summary>
    /// Adds the local settings file at the highest precedence below environment variables,
    /// so it overrides whatever appsettings.json and appsettings.Development.json say.
    /// </summary>
    public static IConfigurationBuilder AddIbsLocalSettings(this IConfigurationBuilder builder)
    {
        var path = Find();

        if (path is not null)
        {
            builder.AddJsonFile(path, optional: true, reloadOnChange: false);
        }

        return builder;
    }

    /// <summary>
    /// Full path to the local settings file, or null when there is none. Walks up from the
    /// compiled output and then from the working directory, so it is found either way.
    /// </summary>
    public static string? Find()
    {
        foreach (var start in new[] { AppContext.BaseDirectory, Directory.GetCurrentDirectory() })
        {
            var directory = new DirectoryInfo(start);

            while (directory is not null)
            {
                var candidate = Path.Combine(directory.FullName, FileName);

                if (File.Exists(candidate))
                {
                    return candidate;
                }

                directory = directory.Parent;
            }
        }

        return null;
    }
}
