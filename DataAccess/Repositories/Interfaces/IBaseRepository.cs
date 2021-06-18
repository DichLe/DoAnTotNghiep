using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Create(T obj);
        T GetById(object id);
        bool Update(T obj);
        bool Delete(object id, ref bool isDeleted);

    }
}
