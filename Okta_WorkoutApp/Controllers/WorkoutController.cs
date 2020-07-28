using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutApp.Application;

namespace Okta_WorkoutApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public async Task<IEnumerable<WorkoutDTO>> GetAllWorkouts()
        {
            return await _workoutService.GetAllWorkouts();
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkoutByID(int ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workout = await _workoutService.GetWorkoutByID(ID);

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        [HttpPut("{ID}")]
        public async Task<IActionResult> UpdateWorkout(int ID, WorkoutDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ID != dto.WorkoutID)
            {
                return BadRequest();
            }

            try
            {
                await _workoutService.UpdateWorkout(dto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(ID))
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

        [HttpPost]
        public async Task<IActionResult> AddWorkout(WorkoutDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _workoutService.AddWorkout(dto);

            return CreatedAtAction("GetWorkouts", new { id = dto.WorkoutID }, dto);
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteWorkout(int ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workout = await _workoutService.GetWorkoutByID(ID);

            if (workout == null)
            {
                return NotFound();
            }

            await _workoutService.DeleteWorkout(ID);

            return Ok(workout);
        }

        private bool WorkoutExists(int ID)
        {
            var workout = _workoutService.GetWorkoutByID(ID);

            if (workout != null)
            {
                return true;
            }

            return false;

        }
    }
}