using JobFinder.Application.Interfaces.Repository;
using JobFinder.Application.Interfaces.Services;
using JobFinder.Helper;
using JobFinder.Infrastructure.DbContexts;
using JobFinder.Infrastructure.Identity;
using JobFinder.Infrastructure.Identity.Models;
using JobFinder.Infrastructure.Identity.Services;
using JobFinder.Infrastructure.Repository;
using JobFinder.Infrastructure.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using JobFinder.Application.Models.Settings;
using Microsoft.Extensions.Configuration;
using JobFinder.Application.Interfaces.Shared;
using JobFinder.Infrastructure.Shared;
using JobFinder.Middlewares;
using JobFinder.Infrastructure.Store;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Hosting;

Console.Write("Hello");

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/account/login");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IStoreContext, StoreContext>();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddTransient<ICurrentUser, CurrentUser>();
builder.Services.AddTransient<IApplicantService, ApplicantService>();
builder.Services.AddTransient<ICertificateService, CertificateService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IEducationService, EducationService>();
builder.Services.AddTransient<IExperienceService, ExperienceService>();
builder.Services.AddTransient<IIdentityService, IdentityService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<ISkillService, SkillService>();
builder.Services.AddTransient<ILanguageService, LanguageService>();
builder.Services.AddTransient<IJobService, JobService>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IReferenceService, ReferenceService>();


builder.Services.AddTransient<IMailService, SMTPMailService>();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions((option) =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}).AddRazorRuntimeCompilation();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        //todo enable this
        SeedUser.InitializeAsync(services).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

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
app.UseMiddleware<FillStoreContextMiddleware>();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
