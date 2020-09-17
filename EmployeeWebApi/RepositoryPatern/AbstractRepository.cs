using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApi.RepositoryPatern
{
    public abstract class AbstractRepository<T>     
    {
        protected SqlConnection SqlConnection = new SqlConnection("Data Source=.;Initial Catalog=BlazorDb;Integrated Security=True");

        protected abstract string TableName { get; }


        public AbstractRepository()
        {
            SqlConnection.Open();
        }
       
        public abstract  Task Insert(T obj);

        public abstract Task<IEnumerable<T>> GetAll();

        public abstract Task Update( Employee employee , int id);

        public abstract Task Delete(int id);

        
        
    }
}
