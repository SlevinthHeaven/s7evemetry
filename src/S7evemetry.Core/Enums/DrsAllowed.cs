namespace S7evemetry.Core.Enums
{
    /// <summary>
    /// The status of DRS
    /// </summary>
    public enum DrsAllowed
    {
        /// <summary>
        /// DRS is not allowed, value 0
        /// </summary>
        NotAllowed = 0,

        /// <summary>
        /// DRS is allowed, value 1
        /// </summary>
        Allowed = 1,

        /// <summary>
        /// DRS has unknown state, value -1
        /// </summary>
        Unknown = -1,
    }
}
