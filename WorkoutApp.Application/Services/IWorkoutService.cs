using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Application
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutDTO>> GetAllWorkouts();
        Task<WorkoutDTO> GetWorkoutByID(int ID);
        Task AddWorkout(WorkoutDTO dto);
        Task UpdateWorkout(WorkoutDTO dto);
        Task DeleteWorkout(int ID);
    }
}
