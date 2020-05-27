using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityApi.Models
{
    [Table("PointOfInterest")]
    public class PointOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PointOfInterestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //[ForeignKey("CityId")]
        public int CityId { get; set; }
        //public City City { get; set; }
    }
}