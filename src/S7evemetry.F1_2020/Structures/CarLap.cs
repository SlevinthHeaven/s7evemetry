using S7evemetry.Core.Structures;
using System;
using System.Buffers.Binary;

namespace S7evemetry.F1_2020.Structures
{
    public class CarLap : CarLapCommon
    {
        public static int Size { get; } = 53;

        ////UPDATED in Beta 3:
        public ushort Sector1TimeInMs { get; set; }//uint16 m_sector1TimeInMS Sector 1 time in milliseconds
        public ushort Sector2TimeInMs { get; set; }  //uint16 m_sector2TimeInMS;           // Sector 2 time in milliseconds
        public float BestLapTime { get; set; }//float m_bestLapTime;               // Best lap time of the session in seconds
        public byte BestLapNum { get; set; }//uint8 m_bestLapNum;                // Lap number best time achieved on
        public ushort BestLapSector1TimeInMs { get; set; } //uint16 m_bestLapSector1TimeInMS;    // Sector 1 time of best lap in the session in milliseconds
        public ushort BestLapSector2TimeInMs { get; set; } //uint16 m_bestLapSector2TimeInMS;    // Sector 2 time of best lap in the session in milliseconds
        public ushort BestLapSector3TimeInMs { get; set; } //uint16 m_bestLapSector3TimeInMS;    // Sector 3 time of best lap in the session in milliseconds
        public ushort BestOverallSector1TimeInMs { get; set; } //uint16 m_bestOverallSector1TimeInMS;// Best overall sector 1 time of the session in milliseconds
        public byte BestOverallSector1LapNum { get; set; }//uint8 m_bestOverallSector1LapNum;  // Lap number best overall sector 1 time achieved on
        public ushort BestOverallSector2TimeInMs { get; set; }//uint16 m_bestOverallSector2TimeInMS;// Best overall sector 2 time of the session in milliseconds
        public byte BestOverallSector2LapNum { get; set; }//uint8 m_bestOverallSector2LapNum;  // Lap number best overall sector 2 time achieved on
        public ushort BestOverallSector3TimeInMs { get; set; }//uint16 m_bestOverallSector3TimeInMS;// Best overall sector 3 time of the session in milliseconds
        public byte BestOverallSector3LapNum { get; set; }//uint8 m_bestOverallSector3LapNum;  // Lap number best overall sector 3 time achieved on
       
        
        public static CarLap Read(Span<byte> input)
        {
            var size2020 = 24;
            var lap = Read<CarLap>(input, size2020);
            lap.Sector1TimeInMs = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(GapByte, 2)); //2
            lap.Sector2TimeInMs = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(GapByte + 2, 2)); //4 
            lap.BestLapTime = BitConverter.ToSingle(input.Slice(GapByte + 4, 4));//8
            lap.BestLapNum = input[GapByte + 8];//9
            lap.BestLapSector1TimeInMs = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(GapByte + 9, 2));//11
            lap.BestLapSector2TimeInMs = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(GapByte + 11, 2));//13
            lap.BestLapSector3TimeInMs = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(GapByte + 13, 2));//15
            lap.BestOverallSector1TimeInMs = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(GapByte + 15, 2));//17
            lap.BestOverallSector1LapNum = input[GapByte + 17];//18
            lap.BestOverallSector2TimeInMs = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(GapByte + 18, 2));//20
            lap.BestOverallSector2LapNum = input[GapByte + 20]; //21
            lap.BestOverallSector3TimeInMs = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(GapByte + 21, 2));//23
            lap.BestOverallSector3LapNum = input[GapByte + 23]; //24
            return lap;
        }
    }
}
