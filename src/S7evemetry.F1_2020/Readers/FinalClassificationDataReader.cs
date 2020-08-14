using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Core.Structures;
using S7evemetry.F1_2020.Packets;
using S7evemetry.F1_2020.Structures;
using System;

namespace S7evemetry.F1_2020.Readers
{
    public class FinalClassificationDataReader
	{
		public PacketData<PacketHeader, FinalClassificationData, FinalClassification>? Read(Span<byte> input, PacketHeader packetHeader)
		{
			if (packetHeader == null)
			{
				throw new ArgumentNullException(nameof(packetHeader), $"{nameof(packetHeader)} is null.");
			}

			if (packetHeader.PacketId != PacketType.FinalClassification) return null;

			if (input.Length != packetHeader.Size +
								(packetHeader.GridSize * FinalClassification.Size) +
								FinalClassificationData.Size)
			{
				return null;
			}
			var packet = new PacketData<PacketHeader, FinalClassificationData, FinalClassification>()
			{
				Header = packetHeader
			};

			for (var i = 0; i < packet.Header.GridSize; i++)
			{
				packet.CarData.Add(FinalClassification.Read(input.Slice((i * FinalClassification.Size), FinalClassification.Size)));
			}

			packet.Data = FinalClassificationData.Read(input.Slice(0, FinalClassificationData.Size));

			return packet;
		}

	}
}
