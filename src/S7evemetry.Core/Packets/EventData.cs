using S7evemetry.Core.Enums;
using S7evemetry.Core.Structures.EventDetails;
using System;
using System.Text;

namespace S7evemetry.Core.Packets
{
    /// <summary>
    /// This packet gives details of events that happen during the course of a session.
    /// </summary>
    public class EventData
    {
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
        /// Contains the additional details for events.
        /// The object will be null if there is no additional data.
        /// Events (and their corresponding object) with additional data are as follows:
        /// Fastest Lap (FTLP) => S7evemetry.Core.Structures.EventDetails.FastestLap; 
        /// Speed Trap (SPTP) => S7evemetry.Core.Structures.EventDetails.SpeedTrap; 
        /// Penalty (PENA) => S7evemetry.Core.Structures.EventDetails.Penalty; 
        /// Retirement (RTMT) => S7evemetry.Core.Structures.EventDetails.EventDetailsCommon; 
        /// Race Winner (RCWN) => S7evemetry.Core.Structures.EventDetails.EventDetailsCommon; 
        /// Team mate in pits (TMPT) => S7evemetry.Core.Structures.EventDetails.EventDetailsCommon; 
        /// </summary>
        public EventDetailsCommon? EventDetails { get; set; }

        /// <summary>
        /// Read event data from the input
        /// </summary>
        /// <param name="input">A Span of byte to be deserialized</param>
        /// <returns>The EventData object and corresponding EventDetails (if there are any)</returns>
        public static EventData Read(Span<byte> input)
        {
            var data = new EventData
            {
                EventCode = (EventCode)Enum.Parse(typeof(EventCode), Encoding.UTF8.GetString(input.Slice(0, 4)))
            };

            //Event is a Fastest Lap, load FastestLap instance
            if (data.EventCode == EventCode.FTLP)
            {
                data.EventDetails = new FastestLap
                {
                    VehicleIndex = input[4],
                    LapTime = BitConverter.ToSingle(input.Slice(5, 4))
                };
            }

            //Event is a Speed Trap, load SpeedTrap instance
            if (data.EventCode == EventCode.SPTP)
            {
                data.EventDetails = new SpeedTrap
                {
                    VehicleIndex = input[4],
                    Speed = BitConverter.ToSingle(input.Slice(5, 4))
                };
            }

            //Event is a Penalty, load Penalty instance
            if (data.EventCode == EventCode.PENA)
            {
                data.EventDetails = new Penalty
                {
                    PenaltyType = input[4],
                    InfringementType = input[5],
                    VehicleIndex = input[6],
                    OtherVehicleIndex = input[7],
                    Time = input[8],
                    LapNum = input[9],
                    PlacesGained = input[10]
                };
            }

            //Event is a Retirement, Teammate in pits or Race Winner, load EventDetailsCommon instance
            if (data.EventCode == EventCode.RTMT
                || data.EventCode == EventCode.TMPT
                || data.EventCode == EventCode.RCWN)
            {
                data.EventDetails = new EventDetailsCommon
                {
                    VehicleIndex = input[4]
                };
            }

            return data;
        }
    }
}
