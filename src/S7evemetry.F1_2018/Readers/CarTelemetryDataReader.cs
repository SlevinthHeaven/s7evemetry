﻿using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.F1_2018.Packets;
using S7evemetry.F1_2018.Structures;
using System;

namespace S7evemetry.F1_2018.Readers
{
    public class CarTelemetryDataReader
    {
        public PacketData<PacketHeader, CarTelemetryData, CarTelemetry>? Read(Span<byte> input, PacketHeader packetHeader)
        {
            if (packetHeader == null)
            {
                throw new ArgumentNullException(nameof(packetHeader), $"{nameof(packetHeader)} is null.");
            }

            if (packetHeader.PacketId != PacketType.CarTelemetry) return null;

            if (input.Length != (packetHeader.GridSize * CarTelemetry.Size) + CarTelemetryData.Size)
            {
                return null;
            }

            var packet = new PacketData<PacketHeader, CarTelemetryData, CarTelemetry>()
            {
                Header = packetHeader
            };

            for (var i = 0; i < packet.Header.GridSize; i++)
            {
                var item = CarTelemetry.Read(input.Slice((i * CarTelemetry.Size), CarTelemetry.Size));
                if (item == null) continue;
                packet.CarData.Add(item);
            }

            var data = CarTelemetryData.Read(input.Slice(packet.Header.GridSize * CarTelemetry.Size));
            if (data == null) return null;
            packet.Data = data;

            return packet;
        }
    }
}
