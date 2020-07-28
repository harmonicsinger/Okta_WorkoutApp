using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Domain
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly WorkoutDbContext _context;

        public WorkoutRepository(WorkoutDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Workout>> GetAllWorkouts()
        {
            return await _context.Workouts.ToListAsync();
        }

        public async Task<Workout> GetWorkoutByID(int ID)
        {
            return await _context.Workouts.SingleOrDefaultAsync(x => x.WorkoutID == ID);
        }

        public async Task AddWorkout(Workout workout)
        {
            if (workout != null)
            {
                _context.Workouts.Add(workout);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateWorkout(Workout workout)
        {
            if (workout != null)
            {
                _context.Workouts.Update(workout);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteWorkout(int ID)
        {
            var workout = await _context.Workouts.SingleOrDefaultAsync(x => x.WorkoutID == ID);

            if (workout != null)
            {
                _context.Workouts.Remove(workout);
                await _context.SaveChangesAsync();
            }
        }




    }
}
