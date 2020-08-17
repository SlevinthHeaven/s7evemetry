using S7evemetry.Core.Enums.F1;
using System;

namespace S7evemetry.Core.Structures.EventDetails
{
    /// <summary>
    /// The penalty event
    /// </summary>
    public class Penalty : EventDetailsCommon
    {
        /// <summary>
        /// Penalty type – see Appendices
        /// </summary>
        public PenaltyType PenaltyType;

        /// <summary>
        /// Infringement type – see Appendices
        /// </summary>
        public byte InfringementType;

        /// <summary>
        /// Vehicle index of the other car involved
        /// </summary>
        public byte OtherVehicleIndex;

        /// <summary>
        /// Time gained, or time spent doing action in seconds
        /// </summary>
        public byte Time;

        /// <summary>
        /// Lap the penalty occurred on
        /// </summary>
        public byte LapNum;

        /// <summary>
        /// Number of places gained by this
        /// </summary>
        public byte PlacesGained;
    }
}
