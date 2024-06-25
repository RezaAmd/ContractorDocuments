using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebUI.Models.InputModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.AccessDeniedPath = "/forbidden";
        options.LoginPath = "/authentication/signin";
        builder.Configuration.Bind("CookieSettings", options);
    });
builder.Services.AddAuthorization();

// Register dependency services.
builder.Services.AddDependencyServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddValidatorsFromAssemblyContaining<UserSignInInputModelValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

await app.InitialiseDatabaseAsync();

app.UseStaticFiles();

// Routing
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

#region Endpoit

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Overview}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#endregion

app.Run();
