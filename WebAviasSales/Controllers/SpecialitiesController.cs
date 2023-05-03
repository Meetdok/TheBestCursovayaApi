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

namespace WebAviasSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialitiesController : ControllerBase
    {
        private readonly user05Context _context;
        private int input;

        public SpecialitiesController(user05Context context)
        {
            _context = context;
        }

        // GET: api/Specialities
        [HttpPost("list")]
        public async Task<ActionResult<IEnumerable<Speciality>>> GetSpecialities()
        {
            return await _context.Specialities.ToListAsync();
        }

        // GET: api/Specialities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Speciality>> GetSpeciality(int id)
        {
            var speciality = await _context.Specialities.FindAsync(id);

            if (speciality == null)
            {
                return NotFound();
            }

            return speciality;
        }

        // PUT: api/Specialities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("put")]
        public async Task<IActionResult> PutSpecialities([FromBody] Speciality speciality)
        {
            input = speciality.SpecialityId;

            var origin = _context.Specialities.Find(input);

            _context.Entry(origin).CurrentValues.SetValues(speciality);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialityExists(input))
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



        // POST: api/Specialities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("save")]
        public async Task<ActionResult<Speciality>> PostSpeciality(Speciality speciality)
        {
            _context.Specialities.Add(speciality);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpeciality", new { id = speciality.SpecialityId }, speciality);
        }

        // DELETE: api/Specialities/5
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteSpeciality([FromBody]int id)
        {
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null)
            {
                return NotFound();
            }

            _context.Specialities.Remove(speciality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecialityExists(int id)
        {
            return _context.Specialities.Any(e => e.SpecialityId == id);
        }
    }
}
