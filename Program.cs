using Microsoft.EntityFrameworkCore;
using SensorWeb.Sensor.Data;
using SensorWeb.Sensor.DataAccess.Repository;
using SensorWeb.Sensor.DataAccess.Repository.IRepository;
using SensorWeb.Sensor.DataAccess.RequestAPI;
using SensorWeb.Sensor.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
// identity autogen
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
// identity autogen

// Add services to the container.
builder.Services.AddControllersWithViews();
// useful service for dynamically compile RazorPages
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
// use DI
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
// use DI
builder.Services.AddScoped<ISensorModelRepository, SensorModelRepository>(); // use in service pattern-Repository 
// add service to access API
builder.Services.AddScoped<DataFromAPI>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
