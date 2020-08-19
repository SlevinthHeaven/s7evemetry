using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.F1_Legacy.Structures;
using System;

namespace S7evemetry.F1_Legacy.Readers
{
    public class CarSetupDataReader
    {
        public PacketData<PacketHeader, CarSetupData, CarSetup>? Read(Span<byte> input, PacketHeader packetHeader)
        {
            if (packetHeader == null)
            {
                throw new ArgumentNullException(nameof(packetHeader), $"{nameof(packetHeader)} is null.");
            }

            if (packetHeader.PacketId != PacketType.CarSetups) return null;

            if (input.Length != (packetHeader.GridSize * CarSetup.Size) + CarSetupData.Size)
            {
                return null;
            }

            var packet = new PacketData<PacketHeader, CarSetupData, CarSetup>()
            {
                Header = packetHeader
            };

            for (var i = 0; i < packet.Header.GridSize; i++)
            {
                packet.CarData.Add(CarSetup.Read(input.Slice((i * CarSetup.Size), CarSetup.Size)));
            }

            packet.Data = new CarSetupData();

            return packet;
        }
    }
}
