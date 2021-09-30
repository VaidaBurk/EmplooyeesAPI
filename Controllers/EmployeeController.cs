using EmplooyeesAPI.Dtos;
using EmplooyeesAPI.Entities;
using EmplooyeesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmplooyeesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _employeeService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreationDto employee)
        {
            await _employeeService.CreateAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutEmployee(Employee employee)
        {
            await _employeeService.UpdateAsync(employee);
            return NoContent();
        }
    }
}
