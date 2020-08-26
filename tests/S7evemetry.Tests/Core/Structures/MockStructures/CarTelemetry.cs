using S7evemetry.Core.Packets.F1;
using S7evemetry.Core.Structures;
using System;

namespace S7evemetry.Tests.Core.Structures.MockStructures
{
    public class CarTelemetry : CarTelemetryCommon
    {
        public static CarTelemetry? Read(Span<byte> input)
        {
            return Read<CarTelemetry>(input);
        }
    }
}
