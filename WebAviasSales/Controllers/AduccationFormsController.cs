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
    public class AduccationFormsController : ControllerBase
    {
        private readonly user05Context _context;
        private int input;

        public AduccationFormsController(user05Context context)
        {
            _context = context;
        }

        // GET: api/AduccationForms
        [HttpPost("list")]
        public async Task<ActionResult<IEnumerable<AduccationForm>>> GetAduccationForms()
        {
            return await _context.AduccationForms.Include(s=>s.Documents).Include(s=>s.Speciality).ToListAsync();
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
        [HttpPost("put")]
        public async Task<IActionResult> PutAduccationForm([FromBody] AduccationForm aduccationForm)
        {

            input = aduccationForm.DefaultListId;

            var origin = _context.AduccationForms.Find(input);

            _context.Entry(origin).CurrentValues.SetValues(aduccationForm);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AduccationFormExists(input))
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
        [HttpPost("save")]
        public async Task<ActionResult<AduccationForm>> PostAduccationForm(AduccationForm aduccationForm)
        {
            _context.AduccationForms.Add(aduccationForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAduccationForm", new { id = aduccationForm.DefaultListId }, aduccationForm);
        }

        // DELETE: api/AduccationForms/5
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAduccationForm([FromBody]int id)
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
