using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Models;
using Vidly2.DTOs;
using System.Data.Entity;

namespace Vidly2.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

       
        public IHttpActionResult GetMoviews()
        {
            var moviesDTO = _context.Movies
                .Include(x=>x.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>);

            return Ok(moviesDTO);
        }

        [Authorize(Roles = RoleName.canManageMovies)]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieId == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.canManageMovies)]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.MovieId = movie.MovieId;

            return Created(new Uri(Request.RequestUri + "/" + movie.MovieId), movieDTO);
        }

        [Authorize(Roles = RoleName.canManageMovies)]
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieinDb = _context.Movies.SingleOrDefault(x => x.MovieId == id);
            if (movieinDb == null)
                return NotFound();

            Mapper.Map(movieDTO, movieinDb);
            _context.SaveChanges();

            return Ok();

        }
        [Authorize(Roles = RoleName.canManageMovies)]
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieinDb = _context.Movies.SingleOrDefault(x => x.MovieId == id);
            if (movieinDb == null)
                return NotFound();

            _context.Movies.Remove(movieinDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
