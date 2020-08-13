using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets;
using S7evemetry.F1_2019.Structures;
using System;

namespace S7evemetry.F1_2019.Readers
{
    public class EventDataReader
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <param name="packetHeader"></param>
		/// <returns>
		/// Packet Data of type Event Data.
		/// Returns null if input size incorrect.
		/// Returns null if packetHeader.PacketId is not Event.
		/// </returns>
		public PacketData<PacketHeader, EventData>? Read(Span<byte> input, PacketHeader packetHeader)
		{
			if (packetHeader == null)
			{
				throw new ArgumentNullException(nameof(packetHeader), $"{nameof(packetHeader)} is null.");
			}

			if (packetHeader.PacketId != PacketType.Event) return null;

			if (input.Length != packetHeader.Size + 9) return null;

			var packet = new PacketData<PacketHeader, EventData>()
			{
				Header = packetHeader

			};

			packet.Data = EventData.Read(input);

			return packet;
		}
	}
}
