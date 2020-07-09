using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? DateAdded { get; set; }

        [Display(Name="Release Date")]
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1,20, ErrorMessage = "Number in Stock must be between 1 and 20")]
        public int NumberInStock { get; set; }

      
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        public int NumberAvailable { get; set; }

    }
}