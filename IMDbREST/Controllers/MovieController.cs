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
    }
}
