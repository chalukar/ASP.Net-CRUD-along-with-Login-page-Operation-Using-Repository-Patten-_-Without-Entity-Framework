using Employee_info.DataAccess;
using Employee_info.Repositiries;
using Microsoft.AspNetCore.Authentication.Cookies;
using NuGet.Protocol.Plugins;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<IRoleRepository,RoleRepository>();
builder.Services.AddSingleton<IUserRepository,UserRepository>();
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddSingleton<ICityRepository, CityRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.ExpireTimeSpan= TimeSpan.FromMinutes(60 * 1);
        option.LoginPath = "/Accounts/Login";
        option.AccessDeniedPath = "/Accounts/Login";
    });
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(5);
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}");

app.Run();
