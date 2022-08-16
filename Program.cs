using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using WiFi_Antennas_Win.DAL.EF;
using WiFi_Antennas_Win.DAL.Interfaces;
using WiFi_Antennas_Win.DAL.Repositories;
using WiFi_Antennas_Win.BLL.Interfaces;
using WiFi_Antennas_Win.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Default") ?? throw new Exception("Bad connection path"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccessUserService, AccessUserService>();
builder.Services.AddTransient<ITokenCreator, TokenCreator>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/auth/login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

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
