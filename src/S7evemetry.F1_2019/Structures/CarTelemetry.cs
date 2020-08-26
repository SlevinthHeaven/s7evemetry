using S7evemetry.Core.Structures;
using System;
using System.Buffers.Binary;

namespace S7evemetry.F1_2019.Structures
{
    public class CarTelemetry : CarTelemetryCommon
    {
        public static new int Size { get; } = 66;
        
        public byte[] SurfaceType { get; set; } = new byte[4];            // Driving surface, see appendices(4)

        public static CarTelemetry? Read(Span<byte> input)
        {
            var item =  Read<CarTelemetry>(input);
            if (item == null) return null;
            item.SurfaceType = new byte[] { input[62], input[63], input[64], input[65] };

            return item;
        }
    }
}

