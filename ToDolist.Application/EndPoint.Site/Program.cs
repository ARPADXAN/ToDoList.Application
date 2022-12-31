using Application.Interfaces;
using Infrastracture.IdentityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.DataBaseContext;

var builder = WebApplication.CreateBuilder(args);
//inject classess//
var Configuration =builder.Services.BuildServiceProvider().CreateScope()
    .ServiceProvider.GetRequiredService<IConfiguration>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IDataBaseContext, DataBaseContextMain>();
builder.Services.AddDbContext<DataBaseContextMain>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add v and Cookie.
builder.Services.AddAuthorization();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/LogOut";
    options.AccessDeniedPath = "/Account/AccessDenied";
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

app.Run();
