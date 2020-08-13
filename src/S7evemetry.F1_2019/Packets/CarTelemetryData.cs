using S7evemetry.Core.Packets;
using System;

namespace S7evemetry.F1_2019.Packets
{
    public class CarTelemetryData : CarTelemetryDataCommon
    {
        public static CarTelemetryData Read(Span<byte> input)
        {
            return Read<CarTelemetryData>(input);
        }
    }
}
