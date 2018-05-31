using MyLocation002.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLocation002.ViewModel
{
    public class LocationsViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Location Locations { get; set; }
    }
}
