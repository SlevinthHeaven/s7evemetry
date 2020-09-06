using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Structures;
using System;
using System.Buffers.Binary;

namespace S7evemetry.F1_2020.Structures
{
    public class PacketHeader : PacketHeaderCommon
    {
        public static new int Size { get; } = 24;
        public new int GridSize { get; } = 22;
        public byte GameMajorVersion { get; set; }     // Game major version - "X.00"
        public byte GameMinorVersion { get; set; }    // Game minor version - "1.XX"
        public byte SecondPlayerCarIndex { get; set; }    

        public static PacketHeader Read(Span<byte> input)
		{

            var packetHeader = new PacketHeader
            {
                PacketFormat = (PacketFormat)BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(0, 2)),    // 2019 2 byte
                GameMajorVersion = input[2],    // Game major version - "X.00" 1 byte
                GameMinorVersion = input[3],     // Game minor version - "1.XX" 1 byte
                PacketVersion = input[4],        // Version of this packet type, all start from 1 1 byte
                PacketId = (PacketType)input[5],      // Identifier for the packet type, see below (byte PacketId convert to enum) 1 byte
                SessionUID = BinaryPrimitives.ReadUInt64LittleEndian(input.Slice(6, 8)),           // Unique identifier for the session 8 byte
                SessionTime = BitConverter.ToSingle(input.Slice(14, 4)),       // Session timestamp 4 byte
                FrameIdentifier = BinaryPrimitives.ReadUInt32LittleEndian(input.Slice(18, 4)),      // Identifier for the frame the input was retrieved on 4 byte
                PlayerCarIndex = input[22],    // Index of player's car in the array 1 byte
                SecondPlayerCarIndex = input[23]
            };


            return packetHeader;

        }
    }
}
