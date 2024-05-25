using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mohammed_MarkelApi.Models
{
    //To add table schema also
    //claims table from databse and its columns
    [Table("Claims")]
    public class ClaimModel
    {
        [Key]
        public string UCR { get; set; }

        public int CompanyId { get; set; }

        public DateTime ClaimDate { get; set; }

        public DateTime LossDate { get; set; }

        [Column("Assured Name")]
        public string AssuredName { get; set; }

        [Column("Incurred Loss")]
        public string IncurredLoss { get; set; }

        public bool Closed { get; set; }

        //new property for api - gets number of days since last claim
        [NotMapped]
        public int ClaimAgeInDays { get { return (DateTime.Now - ClaimDate).Days; } }

    }
}
