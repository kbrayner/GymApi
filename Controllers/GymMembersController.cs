using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymApi.Data;
using GymApi.Models;

namespace GymApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymMembersController : ControllerBase
    {
        private readonly GymContext _context;

        public GymMembersController(GymContext context)
        {
            _context = context;
        }

        // GET: api/GymMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymMember>>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }

        // GET: api/GymMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GymMember>> GetGymMember(int id)
        {
            var gymMember = await _context.Members.FindAsync(id);

            if (gymMember == null)
            {
                return NotFound();
            }

            return gymMember;
        }

        // PUT: api/GymMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGymMember(int id, GymMember gymMember)
        {
            if (id != gymMember.Id)
            {
                return BadRequest();
            }

            _context.Entry(gymMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GymMemberExists(id))
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

        // POST: api/GymMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GymMember>> PostGymMember(GymMember gymMember)
        {
            _context.Members.Add(gymMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGymMember", new { id = gymMember.Id }, gymMember);
        }

        // DELETE: api/GymMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymMember(int id)
        {
            var gymMember = await _context.Members.FindAsync(id);
            if (gymMember == null)
            {
                return NotFound();
            }

            _context.Members.Remove(gymMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GymMemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
