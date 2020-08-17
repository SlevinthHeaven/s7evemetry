using S7evemetry.Core.Packets.F1;
using System;

namespace S7evemetry.F1_Legacy.Packets
{
    public class EventData : EventDataCommon
    {
        public static new int Size { get; } = 4;
        public static EventData? Read(Span<byte> input)
        {
            return Read<EventData>(input);
        }
    }
}
