namespace S7evemetry.Core.Enums
{
    /// <summary>
    /// Status of driver - 0 = in garage, 1 = flying lap, 
    /// 2 = in lap, 3 = out lap, 4 = on track
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
