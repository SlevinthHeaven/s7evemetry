using S7evemetry.Core.Structures;
using S7evemetry.Core.Packets.F1;
using System;
using S7evemetry.F1_2018.Packets;
using S7evemetry.F1_2018.Structures;
using S7evemetry.Core.Enums.F1;

namespace S7evemetry.F1_2018.Readers
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

			packet.Data = SessionData.Read(input);

			return packet;
		}
	}
}
