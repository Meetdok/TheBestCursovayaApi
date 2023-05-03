using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAviasSales;
using WebAviasSales.Controllers;
using WebTheBestCursach.DB;
using WebTheBestCursach.Models;

namespace WebTheBestCursach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginPagesController : ControllerBase
    {
        private readonly user05Context _context;

        public LoginPagesController(user05Context context)
        {
            _context = context;
        }


        [HttpPost("Auth")]
        public async Task<LoginPage> AuthUser(Auth auth)
        {
            var login = await _context.LoginPages.Include(s=>s.Users).FirstOrDefaultAsync(s => s.Login == auth.Login && s.Password == auth.Password );

            return login ?? new LoginPage();
        }

      

        // GET: api/LoginPages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginPage>>> GetLoginPages()
        {
            return await _context.LoginPages.ToListAsync();
        }

        // GET: api/LoginPages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginPage>> GetLoginPage(int id)
        {
            var loginPage = await _context.LoginPages.FindAsync(id);

            if (loginPage == null)
            {
                return NotFound();
            }

            return loginPage;
        }

        // PUT: api/LoginPages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginPage(int id, LoginPage loginPage)
        {
            if (id != loginPage.Id)
            {
                return BadRequest();
            }

            _context.Entry(loginPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginPageExists(id))
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

        // POST: api/LoginPages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("SaveLogin")]
        public async Task<ActionResult<LoginPage>> PostLoginPage(LoginPage loginPage)
        {
            _context.LoginPages.Add(loginPage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginPage", new { id = loginPage.Id }, loginPage);
        }
      

        // DELETE: api/LoginPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginPage(int id)
        {
            var loginPage = await _context.LoginPages.FindAsync(id);
            if (loginPage == null)
            {
                return NotFound();
            }

            _context.LoginPages.Remove(loginPage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginPageExists(int id)
        {
            return _context.LoginPages.Any(e => e.Id == id);
        }
    }
}
