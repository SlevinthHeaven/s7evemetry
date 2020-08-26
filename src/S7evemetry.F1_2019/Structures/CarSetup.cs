using S7evemetry.Core.Structures;
using System;

namespace S7evemetry.F1_2019.Structures
{
    public class CarSetup : CarSetupCommon
    {
        public static new int Size { get; } = 41;
        public float FrontTyrePressure { get; set; }         // Front tyre pressure (PSI)
        public float RearTyrePressure { get; set; }          // Rear tyre pressure (PSI)

        public static CarSetup? Read(Span<byte> input)
        {
            var size2019 = 8;
            var lap = Read<CarSetup>(input, size2019);
            if (lap == null) return null;
            lap.FrontTyrePressure = BitConverter.ToSingle(input.Slice(GapStartByte, 4)); // 4 byte
            lap.RearTyrePressure = BitConverter.ToSingle(input.Slice(GapStartByte + 4, 4)); // 8 byte
            return lap;
        }
    }
}
