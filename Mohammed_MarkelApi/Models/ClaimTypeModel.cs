using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mohammed_MarkelApi.Models
{
    //To add table schema also
    //ClaimType table from databse and its columns
    [Table("ClaimType")]
    public class ClaimTypeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
