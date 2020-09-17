using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Models
{
   public class Employee
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Dept_Name { get; set; }

        public int Dept_id { get; set; }


        //public Departments Departments { get; set; }

        //public Gender Gender { get; set; }

       // public string PhotoPath { get; set; }
    }
}
