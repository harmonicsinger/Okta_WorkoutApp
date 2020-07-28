using System;

namespace WorkoutApp.Domain
{
    public class Workout
    {
        public int WorkoutID { get; set; }
        public DateTime Date { get; set; }
        public int DistanceInMeters { get; set; }
        public long TimeInSeconds { get; set; }
    }
}
