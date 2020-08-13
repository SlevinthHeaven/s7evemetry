using System;

namespace S7evemetry.F1_2020.Structures
{
    public class FinalClassification
    {
        public byte Position { get; set; } // Finishing position
        public byte NumberLaps { get; set; }               // Number of laps completed
        public byte GridPosition { get; set; }          // Grid position of the car
        public byte Points { get; set; }                // Number of points scored
        public byte NumberPitStops { get; set; }          // Number of pit stops made
        public byte ResultStatus { get; set; }          // Result status - 0 = invalid, 1 = inactive, 2 = active
        //                               // 3 = finished, 4 = disqualified, 5 = not classified
        //                               // 6 = retired
        public float BestLapTime { get; set; }           // Best lap time of the session in seconds
        public double TotalRaceTime { get; set; } //8        // Total race time in seconds without penalties
        public byte PenaltiesTime { get; set; }         // Total penalties accumulated in seconds
        public byte NumberPenalties { get; set; }          // Number of penalties applied to this driver
        public byte NumberTyreStints { get; set; }         // Number of tyres stints up to maximum
        public byte[] TyreStintsActual { get; set; } = new byte[8];   // Actual tyres used by this driver
        public byte[] TyreStintsVisual { get; set; } = new byte[8];   // Visual tyres used by this driver
        public static int Size { get; } = 37;

        public static FinalClassification Read(Span<byte> input)
        {
            return new FinalClassification
            {
                Position = input[0], //1
                NumberLaps = input[1], //2
                GridPosition = input[2], //3
                Points = input[3], //4
                NumberPitStops = input[4], //5
                ResultStatus = input[5], //6
                BestLapTime = BitConverter.ToSingle(input.Slice(6, 4)), //10
                TotalRaceTime = BitConverter.ToDouble(input.Slice(10, 8)), //18
                PenaltiesTime = input[18], //19
                NumberPenalties = input[19], //20
                NumberTyreStints = input[20], //21
                TyreStintsActual = input.Slice(21,8).ToArray(), //29
                TyreStintsVisual = input.Slice(29, 8).ToArray(), //37
            };
        }
    }
}
