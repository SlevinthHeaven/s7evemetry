using S7evemetry.Core.Structures;
using S7evemetry.Core.Packets.F1;
using System;
using S7evemetry.Core.Enums.F1;
using S7evemetry.F1_2018.Structures;

namespace S7evemetry.F1_2018.Readers
{
    public class MotionDataReader
	{
		public PacketData<PacketHeader, MotionData, CarMotion>? Read(Span<byte> input, PacketHeader packetHeader)
		{
			if (packetHeader == null)
			{
				throw new ArgumentNullException(nameof(packetHeader), $"{nameof(packetHeader)} is null.");
			}

			if (packetHeader.PacketId != PacketType.Motion) return null;

			if (input.Length != (packetHeader.GridSize * CarMotion.Size) + MotionData.Size)
			{
				return null;
			}

			var packet = new PacketData<PacketHeader, MotionData, CarMotion>()
			{
				Header = packetHeader

			};

			for (var i = 0; i < packet.Header.GridSize; i++)
			{
				var item = CarMotion.Read(input.Slice((i * CarMotion.Size), CarMotion.Size));
				if (item == null) continue;
				packet.CarData.Add(item);
			}

			var data = MotionData.Read(input.Slice(packet.Header.GridSize * CarMotion.Size, MotionData.Size));
			if (data == null) return null;
			packet.Data = data;

			return packet;
		}

		
	}
}
