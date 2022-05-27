using Microsoft.AspNetCore.Mvc;
using SensorWeb.Sensor.DataAccess.Repository.IRepository;
using SensorWeb.Sensor.DataAccess.RequestAPI;
using SensorWeb.Sensor.Models;
using System.Diagnostics;

namespace SensorWeb.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}