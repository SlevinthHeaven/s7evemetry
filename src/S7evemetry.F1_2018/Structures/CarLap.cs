using S7evemetry.Core.Structures;
using System;

namespace S7evemetry.F1_2018.Structures
{
    public class CarLap : CarLapCommon
    {
        public static new int Size { get; } = 41;
        public float BestLapTime { get; set; }         // Best lap time of the session in seconds
        public float Sector1Time { get; set; }         // Sector 1 time in seconds
        public float Sector2Time { get; set; }         // Sector 2 time in seconds

		public static CarLap? Read(Span<byte> input)
		{
            var size2018 = 12;
            var lap = Read<CarLap>(input, size2018);
            if (lap == null) return null;
            lap.BestLapTime = BitConverter.ToSingle(input.Slice(GapStartByte, 4)); //4
            lap.Sector1Time = BitConverter.ToSingle(input.Slice(GapStartByte + 4, 4)); //8
            lap.Sector2Time = BitConverter.ToSingle(input.Slice(GapStartByte + 8, 4)); //12
            return lap;
		}
	}
}
