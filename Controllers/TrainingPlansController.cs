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
    public class TrainingPlansController : ControllerBase
    {
        private readonly GymContext _context;

        public TrainingPlansController(GymContext context)
        {
            _context = context;
        }

        // GET: api/TrainingPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingPlan>>> GetTrainingPlans()
        {
            return await _context.TrainingPlans.ToListAsync();
        }

        // GET: api/TrainingPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingPlan>> GetTrainingPlan(int id)
        {
            var trainingPlan = await _context.TrainingPlans.FindAsync(id);

            if (trainingPlan == null)
            {
                return NotFound();
            }

            return trainingPlan;
        }

        // PUT: api/TrainingPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingPlan(int id, TrainingPlan trainingPlan)
        {
            if (id != trainingPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainingPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingPlanExists(id))
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

        // POST: api/TrainingPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainingPlan>> PostTrainingPlan(TrainingPlan trainingPlan)
        {
            _context.TrainingPlans.Add(trainingPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainingPlan", new { id = trainingPlan.Id }, trainingPlan);
        }

        // DELETE: api/TrainingPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingPlan(int id)
        {
            var trainingPlan = await _context.TrainingPlans.FindAsync(id);
            if (trainingPlan == null)
            {
                return NotFound();
            }

            _context.TrainingPlans.Remove(trainingPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingPlanExists(int id)
        {
            return _context.TrainingPlans.Any(e => e.Id == id);
        }
    }
}
