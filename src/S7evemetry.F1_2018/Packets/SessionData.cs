using S7evemetry.Core.Packets;
using System;

namespace S7evemetry.F1_2018.Packets
{
    public class SessionData : SessionDataCommon
    {
        public static new int Size { get; set; } = 126;
        public static SessionData Read(Span<byte> input)
        {
            return Read<SessionData>(input);
        }
    }
}
