using Microsoft.AspNetCore.Mvc;
using Mohammed_MarkelApi.Data;
using Mohammed_MarkelApi.Models;
using Mohammed_MarkelApi.Services.Claims;

namespace Mohammed_MarkelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly MarkelDBContext _context;
        private readonly IClaimsService _claimsServices;

        //initialise context and service
        public ClaimsController(MarkelDBContext context, IClaimsService claimsServices)
        {
            this._context = context;
            this._claimsServices = claimsServices;
        }

        // get claim by company id - e.g. /api/Claims/ucr?ucr=1
        [HttpGet("ucr")]
        public async Task<ActionResult> GetClaim(string ucr)
        {
            var claim = await _claimsServices.GetClaimAsync(ucr);
            if (claim == null) { return NotFound(); }

            return Ok(claim);
        }

        //get list of claiims by company id - e.g. /api/Claims/companyId?companyID=101
        [HttpGet("companyId")]
        public async Task<ActionResult<IEnumerable<ClaimModel>>> GetCompanyClaims(int companyID)
        {
            var claims = await _claimsServices.GetAllClaimsByCompanyAsync(companyID);
            if (claims == null) { return NotFound(); }

            return Ok(claims);
        }

        //update claim from given claim model and claim reference
        //e.g. /api/Claims?ucr=1
        /*
         * request body
         {
          "ucr": "string",
          "companyId": 0,
          "claimDate": "2024-05-25T13:35:43.471Z",
          "lossDate": "2024-05-25T13:35:43.471Z",
          "assuredName": "string",
          "incurredLoss": "string",
          "closed": true
        }
         */
        [HttpPut]
        public async Task<ActionResult> UpdateClaim(string ucr, ClaimModel newClaim)
        {
            var existingClaim = await _claimsServices.GetClaimAsync(ucr);
            if (existingClaim == null) { return NotFound(); }

            await _claimsServices.UpdateClaimAsync(ucr, existingClaim, newClaim);
            return NoContent();
        }
    }
}
