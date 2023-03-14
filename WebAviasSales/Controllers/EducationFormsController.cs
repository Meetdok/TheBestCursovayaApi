using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAviasSales;
using WebAviasSales.DB;

namespace WebTheBestCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationFormsController : ControllerBase
    {
        private readonly user05Context _context;

        public EducationFormsController(user05Context context)
        {
            _context = context;
        }

        // GET: api/EducationForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationForm>>> GetEducationForms()
        {
            return await _context.EducationForms.ToListAsync();
        }

        // GET: api/EducationForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationForm>> GetEducationForm(int id)
        {
            var educationForm = await _context.EducationForms.FindAsync(id);

            if (educationForm == null)
            {
                return NotFound();
            }

            return educationForm;
        }

        // PUT: api/EducationForms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationForm(int id, EducationForm educationForm)
        {
            if (id != educationForm.EducationFormId)
            {
                return BadRequest();
            }

            _context.Entry(educationForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationFormExists(id))
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

        // POST: api/EducationForms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EducationForm>> PostEducationForm(EducationForm educationForm)
        {
            _context.EducationForms.Add(educationForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationForm", new { id = educationForm.EducationFormId }, educationForm);
        }

        // DELETE: api/EducationForms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducationForm(int id)
        {
            var educationForm = await _context.EducationForms.FindAsync(id);
            if (educationForm == null)
            {
                return NotFound();
            }

            _context.EducationForms.Remove(educationForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EducationFormExists(int id)
        {
            return _context.EducationForms.Any(e => e.EducationFormId == id);
        }
    }
}
