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
    public class AduccationFormsController : ControllerBase
    {
        private readonly user05Context _context;

        public AduccationFormsController(user05Context context)
        {
            _context = context;
        }

        // GET: api/AduccationForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AduccationForm>>> GetAduccationForms()
        {
            return await _context.AduccationForms.ToListAsync();
        }

        // GET: api/AduccationForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AduccationForm>> GetAduccationForm(int id)
        {
            var aduccationForm = await _context.AduccationForms.FindAsync(id);

            if (aduccationForm == null)
            {
                return NotFound();
            }

            return aduccationForm;
        }

        // PUT: api/AduccationForms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAduccationForm(int id, AduccationForm aduccationForm)
        {
            if (id != aduccationForm.DefaultListId)
            {
                return BadRequest();
            }

            _context.Entry(aduccationForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AduccationFormExists(id))
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

        // POST: api/AduccationForms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AduccationForm>> PostAduccationForm(AduccationForm aduccationForm)
        {
            _context.AduccationForms.Add(aduccationForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAduccationForm", new { id = aduccationForm.DefaultListId }, aduccationForm);
        }

        // DELETE: api/AduccationForms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAduccationForm(int id)
        {
            var aduccationForm = await _context.AduccationForms.FindAsync(id);
            if (aduccationForm == null)
            {
                return NotFound();
            }

            _context.AduccationForms.Remove(aduccationForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AduccationFormExists(int id)
        {
            return _context.AduccationForms.Any(e => e.DefaultListId == id);
        }
    }
}
