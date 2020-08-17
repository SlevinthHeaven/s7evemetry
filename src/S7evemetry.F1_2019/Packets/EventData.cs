using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Core.Structures.EventDetails;
using System;

namespace S7evemetry.F1_2019.Packets
{
    public class EventData : EventDataCommon
    {
        /// <summary>
        /// Contains the additional details for events.
        /// The object will be null if there is no additional data.
        /// Events (and their corresponding object) with additional data are as follows:
        /// Fastest Lap (FTLP) => S7evemetry.Core.Structures.EventDetails.FastestLap; 
        /// Retirement (RTMT) => S7evemetry.Core.Structures.EventDetails.EventDetailsCommon; 
        /// Race Winner (RCWN) => S7evemetry.Core.Structures.EventDetails.EventDetailsCommon; 
        /// Team mate in pits (TMPT) => S7evemetry.Core.Structures.EventDetails.EventDetailsCommon; 
        /// </summary>
        public EventDetailsCommon? EventDetails { get; set; }

        public static new int Size { get; } = 9;

        public static EventData? Read(Span<byte> input)
        {
            var item = Read<EventData>(input.Slice(0,4));
            if (item == null) return item;
            //Event is a Retirement, Teammate in pits or Race Winner, load EventDetailsCommon instance
            if (item.EventCode == EventCode.RTMT
                || item.EventCode == EventCode.TMPT
                || item.EventCode == EventCode.RCWN)
            {
                item.EventDetails = new EventDetailsCommon
                {
                    VehicleIndex = input[4]
                };
            }

            //Event is a Fastest Lap, load FastestLap instance
            if (item.EventCode == EventCode.FTLP)
            {
                item.EventDetails = new FastestLap
                {
                    VehicleIndex = input[4],
                    LapTime = TimeSpan.FromSeconds(BitConverter.ToSingle(input.Slice(5, 4)))
                };
            }

            return item;
        }
    }
}
