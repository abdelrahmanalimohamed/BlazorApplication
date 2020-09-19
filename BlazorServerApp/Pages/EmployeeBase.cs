using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using BlazorServerApp.Service;

namespace BlazorServerApp.Pages
{
    public class EmployeeBase :  ComponentBase   
    {
        [Inject]
        public IEmployee IEmployee { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public string NameReturned { get; set; }


        protected override  async Task OnInitializedAsync()
        {
            Employees = (await IEmployee.GetEmployees()).ToList();
        }

    }
}
