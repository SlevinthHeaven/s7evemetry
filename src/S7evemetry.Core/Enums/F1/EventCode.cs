namespace S7evemetry.Core.Enums.F1
{
    /// <summary>
    /// Events that occur in F1 2018, 2019 or 2020
    /// </summary>
    public enum EventCode
    {
        /// <summary>
        /// Session Started “SSTA” Sent when the session starts
        /// </summary>
        SSTA,

        /// <summary>
        /// Session Ended “SEND” Sent when the session ends
        /// </summary>
        SEND,

        /// <summary>
        /// Fastest Lap “FTLP” When a driver achieves the fastest lap
        /// </summary>
        FTLP,

        /// <summary>
        /// Retirement “RTMT” When a driver retires
        /// </summary>
        RTMT,

        /// <summary>
        /// DRS enabled “DRSE” Race control have enabled DRS
        /// </summary>
        DRSE,

        /// <summary>
        /// DRS disabled “DRSD” Race control have disabled DRS
        /// </summary>
        DRSD,

        /// <summary>
        /// Team mate in pits “TMPT” Your team mate has entered the pits
        /// </summary>
        TMPT,

        /// <summary>
        /// Chequered flag “CHQF” The chequered flag has been waved
        /// </summary>
        CHQF,

        /// <summary>
        /// Race Winner “RCWN” The race winner is announced
        /// </summary>
        RCWN,

        /// <summary>
        /// Penalty Issued “PENA” A penalty has been issued – details in event
        /// </summary>
        PENA,

        /// <summary>
        /// Speed Trap Triggered “SPTP” Speed trap has been triggered by fastest speed
        /// </summary>
        SPTP
    }
}
