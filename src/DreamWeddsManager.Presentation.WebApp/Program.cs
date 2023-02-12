using DreamWeddsManager.Application.Extensions;
using DreamWeddsManager.Application.Interfaces.Common;
using DreamWeddsManager.Infrastructure.Contexts;
using DreamWeddsManager.Infrastructure.Extensions;
using DreamWeddsManager.Infrastructure.Models.Identity;
using DreamWeddsManager.Server.Managers.Preferences;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using SmartAdmin.WebUI;
using SmartAdmin.WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
                .MinimumLevel.Override("Serilog", LogEventLevel.Error)
          .Enrich.FromLogContext()
          .Enrich.WithClientIp()
          .Enrich.WithClientAgent()
          .WriteTo.Console()
    );


builder.Services.AddRazorPageServices(builder.Configuration);
builder.Services.AddCurrentUserService();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddIdentity();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.AddCurrentUserService();
builder.Services.AddSerialization();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddServerStorage(); //TODO - should implement ServerStorageProvider to work correctly!
builder.Services.AddScoped<ServerPreferenceManager>();
builder.Services.AddServerLocalization();
builder.Services.AddIdentity();
builder.Services.AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration));
builder.Services.AddApplicationLayer();
builder.Services.AddApplicationServices();
builder.Services.AddRepositories();
builder.Services.AddExtendedAttributesUnitOfWork();
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.RegisterSwagger();
builder.Services.AddInfrastructureMappings();
builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();

//builder.Services.AddInfrastructureServices(builder.Configuration)
//                .AddApplicationServices()
//                .AddWorkflow(builder.Configuration);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<BlazorHeroContext>();

            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
            }

            var userManager = services.GetRequiredService<UserManager<BlazorHeroUser>>();
            var roleManager = services.GetRequiredService<RoleManager<BlazorHeroRole>>();

            //await ApplicationDbContextSeed.SeedDefaultUserAsync(userManager, roleManager);
            //await ApplicationDbContextSeed.SeedSampleDataAsync(context);
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

            logger.LogError(ex, "An error occurred while migrating or seeding the database.");

            throw;
        }
    }
}
else
{
    app.UseHsts();
}
app.UseInfrastructure(builder.Configuration);
await app.RunAsync();
