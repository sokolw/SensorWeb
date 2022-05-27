using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorWeb.Sensor.DataAccess.RequestAPI
{
    public interface IDataFromAPI<T> where T: class
    {
        Task<T> GetData();
    }
}
