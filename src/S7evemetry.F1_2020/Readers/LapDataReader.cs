using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets;
using S7evemetry.Core.Structures;
using S7evemetry.F1_2020.Structures;
using System;

namespace S7evemetry.F1_2020.Readers
{
    public class LapDataReader
    {
        public PacketData<PacketHeader, LapData, CarLap>? Read(Span<byte> input, PacketHeader packetHeader)
        {
            if (packetHeader == null)
            {
                throw new ArgumentNullException(nameof(packetHeader), $"{nameof(packetHeader)} is null.");
            }

            if (packetHeader.PacketId != PacketType.LapData) return null;

            if (input.Length != packetHeader.Size +
                                (packetHeader.GridSize * CarLap.Size) +
                                LapData.Size)
            {
                return null;
            }

            var packet = new PacketData<PacketHeader, LapData, CarLap>()
            {
                Header = packetHeader
            };

            for (var i = 0; i < packet.Header.GridSize; i++)
            {
                packet.CarData.Add(CarLap.Read(input.Slice((i * CarLap.Size), CarLap.Size)));
            }

            packet.Data = new LapData();

            return packet;
        }
    }

}

