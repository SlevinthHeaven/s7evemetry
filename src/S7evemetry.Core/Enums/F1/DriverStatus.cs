namespace S7evemetry.Core.Enums.F1
{
    /// <summary>
    /// Status of driver
    /// </summary>
    public enum DriverStatus
    {
        /// <summary>
        /// Driver is in the garage, value 0
        /// </summary>
        InGarage = 0,

        /// <summary>
        /// Driver is on their flying lap, value 1
        /// </summary>
        FlyingLap = 1,

        /// <summary>
        /// Driver is on their in lap, value 2
        /// </summary>
        InLap = 2,

        /// <summary>
        /// Driver is on their out lap, value 3
        /// </summary>
        OutLap = 3,

        /// <summary>
        /// Driver is on track, value 4
        /// </summary>
        OnTrack = 4
    }
}
