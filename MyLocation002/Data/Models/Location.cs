using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLocation002.Data.Models
{
    public class Location
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Must be valid Coordinates 0")]
        public double? Latitude { get; set; }

        [Required(ErrorMessage = "Must be valid Coordinates 0")]
        public double? Longitude { get; set; }

        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
