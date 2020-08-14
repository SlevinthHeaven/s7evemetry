namespace S7evemetry.Core.Enums.F1
{
    /// <summary>
    /// The pit status of a car
    /// </summary>
    public enum PitStatus
    {
        /// <summary>
        /// Not anywhere near the pits, honest, value = 0
        /// </summary>
        None = 0,

        /// <summary>
        /// In the pit, most likely in the box, value = 1
        /// </summary>
        Pitting = 1,

        /// <summary>
        /// In the pit area, pit lane and entrance/exit most likely, value = 2
        /// </summary>
        InPitArea = 2
    }
}
