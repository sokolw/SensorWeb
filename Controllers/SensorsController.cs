using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SensorWeb.Sensor.DataAccess.Repository.IRepository;
using SensorWeb.Sensor.DataAccess.RequestAPI;
using SensorWeb.Sensor.Models;

namespace SensorWeb.Controllers
{
    public class SensorsController : Controller
    {
        private readonly ISensorModelRepository sensorModelRepository;
        private readonly DataFromAPI dataFromAPI;

        public SensorsController(ISensorModelRepository sensorModelRepository, DataFromAPI dataFromAPI)
        {
            this.sensorModelRepository = sensorModelRepository;
            this.dataFromAPI = dataFromAPI;
        }

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<SensorModel> sensorsList = sensorModelRepository.GetAll();
            return View(sensorsList);
        }

        [Authorize]
        [HttpPost, ActionName("Index")]
        public async Task<ActionResult> IndexPOST()
        {
            SensorModelJson temp = await dataFromAPI.GetData();
            Console.WriteLine(dataFromAPI.ConvertSensorModelJson(temp).Name);
            sensorModelRepository.Add(dataFromAPI.ConvertSensorModelJson(temp));
            sensorModelRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
