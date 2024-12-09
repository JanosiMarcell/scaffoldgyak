using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movies.Models;
using System.Security.Cryptography.X509Certificates;

namespace movies.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly CinemadbContext _context;

        public ActorsController(CinemadbContext context)
        {
            _context = context;
        }

        [HttpGet("feladat9")]
        public async Task<ActionResult<Actor>> Get(string name)
        {
            var actor = await _context.Actors.Include(act => act.Movies)
                .FirstOrDefaultAsync(act => act.ActorName == name);
            
            if (actor != null)
            {
                return Ok(actor);
            }
            
            return NotFound();
        }

        [HttpGet("feladat12")]
        public async Task<ActionResult<Actor>> GetNumOfAct()
        {
           var actor = await _context.Actors.CountAsync();

            if (actor != 0 && actor != null)
            {
                return Ok($"Színészek száma: "+actor);
            }
            return BadRequest("Nem lehet csatlakozni az adatbázishoz!");
        }




        
    }
}
