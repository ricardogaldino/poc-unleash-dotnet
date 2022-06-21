namespace Unleash.Server.Web.API.Dependencies;

public static class UnleashDependence
{
    public static void AddUnleash(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = new UnleashSettings
        {
            AppName = "Unleash.Server.Web.API",
            ProjectId = "default",
            Environment = "development",
            UnleashApi = new Uri("http://localhost:4242/api"),
            CustomHttpHeaders = new Dictionary<string, string>
            {
                {"Authorization", "default:development.unleash-insecure-api-token"}
            }
        };

        var unleash = new DefaultUnleash(settings);

        services.AddScoped<IUnleash>(sp => unleash);
    }
}