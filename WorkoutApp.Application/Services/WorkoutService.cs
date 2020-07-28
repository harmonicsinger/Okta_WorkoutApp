using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkoutApp.Domain;

namespace WorkoutApp.Application
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<IEnumerable<WorkoutDTO>> GetAllWorkouts()
        {
            var list = new List<WorkoutDTO>();
            var workouts = await _workoutRepository.GetAllWorkouts();

            foreach (var workout in workouts)
            {
                var dto = new WorkoutDTO
                {
                    WorkoutID = workout.WorkoutID,
                    Date = workout.Date,
                    DistanceInMeters = workout.DistanceInMeters,
                    TimeInSeconds = workout.TimeInSeconds
                };

                list.Add(dto);
            }

            return list;
        }

        public async Task<WorkoutDTO> GetWorkoutByID(int ID)
        {
            var workout = await _workoutRepository.GetWorkoutByID(ID);
            var dto = new WorkoutDTO();

            if (workout != null)
            {
                dto.WorkoutID = workout.WorkoutID;
                dto.Date = workout.Date;
                dto.DistanceInMeters = workout.DistanceInMeters;
                dto.TimeInSeconds = workout.TimeInSeconds;
            }

            return dto;
        }

        public async Task AddWorkout(WorkoutDTO dto)
        {
            if (dto != null)
            {
                var workout = new Workout
                {
                    Date = dto.Date,
                    DistanceInMeters = dto.DistanceInMeters,
                    TimeInSeconds = dto.TimeInSeconds
                };

                await _workoutRepository.AddWorkout(workout);
            }
        }

        public async Task UpdateWorkout(WorkoutDTO dto)
        {
            var workout = await _workoutRepository.GetWorkoutByID(dto.WorkoutID);

            if (workout != null)
            {
                workout.Date = dto.Date;
                workout.DistanceInMeters = dto.DistanceInMeters;
                workout.TimeInSeconds = dto.TimeInSeconds;
            }

            await _workoutRepository.UpdateWorkout(workout);
        }

        public async Task DeleteWorkout(int ID)
        {
            var workout = await _workoutRepository.GetWorkoutByID(ID);

            if (workout != null)
            {
                await _workoutRepository.DeleteWorkout(workout.WorkoutID);
            }
        }

    }
}
