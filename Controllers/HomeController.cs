using Microsoft.AspNetCore.Mvc;
using SensorWeb.Sensor.DataAccess.Repository.IRepository;
using SensorWeb.Sensor.DataAccess.RequestAPI;
using SensorWeb.Sensor.Models;
using System.Diagnostics;

namespace SensorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISensorModelRepository sensorModelRepository;
        private readonly DataFromAPI dataFromAPI;

        public HomeController(ISensorModelRepository sensorModelRepository, DataFromAPI dataFromAPI)
        {
            this.sensorModelRepository = sensorModelRepository;
            this.dataFromAPI = dataFromAPI;
        }

        public IActionResult Index()
        {
            IEnumerable<SensorModel> sensorsList = sensorModelRepository.GetAll();
            return View(sensorsList);
        }

        [HttpPost, ActionName("Index")]
        public async Task<ActionResult> IndexPOST()
        {
            SensorModelJson temp = await dataFromAPI.GetData();
            Console.WriteLine(dataFromAPI.ConvertSensorModelJson(temp).Name);
            sensorModelRepository.Add(dataFromAPI.ConvertSensorModelJson(temp));
            sensorModelRepository.Save();
            return RedirectToAction("Index");
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