using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeWebApi.RepositoryPatern;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly AbstractRepository<Employee> _employeeRepository;

        public EmployeeController(AbstractRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeRepository.GetAll();
            return new OkObjectResult(result);
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> PostEmployee([FromBody] Employee employee)
        {
            await _employeeRepository.Insert(employee);

            return new JsonResult("Ok");
        }


        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            await _employeeRepository.Update(employee ,id);

            return new JsonResult("Updated");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.Delete(id);

            return new JsonResult("Deleted");
        }


    }
}
