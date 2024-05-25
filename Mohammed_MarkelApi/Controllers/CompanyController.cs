using Microsoft.AspNetCore.Mvc;
using Mohammed_MarkelApi.Data;
using Mohammed_MarkelApi.Services.Company;

namespace Mohammed_MarkelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly MarkelDBContext _context;
        private readonly ICompanyService _companyService;

        //intialise context and services
        public CompanyController(MarkelDBContext context, ICompanyService companyService)
        {
            this._context = context;
            this._companyService = companyService;
        }

        //get company by id api call - e.g. api/Company/Id?id=101
        [HttpGet("Id")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _companyService.GetCompanyAsync(id);
            if (company == null) { return NotFound(); }

            return Ok(company);
        }
    }
}
