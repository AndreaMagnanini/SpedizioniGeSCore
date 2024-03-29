// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
builder.Services.AddDbContext<ShipmentDb>(opt => opt
    .UseSqlServer("Server=ANDREA-XPS; Database=Shipments; Initial Catalog=Shipments;Integrated Security=SSPI; TrustServerCertificate=True")); // Server=localhost,1433; User Id=SA; Database=Shipment; Password=MagnaniniA99;TrustServerCertificate=True
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IPortService, PortService>();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IPortRepository, PortRepository>();

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
    pattern: "{controller}/{action}");

app.MapFallbackToFile("index.html");

app.Run();