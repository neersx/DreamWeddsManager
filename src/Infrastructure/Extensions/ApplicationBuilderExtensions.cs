﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Context;
using static DreamWeddsManager.Shared.Constants.Application.ApplicationConstants;

namespace DreamWeddsManager.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app, IConfiguration config)
        {
            app.UseSerilogRequestLogging(options =>
            {
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) => {
                    //This didn't work when tested
                    diagnosticContext.Set("UserName", httpContext.User.GetDisplayName());
                };
            });
            app.Use(async (httpContext, next) =>
            {
                //This is the correct implementation 
                LogContext.PushProperty("UserName", httpContext.User.GetDisplayName()); //Push user in LogContext;
                await next.Invoke();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"Files")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), @"Files"));
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
                RequestPath = new PathString("/Files")
            });

            app.UseRequestLocalization();
            //app.UseMiddlewares();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseHangfireDashboard("/hangfire/index");
            //app.UseWorkflow();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                //endpoints.MapHub<SignalRHub>(SignalR.HubUrl);
            });
            return app;
        }
    }
}
