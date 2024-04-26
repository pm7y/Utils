using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Utils;

public static class ConfigurationExtensions
{
    public static string EnvironmentName(this IConfiguration configuration)
    {
        return configuration["ENVIRONMENT"].Otherwise(Environments.Production);
    }
}