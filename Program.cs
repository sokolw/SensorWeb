using Microsoft.EntityFrameworkCore;
using SensorWeb.Sensor.Data;
using SensorWeb.Sensor.DataAccess.Repository;
using SensorWeb.Sensor.DataAccess.Repository.IRepository;
using SensorWeb.Sensor.DataAccess.RequestAPI;
using SensorWeb.Sensor.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// удобный сервис дл€ динамической компл€ции разор страниц
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
// тож в DI
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
// делаем DI зависимость
builder.Services.AddScoped<ISensorModelRepository, SensorModelRepository>(); // подключаем парттерн Repository 
// сервис дл€ получени€ данных по апи
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
