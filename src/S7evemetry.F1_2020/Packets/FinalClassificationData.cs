using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.F1_2020.Packets
{
    public class FinalClassificationData
    {
        public static int Size { get; } = 1;
        public byte NumberOfCars { get; set; }
        public static FinalClassificationData Read(Span<byte> input)
        {
            return new FinalClassificationData
            {
                NumberOfCars = input[0]
            };
        }
    }
}
