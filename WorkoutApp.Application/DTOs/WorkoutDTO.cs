using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutApp.Application
{
    public class WorkoutDTO
    {
        public int WorkoutID { get; set; }
        public DateTime Date { get; set; }
        public int DistanceInMeters { get; set; }
        public long TimeInSeconds { get; set; }
    }
}
