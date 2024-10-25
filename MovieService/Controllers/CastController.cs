using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourNamespace.Data;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public CastController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/cast
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cast>>> GetCasts()
        {
            return await _context.Casts.ToListAsync();
        }

        // GET: api/cast/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cast>> GetCastById(int id)
        {
            var cast = await _context.Casts.FindAsync(id);

            if (cast == null)
            {
                return NotFound();
            }

            return cast;
        }

        // POST: api/cast
        [HttpPost]
        public async Task<ActionResult<Cast>> CreateCast([FromBody] Cast cast)
        {
            if (cast == null)
            {
                return BadRequest("Invalid cast data.");
            }

            _context.Casts.Add(cast);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCastById), new { id = cast.Id }, cast);
        }

        // PUT: api/cast/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCast(int id, [FromBody] Cast cast)
        {
            if (id != cast.Id)
            {
                return BadRequest();
            }

            _context.Entry(cast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CastExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/cast/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCast(int id)
        {
            var cast = await _context.Casts.FindAsync(id);
            if (cast == null)
            {
                return NotFound();
            }

            _context.Casts.Remove(cast);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CastExists(int id)
        {
            return _context.Casts.Any(e => e.Id == id);
        }
    }
}
