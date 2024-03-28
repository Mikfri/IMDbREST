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

        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieBaseDTO movieDTO)
        {
            try
            {
                await _movieService.AddMovie(movieDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchMovies(string searchString)
        {
            try
            {
                var movies = await _movieService.GetMovieListByTitle(searchString);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{tconst}")]
        public async Task<IActionResult> GetAllMovieInfo(string tconst)
        {
            try
            {
                var movie = await _movieService.GetAllMovieInfoByTconst(tconst);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(MovieBaseDTO movieDTO)
        {
            try
            {
                await _movieService.UpdateMovie(movieDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{tconst}")]
        public async Task<IActionResult> DeleteMovie(string tconst)
        {
            try
            {
                await _movieService.DeleteMovie(tconst);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
