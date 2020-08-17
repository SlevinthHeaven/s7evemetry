using System;

namespace S7evemetry.Core.Structures.EventDetails
{

    /// <summary>
    /// Fastest Lap event data
    /// </summary>
    public class FastestLap : EventDetailsCommon
    {
        /// <summary>
        /// Lap time is in seconds
        /// </summary>
        public TimeSpan LapTime { get; set; }
    }
}
