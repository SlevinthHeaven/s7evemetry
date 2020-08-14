using S7evemetry.Core.Packets.F1;
using System;

namespace S7evemetry.F1_2018.Packets
{
    public class CarTelemetryData : CarTelemetryDataCommon
    {
        public static CarTelemetryData Read(Span<byte> input)
        {
            return Read<CarTelemetryData>(input);
        }
    }
}
