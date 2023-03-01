using DreamWedds.Client.WebApp;
using DreamWedds.Client.WebApp.Data;
using DreamWedds.Client.WebApp.Extensions;
using DreamWedds.Client.WebApp.Models;
using DreamWeddsManager.Application.Extensions;
using DreamWeddsManager.Application.Interfaces.Common;
using DreamWeddsManager.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPageServices(builder.Configuration);
//builder.Services.Configure<SmartSettings>(builder.Configuration.GetSection(SmartSettings.SectionName));
//            builder.Services.AddSingleton(s => s.GetRequiredService<IOptions<SmartSettings>>().Value);
//            builder.Services.AddHealthChecks();

builder.Services.AddCors();
builder.Services.AddSignalR();
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.AddCurrentUserService();
builder.Services.AddSerialization();
builder.Services.AddDatabase(builder.Configuration);
//builder.Services.AddServerStorage(); //TODO - should implement ServerStorageProvider to work correctly!
//builder.Services.AddScoped<ServerPreferenceManager>();
builder.Services.AddServerLocalization();
builder.Services.AddIdentity();
builder.Services.AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration));
builder.Services.AddApplicationLayer();
builder.Services.AddApplicationServices();
builder.Services.AddRepositories();
builder.Services.AddExtendedAttributesUnitOfWork();
builder.Services.AddSharedInfrastructure(builder.Configuration);
//builder.Services.RegisterSwagger();
builder.Services.AddInfrastructureMappings();
//builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddHangfireServer();
builder.Services.AddControllers();
//builder.Services.AddExtendedAttributesValidators();
builder.Services.AddExtendedAttributesHandlers();
//builder.Services.AddRazorPages();
//builder.Services.AddApiVersioning(config =>
//{
//    config.DefaultApiVersion = new ApiVersion(1, 0);
//    config.AssumeDefaultVersionWhenUnspecified = true;
//    config.ReportApiVersions = true;
//});
builder.Services.AddLazyCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    // Console.WriteLine($"The authenticated status {context.User.Identity!.IsAuthenticated}");
    await next.Invoke();
    Console.WriteLine($"The authenticated status 1 {context.User.Identity!.IsAuthenticated}");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.Use(async (context, next) =>
{
    // Console.WriteLine($"The authenticated status {context.User.Identity!.IsAuthenticated}");
    await next.Invoke();
    Console.WriteLine($"The authenticated status 2 {context.User.Identity!.IsAuthenticated}");
});
app.UseAuthentication();

app.Use(async (context, next) =>
{
    // Console.WriteLine($"The authenticated status {context.User.Identity!.IsAuthenticated}");
    await next.Invoke();
    Console.WriteLine($"The authenticated status 3 {context.User.Identity!.IsAuthenticated}");
});
app.UseAuthorization();

app.MapRazorPages();
app.Initialize(builder.Configuration);
app.Run();
