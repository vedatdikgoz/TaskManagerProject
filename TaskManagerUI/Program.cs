
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagerBusiness.Containers;
using TaskManagerUI.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDependencies();
builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

builder.Services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer("server=VEDAT; Database=TaskManagerDB; Trusted_Connection=true; MultipleActiveResultSets=true"));


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;


    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = ".TaskManager.Security.Cookie",
        SameSite = SameSiteMode.Strict
    };

});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
