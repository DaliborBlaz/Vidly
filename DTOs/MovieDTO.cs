using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.DTOs
{
    public class MovieDTO
    {
        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }
        public GenreDTO Genre { get; set; }

        public DateTime? DateAdded { get; set; }
        public DateTime? ReleaseDate { get; set; }

       
        [Range(1, 20)]
        public int NumberInStock { get; set; }


        

      
        
    }
}