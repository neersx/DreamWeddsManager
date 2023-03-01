using DreamWeddsManager.Application.Configurations;
using DreamWeddsManager.Application.Interfaces.Services;
using DreamWeddsManager.Application.Interfaces.Services.Account;
using DreamWeddsManager.Application.Interfaces.Services.Identity;
using DreamWeddsManager.Infrastructure;
using DreamWeddsManager.Infrastructure.Contexts;
using DreamWeddsManager.Infrastructure.Models.Identity;
using DreamWeddsManager.Infrastructure.Services;
using DreamWeddsManager.Infrastructure.Services.Identity;
using DreamWeddsManager.Infrastructure.Shared.Services;
using DreamWeddsManager.Shared.Constants.Localization;
using DreamWeddsManager.Shared.Constants.Permission;
using DreamWeddsManager.Shared.Wrapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DreamWeddsManager.Application.Interfaces.Serialization.Options;
using DreamWeddsManager.Application.Interfaces.Serialization.Serializers;
using DreamWeddsManager.Application.Interfaces.Serialization.Settings;
using DreamWeddsManager.Application.Serialization.JsonConverters;
using DreamWeddsManager.Application.Serialization.Options;
using DreamWeddsManager.Application.Serialization.Serializers;
using DreamWeddsManager.Application.Serialization.Settings;
using DreamWeddsManager.Application.Interfaces;
using DreamWedds.Client.WebApp.Services;
using DreamWedds.Client.WebApp.Permission;
using DreamWedds.Client.WebApp.Localization;
using DreamWedds.Client.WebApp.Managers.Preferences;
using DreamWedds.Client.WebApp.Settings;
using DreamWeddsManager.Client.Infrastructure.Managers.Identity.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DreamWedds.Client.WebApp.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static async Task<IStringLocalizer> GetRegisteredServerLocalizerAsync<T>(this IServiceCollection services) where T : class
        {
            var serviceProvider = services.BuildServiceProvider();
            await SetCultureFromServerPreferenceAsync(serviceProvider);
            var localizer = serviceProvider.GetService<IStringLocalizer<T>>();
            await serviceProvider.DisposeAsync();
            return localizer;
        }

        private static async Task SetCultureFromServerPreferenceAsync(IServiceProvider serviceProvider)
        {
            var storageService = serviceProvider.GetService<ServerPreferenceManager>();
            if (storageService != null)
            {
                // TODO - should implement ServerStorageProvider to work correctly!
                CultureInfo culture;
                var preference = await storageService.GetPreference() as ServerPreference;
                if (preference != null)
                    culture = new CultureInfo(preference.LanguageCode);
                else
                    culture = new CultureInfo(LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US");
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }
        }

        internal static IServiceCollection AddServerLocalization(this IServiceCollection services)
        {
            services.TryAddTransient(typeof(IStringLocalizer<>), typeof(ServerLocalizer<>));
            return services;
        }

        internal static AppConfiguration GetApplicationSettings(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection(nameof(AppConfiguration));
            services.Configure<AppConfiguration>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<AppConfiguration>();
        }

        //internal static void RegisterSwagger(this IServiceCollection services)
        //{
        //    services.AddSwaggerGen(async c =>
        //    {
        //        //TODO - Lowercase Swagger Documents
        //        //c.DocumentFilter<LowercaseDocumentFilter>();
        //        //Refer - https://gist.github.com/rafalkasa/01d5e3b265e5aa075678e0adfd54e23f

        //        // include all project's xml comments
        //        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        //        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        //        {
        //            if (!assembly.IsDynamic)
        //            {
        //                var xmlFile = $"{assembly.GetName().Name}.xml";
        //                var xmlPath = Path.Combine(baseDirectory, xmlFile);
        //                if (File.Exists(xmlPath))
        //                {
        //                    c.IncludeXmlComments(xmlPath);
        //                }
        //            }
        //        }

        //        c.SwaggerDoc("v1", new OpenApiInfo
        //        {
        //            Version = "v1",
        //            Title = "DreamWeddsManager",
        //            License = new OpenApiLicense
        //            {
        //                Name = "MIT License",
        //                Url = new Uri("https://opensource.org/licenses/MIT")
        //            }
        //        });

        //        var localizer = await GetRegisteredServerLocalizerAsync<ServerCommonResources>(services);

        //        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //        {
        //            Name = "Authorization",
        //            In = ParameterLocation.Header,
        //            Type = SecuritySchemeType.ApiKey,
        //            Scheme = "Bearer",
        //            BearerFormat = "JWT",
        //            Description = localizer["Input your Bearer token in this format - Bearer {your token here} to access this API"],
        //        });
        //        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        //        {
        //            {
        //                new OpenApiSecurityScheme
        //                {
        //                    Reference = new OpenApiReference
        //                    {
        //                        Type = ReferenceType.SecurityScheme,
        //                        Id = "Bearer",
        //                    },
        //                    Scheme = "Bearer",
        //                    Name = "Bearer",
        //                    In = ParameterLocation.Header,
        //                }, new List<string>()
        //            },
        //        });
        //    });
        //}

        internal static IServiceCollection AddSerialization(this IServiceCollection services)
        {
            services
                .AddScoped<IJsonSerializerOptions, SystemTextJsonOptions>()
                .Configure<SystemTextJsonOptions>(configureOptions =>
                {
                    if (!configureOptions.JsonSerializerOptions.Converters.Any(c => c.GetType() == typeof(TimespanJsonConverter)))
                        configureOptions.JsonSerializerOptions.Converters.Add(new TimespanJsonConverter());
                });
            services.AddScoped<IJsonSerializerSettings, NewtonsoftJsonSettings>();

            services.AddScoped<IJsonSerializer, SystemTextJsonSerializer>(); // you can change it
            return services;
        }

        internal static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<BlazorHeroContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
            .AddTransient<IDatabaseSeeder, DatabaseSeeder>();

        internal static IServiceCollection AddCurrentUserService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IBlazorHeroContext>(provider => provider.GetService<BlazorHeroContext>());
            return services;
        }

        internal static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>()
                .AddIdentity<BlazorHeroUser, BlazorHeroRole>()
                .AddEntityFrameworkStores<BlazorHeroContext>()
                .AddDefaultTokenProviders();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(24);
                options.SlidingExpiration = true;
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(1));
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
                // Here I stored necessary permissions/roles in a constant
                foreach (var prop in typeof(Permissions).GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
                {
                    var propertyValue = prop.GetValue(null);
                    if (propertyValue is not null)
                    {
                        options.AddPolicy(propertyValue.ToString(), policy => policy.RequireClaim(ApplicationClaimTypes.Permission, propertyValue.ToString()));
                    }
                }
            });

            return services;
        }

        internal static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeService, SystemDateTimeService>();
            services.Configure<MailConfiguration>(configuration.GetSection("MailConfiguration"));
            services.AddTransient<IMailService, SMTPMailService>();
            return services;
        }

        internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IRoleClaimService, RoleClaimService>();
            services.AddTransient<ITokenService, IdentityService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IUploadService, UploadService>();
            services.AddTransient<IAuditService, AuditService>();
            services.AddScoped<IExcelService, ExcelService>();
            return services;
        }

        internal static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services, AppConfiguration config)
        {
            var key = Encoding.ASCII.GetBytes(config.Secret);
            services.AddAuthentication("authCookie");
            services.AddAuthorization(options =>
            {
                // Here I stored necessary permissions/roles in a constant
                foreach (var prop in typeof(Permissions).GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
                {
                    var propertyValue = prop.GetValue(null);
                    if (propertyValue is not null)
                    {
                        options.AddPolicy(propertyValue.ToString(), policy => policy.RequireClaim(ApplicationClaimTypes.Permission, propertyValue.ToString()));
                    }
                }
            });
            return services;
        }

        internal static IApplicationBuilder Initialize(this IApplicationBuilder app, Microsoft.Extensions.Configuration.IConfiguration _configuration)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var initializers = serviceScope.ServiceProvider.GetServices<IDatabaseSeeder>();

            foreach (var initializer in initializers)
            {
                initializer.Initialize();
            }

            return app;
        }
    }
}