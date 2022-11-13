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
    public class TrainingPlanExercisesController : ControllerBase
    {
        private readonly GymContext _context;

        public TrainingPlanExercisesController(GymContext context)
        {
            _context = context;
        }

        // GET: api/TrainingPlanExercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingPlanExercise>>> GetTrainingPlanExercises()
        {
            return await _context.TrainingPlanExercises.ToListAsync();
        }

        // GET: api/TrainingPlanExercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingPlanExercise>> GetTrainingPlanExercise(int id)
        {
            var trainingPlanExercise = await _context.TrainingPlanExercises.FindAsync(id);

            if (trainingPlanExercise == null)
            {
                return NotFound();
            }

            return trainingPlanExercise;
        }

        // PUT: api/TrainingPlanExercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingPlanExercise(int id, TrainingPlanExercise trainingPlanExercise)
        {
            if (id != trainingPlanExercise.TrainingPlanId)
            {
                return BadRequest();
            }

            _context.Entry(trainingPlanExercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingPlanExerciseExists(id))
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

        // POST: api/TrainingPlanExercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainingPlanExercise>> PostTrainingPlanExercise(TrainingPlanExercise trainingPlanExercise)
        {
            _context.TrainingPlanExercises.Add(trainingPlanExercise);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainingPlanExerciseExists(trainingPlanExercise.TrainingPlanId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrainingPlanExercise", new { id = trainingPlanExercise.TrainingPlanId }, trainingPlanExercise);
        }

        // DELETE: api/TrainingPlanExercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingPlanExercise(int id)
        {
            var trainingPlanExercise = await _context.TrainingPlanExercises.FindAsync(id);
            if (trainingPlanExercise == null)
            {
                return NotFound();
            }

            _context.TrainingPlanExercises.Remove(trainingPlanExercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainingPlanExerciseExists(int id)
        {
            return _context.TrainingPlanExercises.Any(e => e.TrainingPlanId == id);
        }
    }
}
