using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLocation002.Data.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Display Category")]
        public int DisplayCategory { get; set; }
    }
}
