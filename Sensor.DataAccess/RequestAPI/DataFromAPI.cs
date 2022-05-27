using SensorWeb.Sensor.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SensorWeb.Sensor.DataAccess.RequestAPI
{
    public class DataFromAPI : IDataFromAPI<SensorModelJson>
    {
        private static Uri apiLink = new Uri("https://localhost:5001/sensor");

        public async Task<SensorModelJson> GetData()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(apiLink);
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            SensorModelJson? sensor = DeserializeJSON(responseBody);

            return sensor;
        }

        public SensorModel ConvertSensorModelJson(SensorModelJson sensor)
        {
            return new SensorModel()
            {
                Id = sensor.Id,
                Date = sensor.Date,
                Glonass = sensor.Glonass,
                GPS = String.Join(",", sensor.GPS),
                Indication = sensor.Indication,
                Name = sensor.Name,
                OwnerName = sensor.OwnerName,
                Сharge = sensor.Сharge,
            };
        }

        private SensorModelJson? DeserializeJSON(string json)
        {
            SensorModelJson? temp = JsonSerializer.Deserialize<SensorModelJson>(json);
            return temp;
        }
    }
}
