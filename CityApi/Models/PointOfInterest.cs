using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityApi.Models
{
    public class PointOfInterest
    {
        [Key]
        public int PointsOfInterestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }
    }
}