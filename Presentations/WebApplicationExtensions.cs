using Infrastructure.Databases;

namespace Presentation;

public static class WebApplicationExtensions
{
    public static WebApplication UseInfrastructure(this WebApplication application)
    {
        using var serviceScope = application.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        serviceScope.SetupDatabase(application.Environment.IsDevelopment() || application.Environment.IsEnvironment("Test"));

        return application;
    }
}