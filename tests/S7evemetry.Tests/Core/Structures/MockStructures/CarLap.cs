using S7evemetry.Core.Packets.F1;
using S7evemetry.Core.Structures;
using System;

namespace S7evemetry.Tests.Core.Structures.MockStructures
{
    public class CarLap : CarLapCommon
    {
        public static CarLap? Read(Span<byte> input)
        {
            return Read<CarLap>(input, 0);
        }
    }
}
