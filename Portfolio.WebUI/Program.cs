using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Business.Abstract;
using Portfolio.Business.Concrete;
using Portfolio.DataAccess.Abstract;
using Portfolio.DataAccess.Context;
using Portfolio.DataAccess.EFCore;
using Portfolio.DataAccess.Repositories;
using Portfolio.Entity.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// GENERIC
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

// AboutSection
builder.Services.AddScoped<IAboutSectionDal, AboutSectionDal>();
builder.Services.AddScoped<IAboutSectionService, AboutSectionService>();

// HeroSection
builder.Services.AddScoped<IHeroSectionDal, HeroSectionDal>();
builder.Services.AddScoped<IHeroSectionService, HeroSectionService>();

// ContactSection
builder.Services.AddScoped<IContactSectionDal, ContactSectionDal>();
builder.Services.AddScoped<IContactSectionService, ContactSectionService>();

// ProjectsSection
builder.Services.AddScoped<IProjectsSectionDal, ProjectsSectionDal>();
builder.Services.AddScoped<IProjectsSectionService, ProjectsSectionService>();

// Project
builder.Services.AddScoped<IProjectDal, ProjectDal>();
builder.Services.AddScoped<IProjectService, ProjectService>();

// Skill
builder.Services.AddScoped<ISkillDal, SkillDal>();
builder.Services.AddScoped<ISkillService, SkillService>();

// SocialMedia
builder.Services.AddScoped<ISocialMediaDal, SocialMediaDal>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();

// Auth
builder.Services.AddScoped<IAuthDal, AuthDal>();
builder.Services.AddScoped<IAuthService, AuthService>();


// AUTHENTICATION
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "AdminPanel.Auth"; 
        options.LoginPath = "/Admin/Auth/Login"; 
        options.LogoutPath = "/Admin/Auth/Logout"; 
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60); 
    });


builder.Services.AddScoped<IPasswordHasher<Admin>, PasswordHasher<Admin>>();


var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
}

app.UseStaticFiles(); 
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);


app.Run();