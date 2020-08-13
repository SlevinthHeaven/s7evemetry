using S7evemetry.Core.Structures;
using System;

namespace S7evemetry.F1_2018.Structures
{
    public class CarTelemetry : CarTelemetryCommon
	{
        public static new int Size { get; } = 62;
        public static CarTelemetry Read(Span<byte> input)
        {
            return Read<CarTelemetry>(input);
        }
    }
}
