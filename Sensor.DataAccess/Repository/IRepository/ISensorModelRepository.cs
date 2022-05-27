using SensorWeb.Sensor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorWeb.Sensor.DataAccess.Repository.IRepository
{
    public interface ISensorModelRepository : IRepository<SensorModel>
    {
        void Update(SensorModel obj);

        void Save();
    }
}
