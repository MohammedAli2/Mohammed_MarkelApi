using Microsoft.EntityFrameworkCore;
using Mohammed_MarkelApi.Data;
using Mohammed_MarkelApi.Models;

namespace Mohammed_MarkelApi.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly MarkelDBContext _context;

        //initialise context
        public CompanyService(MarkelDBContext context)
        {
            this._context = context;
        }

        //query context and filter by id for first company item with id
        public async Task<CompanyModel?> GetCompanyAsync(int id)
        {
            return await _context.companys.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
