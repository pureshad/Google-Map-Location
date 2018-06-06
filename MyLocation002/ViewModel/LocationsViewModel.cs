using MyLocation002.Data.Models;
using System.Collections.Generic;

namespace MyLocation002.ViewModel
{
    public class LocationsViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Location Locations { get; set; }
    }
}
