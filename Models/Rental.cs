using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Rental
    {
        public int RentalId { get; set; }

        public DateTime DateReturned { get; set; }
        public DateTime DateRented { get; set; }

        [Required]
        public Movie Movies { get; set; }

        [Required]
        public Customer Customers { get; set; }

    }
}