using System.Reflection;
using FancyWebApp.DataBase;
using FancyWebApp.Interfaces.Repositories;
using FancyWebApp.Interfaces.Services;
using FancyWebApp.Repositories;
using FancyWebApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    opt.Lockout.MaxFailedAccessAttempts = 5;
    opt.Lockout.AllowedForNewUsers = true;
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 8;
    opt.SignIn.RequireConfirmedEmail = false;
    opt.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    opt.SignIn.RequireConfirmedPhoneNumber = false;
});
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.AccessDeniedPath = "/Identity/Account/AccessDenied";
    opt.Cookie.HttpOnly = true;
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    opt.LoginPath = "/Access/Login";
    opt.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    opt.SlidingExpiration = true;
});

builder.Services.Configure<PasswordHasherOptions>(opt =>
{
    opt.IterationCount = 12000;
});

builder.Services.Configure<SecurityStampValidatorOptions>(opt => opt.ValidationInterval = TimeSpan.FromMinutes(1));
builder.Services.AddDbContext<ShipmentDB>(opt => opt
    .UseSqlServer("Server=localhost,1433; User Id=SA; Database=ShipmentDB; Password=MagnaniniA99;TrustServerCertificate=True"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseFileServer();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

app.MapFallbackToFile("index.html");
;

app.Run();