using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies.Models;

namespace movies.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CinemadbContext _context;

        public MoviesController(CinemadbContext context)
        {
            _context = context;
        }

        [HttpGet("feladat10")]
        public async Task<ActionResult<Movie>> Get()
        {
            var movie = await _context.Movies.ToListAsync();

            if (movie != null)
            {
                return Ok(movie);
            }
            Exception e = new();
            return BadRequest(new { message = e.Message });
        }

        [HttpPost("feladat13")]
        public async Task<ActionResult> Post(string id, Movie movie)
        {            
            var builder = WebApplication.CreateBuilder();

            string uid = builder.Configuration.GetValue<string>("Code");

            if (uid == id && uid != null)
            {
                var mov = new Movie
                {
                    Title = movie.Title,
                    ReleaseDate = movie.ReleaseDate,
                    ActorId = movie.ActorId,
                    FilmTypeId = movie.FilmTypeId,                   
                };

                if (movie != null)
                {
                    await _context.Movies.AddAsync(mov);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, "Film hozzáadása sikeresen megtörtént.");
                }
                return BadRequest();
            }
            return StatusCode(400, "Nincs jogosultsága új film felvételéhez.");

        }

    }
}
