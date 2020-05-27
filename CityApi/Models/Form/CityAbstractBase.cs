using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityApi.Models.Form
{
    public abstract class CityAbstractBase
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCapital { get; set; }
    }
}
