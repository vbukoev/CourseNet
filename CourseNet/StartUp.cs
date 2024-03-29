using CourseNet.Data;
using CourseNet.Data.Models.Entities;
using CourseNet.Services.Data.Interfaces;
using CourseNet.Web.Infrastructure.Extensions;
using CourseNet.Web.Infrastructure.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CourseNetDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<CourseUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
        options.Password.RequiredLength = builder.Configuration.GetValue<int>("Password:SignIn:RequiredLength");
        options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Password:SignIn:RequireLowercase");
        options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Password:SignIn:RequireNonAlphanumeric"); 
        options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Password:SignIn:RequireUppercase"); 
    })
    .AddEntityFrameworkStores<CourseNetDbContext>();

builder.Services.AddApplicationServices(typeof(ICourseService));

builder.Services
    .AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "LecturesRoute",
        pattern: "{controller=Lectures}/{action=AllLecturesForCourse}/{courseId?}");

    endpoints.MapControllerRoute(
        name: "materials",
        pattern: "{controller=Materials}/{action=Create}/{lectureId?}");
    endpoints.MapRazorPages();
});

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();