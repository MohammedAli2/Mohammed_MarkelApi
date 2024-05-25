using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mohammed_MarkelApi.Models
{
    //To add table schema also
    //Company table from databse and its columns
    [Table("Company")]
    public class CompanyModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set;  }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public bool Active { get; set; }
        public DateTime InsuranceEndDate { get; set; }

        //addition property for api call - checks if insurance policy is active (if active flag is true and insurance end date is in the future)
        [NotMapped]
        public bool ActiveInsurancePolicy { get { return (Active && InsuranceEndDate >= DateTime.Now) ? true : false; } }
    }
}
