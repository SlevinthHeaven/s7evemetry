using S7evemetry.Core.Enums.F1;
using System;
using System.Text;

namespace S7evemetry.Core.Packets.F1
{
    /// <summary>
    /// This packet gives details of events that happen during the course of a session.
    /// </summary>
    public class EventDataCommon
    {
        public static int Size { get; } = 4;
        /// <summary>
        /// SSTA - Session Started “SSTA” Sent when the session starts
        /// SEND - Session Ended “SEND” Sent when the session ends
        /// FTLP - Fastest Lap “FTLP” When a driver achieves the fastest lap
        /// RTMT - Retirement “RTMT” When a driver retires
        /// DRSE - DRS enabled “DRSE” Race control have enabled DRS
        /// DRSD - DRS disabled “DRSD” Race control have disabled DRS
        /// TMPT - Team mate in pits “TMPT” Your team mate has entered the pits
        /// CHQF - Chequered flag “CHQF” The chequered flag has been waved
        /// RCWN - Race Winner “RCWN” The race winner is announced
        /// PENA - Penalty Issued “PENA” A penalty has been issued – details in event
        /// SPTP - Speed Trap Triggered “SPTP” Speed trap has been triggered by fastest speed
        /// </summary>
        public EventCode EventCode { get; set; }

        /// <summary>
        /// Read event data from the input
        /// </summary>
        /// <param name="input">A Span of byte to be deserialized</param>
        /// <returns>The EventData object and corresponding EventDetails (if there are any)</returns>
        protected static T? Read<T>(Span<byte> input) where T : EventDataCommon, new()
        {
            if (input.Length != 4) return null;
            var output = new T
            {
                EventCode = (EventCode)Enum.Parse(typeof(EventCode), Encoding.UTF8.GetString(input.Slice(0, 4)))
            };
            return output;
        }
    }
}
