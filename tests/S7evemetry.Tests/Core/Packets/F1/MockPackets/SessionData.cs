using S7evemetry.Core.Packets.F1;
using System;

namespace S7evemetry.Tests.Core.Packets.F1.MockPackets
{
    public class SessionData : SessionDataCommon
    {
        public static SessionData? Read(Span<byte> input)
        {
            return Read<SessionData>(input);
        }
    }
}
