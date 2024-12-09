using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies.Models;

namespace movies.Controllers
{
    [Route("api/filmtypes")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly CinemadbContext _context;

        public TypeController(CinemadbContext context) 
        {        
            _context = context;
        }

        [HttpGet("feladat11")]
        public async Task<ActionResult<FilmType>> Get()
        {
            var type = await _context.FilmTypes.Include(type => type.Movies).ToListAsync();

            if (type != null)
            {
                return Ok(type);
            }
            return BadRequest();
        }
    }
}
