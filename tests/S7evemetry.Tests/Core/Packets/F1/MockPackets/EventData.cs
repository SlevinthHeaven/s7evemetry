using S7evemetry.Core.Packets.F1;
using System;

namespace S7evemetry.Tests.Core.Packets.F1.MockPackets
{
    public class EventData : EventDataCommon
    {
        public static EventData? Read(Span<byte> input)
        {
            return Read<EventData>(input);
        }
    }
}
