using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAviasSales;
using WebTheBestCursach.DB;
using WebTheBestCursach.Models;

namespace WebTheBestCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumetsController : ControllerBase
    {
        private readonly user05Context _context;
        private int input;

        public DocumetsController(user05Context context)
        {
            _context = context;
        }

        // GET: api/Documets
        [HttpPost("list")]
        public async Task<ActionResult<IEnumerable<Documet>>> GetDocumets()
        {
            return await _context.Documets.ToListAsync();
        }

        


        // GET: api/Documets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Documet>> GetDocumet(int id)
        {
            var documet = await _context.Documets.FindAsync(id);

            if (documet == null)
            {
                return NotFound();
            }

            return documet;
        }

        // PUT: api/Documets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("put")]
        public async Task<IActionResult> PutDocument([FromBody] Documet documet)
        {
            input = documet.DocumetId;

            var origin = _context.Documets.Find(input);

            _context.Entry(origin).CurrentValues.SetValues(documet);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumetExists(input))
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

        // POST: api/Documets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("save")]
        public async Task<ActionResult<Documet>> PostDocumet(Documet documet)
        {
            _context.Documets.Add(documet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumet", new { id = documet.DocumetId }, documet);
        }

        // DELETE: api/Documets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumet(int id)
        {
            var documet = await _context.Documets.FindAsync(id);
            if (documet == null)
            {
                return NotFound();
            }

            _context.Documets.Remove(documet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumetExists(int id)
        {
            return _context.Documets.Any(e => e.DocumetId == id);
        }
    }
}
