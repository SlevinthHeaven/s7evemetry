using S7evemetry.Core.Structures;
using System;

namespace S7evemetry.F1_2020.Structures
{
    public class CarSetup : CarSetupCommon
    {
        public static int Size { get; } = 49;
        public float RearLeftTyrePressure { get; set; }
        public float RearRightTyrePressure { get; set; }
        public float FrontLeftTyrePressure { get; set; }
        public float FrontRightTyrePressure { get; set; }

        public static CarSetup Read(Span<byte> input)
        {
            var size2020 = 16;
            var start = 28;
            var lap = Read<CarSetup>(input, size2020 + start);

            lap.RearLeftTyrePressure = BitConverter.ToSingle(input.Slice(start, 4)); // 4 byte
            lap.RearRightTyrePressure = BitConverter.ToSingle(input.Slice(start + 4, 4)); // 8 byte
            lap.FrontLeftTyrePressure = BitConverter.ToSingle(input.Slice(start + 8, 4)); // 12 byte
            lap.FrontRightTyrePressure = BitConverter.ToSingle(input.Slice(start + 12, 4)); // 16 byte

            return lap;
        }
    }
}
