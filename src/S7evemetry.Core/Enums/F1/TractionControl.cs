namespace S7evemetry.Core.Enums.F1
{
    /// <summary>
    /// Traction control level
    /// </summary>
    public enum TractionControl
    {
        /// <summary>
        /// You have traction control off
        /// </summary>
        Off = 0,

        /// <summary>
        /// You have traction control on, but not strong enough to stop you spinning.
        /// </summary>
        Medium = 1,

        /// <summary>
        /// You have traction control on, it's so on, I dare you to try spinning out.
        /// </summary>
        Full = 2
    }
}
