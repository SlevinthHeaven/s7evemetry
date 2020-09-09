using System;
using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Core.Structures;
using S7evemetry.F1_2020.Structures;

namespace S7evemetry.F1_2020.Readers
{
    public class ParticipantsDataReader
	{
		public PacketData<PacketHeader, ParticipantData, Participant>? Read(Span<byte> input, PacketHeader packetHeader)
		{
			if (packetHeader == null)
			{
				throw new ArgumentNullException(nameof(packetHeader), $"{nameof(packetHeader)} is null.");
			}

			if (packetHeader.PacketId != PacketType.Participants) return null;

			if (input.Length != 
								(packetHeader.GridSize * Participant.Size) +
								ParticipantData.Size)
			{
				return null;
			}

			var packet = new PacketData<PacketHeader, ParticipantData, Participant>()
			{
				Header = packetHeader
			};

			for (var i = 0; i < packet.Header.GridSize; i++)
			{
				packet.CarData.Add(Participant.Read(input.Slice(1 + (i * Participant.Size), Participant.Size)));
			}

			var data = ParticipantData.Read(input.Slice(0, ParticipantData.Size));
			if (data == null) return null;
			packet.Data = data;

			return packet;
		}


	}
}
