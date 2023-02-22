using DreamWedds.Client.WebApp;
using DreamWedds.Client.WebApp.Data;
using DreamWedds.Client.WebApp.Extensions;
using DreamWeddsManager.Application.Interfaces.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPageServices(builder.Configuration);
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddCurrentUserService();
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddIdentity();
builder.Services.AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration));

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
