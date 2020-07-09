using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.DTOs;
using Vidly2.Models;

namespace Vidly2.Controllers.API
{
    

    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTO newRental)
        {
          

            var customer = _context.Customers.Single(x => x.CustomerId == newRental.CustomerID);

            

            var movies = _context.Movies.Where(x => newRental.MovieIds.Contains(x.MovieId)).ToList();

            

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customers = customer,
                    Movies = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);

            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
