using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectBackendAPI.Models;
using ProjectBackendAPI;


namespace ProjectBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ServicePortalContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsersController(ServicePortalContext context, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserss()
        {
            return await _context.Userss.ToListAsync();
        }

        // GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(int id)
        //{
        //    var user = await _context.Userss.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}

        // GET: api/Users/5
        //[HttpGet("{id}")]
        //public IEnumerable<Ticket> GetUserTickets([FromRoute] int id)
        //{
        //    var TicketDetail = _context.Tickets.Where(x => x.UserId == id);
        //    return TicketDetail;
        //}

        [HttpGet("specific/{userId}")]
        public IEnumerable<Models.Ticket> GetUserTickets([FromRoute] int userId)

        {
            return _context.Tickets.Where(q => q.UserId == userId);
        }



        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Userss.Add(user);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUser", new { id = user.UserId }, user);
            return Ok();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Userss.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Userss.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> ToLogin(Login model)
        {
            var userFromDb = await _context.Userss.FirstOrDefaultAsync(x => x.UserName == model.UserName);
            if(userFromDb == null)
            {
                return BadRequest();
            }
            if(!((userFromDb.UserName == model.UserName)&&(userFromDb.Password == model.Password)))
            {
                return BadRequest();
            }
            return Ok(new
            {
                userId = userFromDb.UserId,
                userName = userFromDb.UserName
            });
        }

        private bool UserExists(int id)
        {
            return _context.Userss.Any(e => e.UserId == id);
        }
    }
}
