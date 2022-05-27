using SensorWeb.Sensor.Data;
using SensorWeb.Sensor.DataAccess.Repository.IRepository;
using SensorWeb.Sensor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorWeb.Sensor.DataAccess.Repository
{
    public class SensorModelRepository : Repository<SensorModel>, ISensorModelRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SensorModelRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        void ISensorModelRepository.Save()
        {
            applicationDbContext.SaveChanges();
        }

        void ISensorModelRepository.Update(SensorModel obj)
        {
            applicationDbContext.Sensors.Update(obj);
        }
    }
}
