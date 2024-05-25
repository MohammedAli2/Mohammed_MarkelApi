using Microsoft.EntityFrameworkCore;
using Mohammed_MarkelApi.Data;
using Mohammed_MarkelApi.Models;

namespace MarkelApi_UnitTests.TestData
{
    //setup for in memory database for testing 
    public static class TestDBContext
    {
        //create context with in memory data needed for testing - initalize db consitantly across tests
        public static MarkelDBContext SetupDBContextForTesting() 
        {
            var dbContextOptions = new DbContextOptionsBuilder<MarkelDBContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()) //so it uses new in memory db each test
                    .Options;

            var context = new MarkelDBContext(dbContextOptions);

            //add test data
            PopulateWithTestData(context);

            return context;
        }

        private static void PopulateWithTestData(MarkelDBContext context)
        {
            context.claims.AddRange(
                new ClaimModel { UCR = "1", CompanyId = 101, ClaimDate = new DateTime(2021, 1, 1), LossDate = new DateTime(2021, 2, 2), AssuredName = "Andy Test", IncurredLoss = "£1001", Closed = true },
                new ClaimModel { UCR = "2", CompanyId = 102, ClaimDate = new DateTime(2022, 1, 1), LossDate = new DateTime(2022, 2, 2), AssuredName = "Bob Test", IncurredLoss = "£2002", Closed = true },
                new ClaimModel { UCR = "3", CompanyId = 103, ClaimDate = new DateTime(2023, 1, 1), LossDate = new DateTime(2023, 2, 2), AssuredName = "Charlie Test", IncurredLoss = "£3003", Closed = true },
                new ClaimModel { UCR = "4", CompanyId = 101, ClaimDate = new DateTime(2024, 5, 20), LossDate = new DateTime(2024, 5, 20), AssuredName = "Dan Test", IncurredLoss = "£1002", Closed = false }
             );

            context.companys.AddRange(
                new CompanyModel { Id = 101, Name = "A TestCompany", Address1 = "11 Bond Street", Address2 = "Leeds", Address3 = "West Yorkshire", PostCode = "LS1 ABC", Country = "United Kingdom", Active = true, InsuranceEndDate = new DateTime(2025, 1, 2) },
                new CompanyModel { Id = 102, Name = "B TestCompany", Address1 = "22 Baker Street", Address2 = "Sheffield", Address3 = "South Yorkshire", PostCode = "S5 ABC", Country = "United Kingdom", Active = false, InsuranceEndDate = new DateTime(2023, 2, 2) },
                new CompanyModel { Id = 103, Name = "C TestCompany", Address1 = "33 Oxford Street", Address2 = "Leeds", Address3 = "West Yorkshire", PostCode = "LS2 CDE", Country = "United Kingdom", Active = false, InsuranceEndDate = new DateTime(2023, 3, 3) }
             );

            context.SaveChanges();
        }
    }
}
