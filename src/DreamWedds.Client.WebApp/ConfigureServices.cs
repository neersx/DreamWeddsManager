using DreamWedds.Client.WebApp.Filters;
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
            services.AddHealthChecks();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddControllers();
            services.AddRazorPages(options =>
            {
                options.Conventions.AddPageRoute("/", "");
            })
                     .AddMvcOptions(options =>
                     {
                         options.Filters.Add<ApiExceptionFilterAttribute>();
                     })
    .AddViewLocalization()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;

    })
    .AddRazorRuntimeCompilation();
            services.AddSignalR();
            return services;
        }
    }
}
