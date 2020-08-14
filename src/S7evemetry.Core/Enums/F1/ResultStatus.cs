namespace S7evemetry.Core.Enums.F1
{
    /// <summary>
    /// Result status
    /// </summary>
    public enum ResultStatus
    {
        /// <summary>
        /// Invalid status, what is this?, value = 0
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Inactive in the race, afk?, value = 1
        /// </summary>
        Inactive = 1,

        /// <summary>
        /// Active in the race, value = 2
        /// </summary>
        Active = 2,

        /// <summary>
        /// Finished the race, got a position, value = 3
        /// </summary>
        Finished = 3,

        /// <summary>
        /// Disqualified from the race, value = 4
        /// </summary>
        Disqualified = 4,

        /// <summary>
        /// Not Classified in the race, unsure how this happens, value = 5
        /// </summary>
        NotClassified = 5,

        /// <summary>
        /// Retired from the race, value = 6
        /// </summary>
        Retired = 6
    }
}
