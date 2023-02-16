using DreamWedds.Client.WebApp.Models;
using Microsoft.Extensions.Options;

namespace DreamWedds.Client.WebApp
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddRazorPageServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmartSettings>(configuration.GetSection(SmartSettings.SectionName));
            services.AddSingleton(s => s.GetRequiredService<IOptions<SmartSettings>>().Value);
            return services;
        }
    }
}
