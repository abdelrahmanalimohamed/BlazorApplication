using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApi.RepositoryPatern
{
    public class EmployeeRepository : AbstractRepository<Employee>
    {
        public EmployeeRepository()
        {

        }
        protected override string TableName 
        {
            get
            {
                return "Employee";
            }
        }

        

        public override async Task<IEnumerable<Employee>> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            var query = $"SELECT E.FirstName , e.LastName , e.Gender , d.Name FROM {TableName} e  JOIN Department d ON e.ID = d.ID";
            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);

            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            DataTable dataTable = new DataTable();

            dataTable.Load(sqlDataReader);

            employees = (from DataRow dr in dataTable.Rows
                           select new Employee()
                           {
                               FirstName = dr["FirstName"].ToString(),
                               LastName = dr["LastName"].ToString(),
                               Gender = dr["Gender"].ToString(),
                               Dept_Name = dr["Name"].ToString()
                           }).ToList();

            return employees ;


        }

        public override async Task Insert(Employee obj)
        {
            var query = $"insert into {TableName} (FirstName, LastName, Gender, Dept_id) values ('" + obj.FirstName + "' , '" + obj.LastName + "' , '" + obj.Gender + "' , '" + obj.Dept_id + "')";

            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);

            await sqlCommand.ExecuteNonQueryAsync();
        }

        public override async Task Update(Employee employee , int id)
        {

            var query = $"update {TableName} set FirstName = '"+employee.FirstName+"', LastName = '"+employee.LastName+"' , Gender = '"+employee.Gender+"', Dept_id = " +employee.Dept_id+ " where id = " +id+ " ";

            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);

            await sqlCommand.ExecuteNonQueryAsync();
        }


        public override async Task Delete(int id)
        {
            var query = $"delete from {TableName} where id = " + id + " ";

            SqlCommand sqlCommand = new SqlCommand(query, SqlConnection);

            await sqlCommand.ExecuteNonQueryAsync();
        }
    }
}
