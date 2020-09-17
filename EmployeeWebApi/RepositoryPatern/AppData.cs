using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApi.RepositoryPatern
{
    public class AppData : IDisposable
    {
        public SqlConnection Connection { get; }

        public AppData(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
