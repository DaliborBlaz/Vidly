using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly2.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.canManageMovies))
                return View("Index");
            else
                return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.MovieId == id);

            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        [Authorize(Roles=RoleName.canManageMovies)]
        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMoviewViewModel {
                Movie = new Movie(),
                Genres = genres
            };
            return View(viewModel);
        }

        [Authorize(Roles = RoleName.canManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMoviewViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("Create", viewModel);
            }
           
            if(movie.MovieId==0)
                _context.Movies.Add(movie);
            else
            {
                var movieinDb = _context.Movies.Single(x => x.MovieId == movie.MovieId);

                movieinDb.Name = movie.Name;
                movieinDb.ReleaseDate = movie.ReleaseDate;
                movieinDb.GenreId = movie.GenreId;
                movieinDb.NumberInStock = movie.NumberInStock;

            }

            _context.SaveChanges();
           
            return RedirectToAction("Index", "Movie");
        }

        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieId == id);
            if (movie == null)
                return HttpNotFound();
            
                var viewModel = new NewMoviewViewModel {
                    Movie = movie,
                    Genres=_context.Genres.ToList()
                };
            
            return View("Create",viewModel);
        }
        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>{
        //        new Movie{MovieId=1, Name="Shrek"},
        //        new Movie{MovieId=2, Name="Matrix"},
        //        new Movie{MovieId=3, Name="Walle"}
        //    };
        //}
    }
}