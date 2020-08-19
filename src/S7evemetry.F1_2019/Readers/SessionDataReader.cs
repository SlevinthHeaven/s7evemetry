using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.F1_2019.Packets;
using S7evemetry.F1_2019.Structures;
using System;

namespace S7evemetry.F1_2019.Readers
{
    public class SessionDataReader
    {
        public PacketData<PacketHeader, SessionData>? Read(Span<byte> input, PacketHeader packetHeader)
        {
            if (packetHeader == null)
            {
                throw new ArgumentNullException(nameof(packetHeader), $"{nameof(packetHeader)} is null.");
            }

            if (packetHeader.PacketId != PacketType.Session) return null;

            if (input.Length != SessionData.Size)
            {
                return null;
            }

            var packet = new PacketData<PacketHeader, SessionData>()
            {
                Header = packetHeader
            };

            var data = SessionData.Read(input);
            if (data == null) return null;
            packet.Data = data;

            return packet;
        }
    }
}
