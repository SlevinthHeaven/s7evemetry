using S7evemetry.Core.Packets.F1;
using S7evemetry.Core.Structures;
using System;
using System.Net.NetworkInformation;

namespace S7evemetry.Tests.Core.Structures.MockStructures
{
    public class CarSetup : CarSetupCommon
    {
        public static CarSetup? Read(Span<byte> input)
        {
            return Read<CarSetup>(input, 0);
        }
    }
}
