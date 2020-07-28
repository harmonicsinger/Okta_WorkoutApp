using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorkoutApp.Domain
{
    public interface IWorkoutRepository
    {
        Task<IEnumerable<Workout>> GetAllWorkouts();
        Task<Workout> GetWorkoutByID(int ID);
        Task AddWorkout(Workout workout);
        Task UpdateWorkout(Workout workout);
        Task DeleteWorkout(int ID);

    }
}
