using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApi.RepositoryPatern
{
    public interface IGenericRepository<T> where T : class
    {
         void Insert(T obj);
         void Update(T obj);
         void Delete(object id);
       
    }
}
