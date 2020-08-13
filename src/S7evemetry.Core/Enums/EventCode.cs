using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.Core.Enums
{
    /// <summary>
    /// SSTA - Session Started “SSTA” Sent when the session startsSession Started “SSTA” Sent when the session starts
    /// SEND - Session Ended “SEND” Sent when the session endsSession Ended “SEND” Sent when the session ends
    /// FTLP - Fastest Lap “FTLP” When a driver achieves the fastest lapFastest Lap “FTLP” When a driver achieves the fastest lap
    /// RTMT - Retirement “RTMT” When a driver retiresRetirement “RTMT” When a driver retires
    /// DRSE - DRS enabled “DRSE” Race control have enabled DRSDRS enabled “DRSE” Race control have enabled DRS
    /// DRSD - DRS disabled “DRSD” Race control have disabled DRSDRS disabled “DRSD” Race control have disabled DRS
    /// TMPT - Team mate in pits “TMPT” Your team mate has entered the pitsTeam mate in pits “TMPT” Your team mate has entered the pits
    /// CHQF - Chequered flag “CHQF” The chequered flag has been wavedChequered flag “CHQF” The chequered flag has been waved
    /// RCWN - Race Winner “RCWN” The race winner is announcedRace Winner “RCWN” The race winner is announced
    /// PENA - Penalty Issued “PENA” A penalty has been issued – details in eventPenalty Issued “PENA” A penalty has been issued – details in event
    /// SPTP - Speed Trap Triggered “SPTP” Speed trap has been triggered by fastest speedSpeed Trap Triggered “SPTP” Speed trap has been triggered by fastest speed
    /// </summary>
    public enum EventCode
    {
        SSTA,
        SEND,
        FTLP,
        RTMT,
        DRSE,
        DRSD,
        TMPT,
        CHQF,
        RCWN,
        PENA,
        SPTP 
    }
}
