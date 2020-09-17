using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace BlazorServerApp.Pages
{
    public class EmployeeBase :  ComponentBase   
    {
        public IEnumerable<Employee> Employees { get; set; }

        public string NameReturned { get; set; }


        protected override Task OnInitializedAsync()
        {
          //  LoadEmployee();
            return base.OnInitializedAsync();   
        }

        public string GetEmployee(int id)
        {
            string emp = (from a in Employees
                          where a.ID == id
                          select a.FirstName).FirstOrDefault();
            NameReturned = emp;
            return emp;
        }



        private void LoadEmployee()
        {
            Employee employee1 = new Employee()
            {
                ID = 1,
                FirstName = "A",
                LastName = "Test",
                Gender = "aaaa@yahoo.com",
                //Departments = new Departments { DepartmentID = 1, DepartmentName = "Software" },
                //Gender = Gender.Male , 
                //PhotoPath = "Img/download.png"
            };

            Employee employee2 = new Employee()
            {
                ID = 1,
                FirstName = "B",
                LastName = "Test",
                Gender = "bbbbb@yahoo.com",
                //Departments = new Departments { DepartmentID = 2, DepartmentName = "HardWare" },
                //Gender = Gender.Female , 
                //PhotoPath = "Img/images.png"
            };

            Employee employee3 = new Employee()
            {
                ID = 1,
                FirstName = "C",
                LastName = "Test",
                Gender = "cccc@yahoo.com",
                //Departments = new Departments { DepartmentID = 1, DepartmentName = "Network" },
                //Gender = Gender.Male ,
                //PhotoPath = "Img/male.png"
            };


            Employees = new List<Employee> { employee1, employee2 , employee3 };
        }
    }
}
