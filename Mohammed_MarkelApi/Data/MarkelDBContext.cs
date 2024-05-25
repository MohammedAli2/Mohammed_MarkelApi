using Microsoft.EntityFrameworkCore;
using Mohammed_MarkelApi.Models;

namespace Mohammed_MarkelApi.Data
{
    public class MarkelDBContext : DbContext
    {
        //configure dbcontext
        public MarkelDBContext(DbContextOptions<MarkelDBContext> options) : base(options)
        {
                
        }

        //tables from database - get data and set property values when loading
        public DbSet<ClaimModel> claims { get; set; }
        public DbSet<ClaimTypeModel> claimTypes { get; set; }
        public DbSet<CompanyModel> companys { get; set; }

        //configure model usnig builder - called when model for context created
        //overriding dbcontext base class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //applies and base class configuration
            
            //adding data to db entities
            modelBuilder.Entity<ClaimModel>().HasData(
                new ClaimModel { UCR = "1", CompanyId = 101, ClaimDate = new DateTime(2021, 1, 1), LossDate = new DateTime(2021, 2, 2), AssuredName = "Andy Andyson", IncurredLoss = "£1001", Closed = true },
                new ClaimModel { UCR = "2", CompanyId = 102, ClaimDate = new DateTime(2022, 1, 1), LossDate = new DateTime(2022, 2, 2), AssuredName = "Bob Bobson", IncurredLoss = "£2002", Closed = true },
                new ClaimModel { UCR = "3", CompanyId = 103, ClaimDate = new DateTime(2023, 1, 1), LossDate = new DateTime(2023, 2, 2), AssuredName = "Charlie Charlson", IncurredLoss = "£3003", Closed = true },
                new ClaimModel { UCR = "4", CompanyId = 101, ClaimDate = new DateTime(2024, 5, 20), LossDate = new DateTime(2024, 5, 20), AssuredName = "Dan Danson", IncurredLoss = "£1002", Closed = false }
            );

            modelBuilder.Entity<ClaimTypeModel>().HasData(
                new ClaimTypeModel { Id = 10, Name = "Fire" },
                new ClaimTypeModel { Id = 20, Name = "Theft" },
                new ClaimTypeModel { Id = 30, Name = "Injury" }
            );

            modelBuilder.Entity<CompanyModel>().HasData(
                new CompanyModel { Id = 101, Name = "A Company", Address1 = "11 Bond Street", Address2 = "Leeds", Address3 = "West Yorkshire", PostCode = "LS1 ABC", Country = "United Kingdom", Active = true, InsuranceEndDate = new DateTime(2025, 1, 2) },
                new CompanyModel { Id = 102, Name = "B Company", Address1 = "22 Baker Street", Address2 = "Sheffield", Address3 = "South Yorkshire", PostCode = "S5 ABC", Country = "United Kingdom", Active = false, InsuranceEndDate = new DateTime(2023, 2, 2) },
                new CompanyModel { Id = 103, Name = "C Company", Address1 = "33 Oxford Street", Address2 = "Leeds", Address3 = "West Yorkshire", PostCode = "LS2 CDE", Country = "United Kingdom", Active = false, InsuranceEndDate = new DateTime(2023, 3, 3) }
            );
        }
    }
}
