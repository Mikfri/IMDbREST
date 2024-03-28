using IMDbLib.DTOs;
using IMDbLib.Models;
using IMDbLib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDbREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<MovieBase> GetMovies([FromQuery] string title)
        {
            return _movieService.SearchMovies(title);
        }

        //[HttpGet("{tconst}")]
        //public IActionResult GetMovieDetails(string tconst)
        //{
        //    var movie = _movieService.GetMovieDetails(tconst);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(movie);
        //}

        [HttpGet("{tconst}")]
        public ActionResult<MovieBase> GetMovieDetails(string tconst)
        {
            var movie = _movieService.GetMovieDetails(tconst);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        // todo: Afprøv
        [HttpPost]
        public IActionResult AddMovie(MovieBaseDTO movieDto)
        {
            var movie = new MovieBase
            {
                TitleType = new TitleType { Type = movieDto.TitleType }, // assuming TitleType has a Type property of type string
                PrimaryTitle = movieDto.PrimaryTitle,
                IsAdult = movieDto.IsAdult,
                StartYear = movieDto.StartYear,
                EndYear = movieDto.EndYear,
                RuntimeMins = movieDto.RuntimeMins
            };

            _movieService.AddMovie(movie);
            return Ok();
        }
        //[HttpPost]
        //public IActionResult AddMovie(MovieBase movie)
        //{
        //    _movieService.AddMovie(movie);
        //    return Ok();
        //}

        // todo: Afprøv
        [HttpPut]
        public ActionResult<MovieBase> UpdateMovie(MovieBase movie)
        {
            var updatedMovie = _movieService.UpdateMovie(movie);
            if (updatedMovie == null)
            {
                return NotFound();
            }
            return updatedMovie;
        }

        // todo: Afprøv
        [HttpDelete]
        public IActionResult DeleteMovie(MovieBase movie)
        {
            _movieService.DeleteMovie(movie);
            return Ok();
        }
    }
}
