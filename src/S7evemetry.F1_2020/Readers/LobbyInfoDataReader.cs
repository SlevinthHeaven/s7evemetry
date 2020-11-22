using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.F1_2020.Structures;
using S7evemetry.F1_2020.Packets;
using System;

namespace S7evemetry.F1_2020.Readers
{
    public class LobbyInfoDataReader
	{
		public PacketData<PacketHeader, LobbyInfoData, LobbyInfo>? Read(Span<byte> input, PacketHeader packetHeader)
		{
			if (packetHeader == null)
			{
				throw new ArgumentNullException(nameof(packetHeader), $"{nameof(packetHeader)} is null.");
			}

			if (packetHeader.PacketId != PacketType.LobbyInfo) return null;

			if (input.Length != (packetHeader.GridSize * LobbyInfo.Size) + LobbyInfoData.Size)
			{
				return null;
			}

			var packet = new PacketData<PacketHeader, LobbyInfoData, LobbyInfo>()
			{
				Header = packetHeader
			};

			for (var i = 0; i < packet.Header.GridSize; i++)
			{
				packet.CarData.Add(LobbyInfo.Read(input.Slice((i * LobbyInfo.Size) + LobbyInfoData.Size, LobbyInfo.Size)));
			}

			packet.Data = LobbyInfoData.Read(input.Slice(0, LobbyInfoData.Size));

			return packet;
		}

	}
}
