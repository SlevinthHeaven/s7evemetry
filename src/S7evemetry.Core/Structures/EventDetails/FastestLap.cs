using System;

namespace S7evemetry.Core.Structures.EventDetails
{

    /// <summary>
    /// Fastest Lap event data
    /// </summary>
    public class FastestLap : EventDetailsCommon
    {
        /// <summary>
        /// LapTime
        /// </summary>
        public float LapTime { get; set; }
    }
}
