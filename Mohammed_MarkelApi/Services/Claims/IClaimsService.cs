using Mohammed_MarkelApi.Models;

namespace Mohammed_MarkelApi.Services.Claims
{
    public interface IClaimsService
    {
        Task<ClaimModel?> GetClaimAsync(string ucr);
        Task<IEnumerable<ClaimModel>> GetAllClaimsByCompanyAsync(int companyID);
        Task UpdateClaimAsync(string ucr, ClaimModel existingClaim, ClaimModel newClaim);
    }
}
