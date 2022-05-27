using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SensorWeb.Sensor.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class //Ограничения на параметры типа Аргумент типа class должен быть ссылочным типом
    {
        // T - Any model class

        IEnumerable<T> GetAll();

        T GetById(int? id);

        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);
    }
}
