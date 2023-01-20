using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns;
using Application.Services.TodoItem.Commands.NotifyAlertOnTime;
using Application.Services.TodoItem.FacadPattern;
using EndPoint.Site.Hubs;
using Infrastracture.IdentityConfig;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.DataBaseContext;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

var builder = WebApplication.CreateBuilder(args);
//inject classess//
var Configuration =builder.Services.BuildServiceProvider().CreateScope()
    .ServiceProvider.GetRequiredService<IConfiguration>();

builder.Services.AddSignalR();
// Add services to the container.
builder.Services.AddTransient<IDataBaseContext, DataBaseContextMain>();
builder.Services.AddTransient<ICartFacad, CartFacad>();
#region Schedule
builder.Services.AddSingleton<IJobFactory, singeltonjobfactory>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
#endregion

builder.Services.AddDbContext<DataBaseContextMain>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Path.GetTempPath()));
builder.Services.AddControllersWithViews();
//Add v and Cookie.
builder.Services.AddAuthorization();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
    options.LoginPath = "/Account/Register";
    options.LogoutPath = "/Account/LogOut";

    options.AccessDeniedPath = "/Account/Register";
    options.SlidingExpiration = true;
});

//AddService//
builder.Services.AddidentityService(Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<Notify>("/notify");
app.Run();
