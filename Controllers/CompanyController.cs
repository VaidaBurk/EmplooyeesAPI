using EmplooyeesAPI.Dtos;
using EmplooyeesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmplooyeesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _companyService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _companyService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyCreationDto company)
        {
            await _companyService.CreateAsync(company);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutCompany(CompanyEditDto company)
        {
            await _companyService.UpdateCompanyAsync(company);
            return NoContent();
        }
    }
}
