using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;

namespace dotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionController : ControllerBase
    {
        private readonly APIDbContext _context;

        public UserPermissionController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/UserPermission
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPermission>>> GetUserPermission()
        {
          if (_context.UserPermission == null)
          {
              return NotFound();
          }
            return await _context.UserPermission.ToListAsync();
        }

        // GET: api/UserPermission/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPermission>> GetUserPermission(int id)
        {
          if (_context.UserPermission == null)
          {
              return NotFound();
          }
            var userPermission = await _context.UserPermission.FindAsync(id);

            if (userPermission == null)
            {
                return NotFound();
            }

            return userPermission;
        }

        // PUT: api/UserPermission/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPermission(int id, UserPermission userPermission)
        {
            if (id != userPermission.Id)
            {
                return BadRequest();
            }

            _context.Entry(userPermission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPermissionExists(id))
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

        // POST: api/UserPermission
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPermission>> PostUserPermission(UserPermission userPermission)
        {
          if (_context.UserPermission == null)
          {
              return Problem("Entity set 'UserServiceContext.UserPermission'  is null.");
          }
            _context.UserPermission.Add(userPermission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPermission", new { id = userPermission.Id }, userPermission);
        }

        // DELETE: api/UserPermission/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPermission(int id)
        {
            if (_context.UserPermission == null)
            {
                return NotFound();
            }
            var userPermission = await _context.UserPermission.FindAsync(id);
            if (userPermission == null)
            {
                return NotFound();
            }

            _context.UserPermission.Remove(userPermission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPermissionExists(int id)
        {
            return (_context.UserPermission?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
