using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityApi.Models.Form
{
    public class CityWithPointsOfInterestForCreation: CityForCreation
    {
        public ICollection<PointOfInterest> PointsOfInterest { get; set; }
              = new List<PointOfInterest>();
    }
}
