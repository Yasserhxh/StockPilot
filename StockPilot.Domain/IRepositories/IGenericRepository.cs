using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPilot.Domain.IRepositories
{
    public interface IGenericRepository<T>where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void Add(T entity);
        void Delete(int id);

    }
}
