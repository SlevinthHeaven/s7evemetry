using System;

namespace S7evemetry.Core.Structures.EventDetails
{
    /// <summary>
    /// Speed Trap event details
    /// </summary>
    public class SpeedTrap : EventDetailsCommon
    {
        /// <summary>
        /// Top speed achieved in kilometres per hour
        /// </summary>
        public float Speed { get; set; }
    }
}
