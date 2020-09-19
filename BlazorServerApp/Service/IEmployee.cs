using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Service
{
    public interface IEmployee
    {
       Task<IEnumerable<Employee>> GetEmployees();

        

    }
}
