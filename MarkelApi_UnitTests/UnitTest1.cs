using MarkelApi_UnitTests.TestData;
using Mohammed_MarkelApi.Data;
using Mohammed_MarkelApi.Models;
using Mohammed_MarkelApi.Services.Claims;
using Mohammed_MarkelApi.Services.Company;

namespace MarkelApi_UnitTests
{
    public class Tests : IDisposable
    {
        private MarkelDBContext _context;
        private CompanyService _companyService;
        private ClaimsService _claimService;

        //Some Test Variables -- arrange
        private const int companyID1 = 101;
        private const int companyID2 = 102;
        private const string claimUCR1 = "4";

        [SetUp]
        public void Setup()
        {
            _context = TestDBContext.SetupDBContextForTesting();
            _companyService = new CompanyService(_context);
            _claimService = new ClaimsService(_context);
        }

        //_____________company tests:_______________________________
        [Test]
        public async Task GetCompanyAsync_NotNullCompany()
        {
            //act
            var company = await _companyService.GetCompanyAsync(companyID1);

            //assert
            Assert.NotNull(company);
            Assert.AreEqual(companyID1, company.Id);
        }

        [Test]
        public async Task GetCompanyAsync_ActiveInusrancePolicyTrue()
        {
            //act
            var company = await _companyService.GetCompanyAsync(companyID1);

            //assert
            Assert.NotNull(company);
            Assert.AreEqual(true, company.ActiveInsurancePolicy);
        }

        [Test]
        public async Task GetCompanyAsync_ActiveInusrancePolicyFalse()
        {
            //act
            var company = await _companyService.GetCompanyAsync(companyID2);

            //assert
            Assert.NotNull(company);
            Assert.AreEqual(false, company.ActiveInsurancePolicy);
        }

        //________________claim tests___________________________
        [Test]
        public async Task GetAllClaimsByCompanyAsync_ClaimsCount2()
        {
            //act
            var claims = await _claimService.GetAllClaimsByCompanyAsync(companyID1);

            //assert
            Assert.NotNull(claims);
            Assert.AreEqual(2, claims.Count());
        }

        [Test]
        public async Task GetClaimAsync_Details_And_ClaimAge()
        {
            //act
            var claims = await _claimService.GetClaimAsync(claimUCR1);

            //assert
            Assert.NotNull(claims);
            Assert.AreEqual(claimUCR1, claims.UCR);
            var expectedClaimAge = (DateTime.Now - claims.ClaimDate).Days;
            Assert.AreEqual(expectedClaimAge, claims.ClaimAgeInDays);
        }

        [Test]
        public async Task UpdateClaimAsync_Updated()
        {
            //arrange
            var claim = await _claimService.GetClaimAsync(claimUCR1);

            var updatedClaim = new ClaimModel
            {
                UCR = claimUCR1,
                CompanyId = companyID1,
                ClaimDate = new DateTime(2024, 5, 20),
                LossDate = new DateTime(2024, 5, 20),
                AssuredName = "CHANGE1",
                IncurredLoss = "CHANGE2",
                Closed = false
            };

            //act
            if (claim != null)
            {
                await _claimService.UpdateClaimAsync(claimUCR1, claim, updatedClaim);
            }

            //assert
            Assert.NotNull(claim);

            Assert.AreEqual(updatedClaim.AssuredName, claim.AssuredName);
            Assert.AreEqual(updatedClaim.IncurredLoss, claim.IncurredLoss);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}