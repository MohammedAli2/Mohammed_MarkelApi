using Mohammed_MarkelApi.Models;

namespace Mohammed_MarkelApi.Services.Company
{
    public interface ICompanyService
    {
        Task<CompanyModel?> GetCompanyAsync(int id);
    }
}
