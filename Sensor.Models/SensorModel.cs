using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorWeb.Sensor.Models
{
    public class SensorModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public virtual string GPS { get; set; }

        public string Glonass { get; set; }

        public int Сharge { get; set; }

        public double Indication { get; set; }

        public DateTime Date { get; set; }
    }
}
