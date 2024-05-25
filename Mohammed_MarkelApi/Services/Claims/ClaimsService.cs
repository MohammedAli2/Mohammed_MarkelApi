using Microsoft.EntityFrameworkCore;
using Mohammed_MarkelApi.Data;
using Mohammed_MarkelApi.Models;

namespace Mohammed_MarkelApi.Services.Claims
{
    public class ClaimsService : IClaimsService
    {
        private readonly MarkelDBContext _context;

        //intialise contex
        public ClaimsService(MarkelDBContext context)
        {
            this._context = context;
        }

        //filter context for first claim with given unique reference identifier
        public async Task<ClaimModel?> GetClaimAsync(string ucr)
        {
            return await _context.claims.Where(i => i.UCR == ucr).FirstOrDefaultAsync();
        }

        //get list of claims from context fitlered by company id
        public async Task<IEnumerable<ClaimModel>> GetAllClaimsByCompanyAsync(int companyID)
        {
            return await _context.claims.Where(i => i.CompanyId == companyID).ToListAsync();
        }

        //assign new values and save change to context/db
        public async Task UpdateClaimAsync(string ucr, ClaimModel existingClaim, ClaimModel newClaim)
        {
            existingClaim.CompanyId = newClaim.CompanyId;
            existingClaim.ClaimDate = newClaim.ClaimDate;
            existingClaim.LossDate = newClaim.ClaimDate;
            existingClaim.AssuredName = newClaim.AssuredName;
            existingClaim.IncurredLoss = newClaim.IncurredLoss;
            existingClaim.Closed = newClaim.Closed;

            await _context.SaveChangesAsync();
        }
    }
}
