using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.F1_2018.Packets;
using S7evemetry.F1_2018.Structures;
using System;

namespace S7evemetry.F1_2018.Readers
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

			if (input.Length != EventData.Size) return null;

			var packet = new PacketData<PacketHeader, EventData>()
			{
				Header = packetHeader

			};

			var eventData = EventData.Read(input);

			if (eventData == null) return null;

			packet.Data = eventData;

			return packet;
		}
	}
}
