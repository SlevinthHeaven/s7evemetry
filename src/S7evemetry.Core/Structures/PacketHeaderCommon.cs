using S7evemetry.Core.Enums.F1;
using System;
using System.Buffers.Binary;

namespace S7evemetry.Core.Structures
{
    public abstract class PacketHeaderCommon
    {
        /// <summary>
        /// Size of the Packet Header
        /// </summary>
        public int Size { get; } = 21;

        /// <summary>
        /// The GridSize in game, this is used in the readers to add
        /// the correct number of items into the CarData fields
        /// </summary>
        public int GridSize { get; } = 20;

        /// <summary>
        /// Packet Format -> converted from 2018, 2019, 2020 to the enum
        /// </summary>
        public PacketFormat PacketFormat { get; set; }
        /// <summary>
        /// Version of this packet type, all start from 1
        /// </summary>
        public byte PacketVersion { get; set; }
        /// <summary>
        /// Identifier for the packet type (byte PacketId convert to enum)
        /// </summary>
        public PacketType PacketId { get; set; }
        /// <summary>
        /// Unique identifier for the session
        /// </summary>
        public ulong SessionUID { get; set; }
        /// <summary>
        /// Session timestamp
        /// </summary>
        public float SessionTime { get; set; }
        /// <summary>
        /// Identifier for the frame the data was retrieved on
        /// </summary>
        public uint FrameIdentifier { get; set; }
        /// <summary>
        /// Index of player's car in the array
        /// </summary>
        public byte PlayerCarIndex { get; set; }

        /// <summary>
        /// Default read of the Packet Header, can only be used by inherited types
        /// </summary>
        /// <typeparam name="T">The Type of the inherited class</typeparam>
        /// <param name="input">The byte array to deserialize</param>
        /// <returns>a new object of the specified Type(T) </returns>
        protected static T Read<T>(Span<byte> input) where T: PacketHeaderCommon, new()
        {
            return new T
            {
                PacketFormat = (PacketFormat)BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(0,2)),
                PacketVersion = input[2],
                PacketId = (PacketType)input[3],
                SessionUID = BinaryPrimitives.ReadUInt64LittleEndian(input.Slice(4, 8)),
                SessionTime = BitConverter.ToSingle(input.Slice(12, 4)),
                FrameIdentifier = BinaryPrimitives.ReadUInt32LittleEndian(input.Slice(16, 4)),
                PlayerCarIndex = input[20]
            };

        }
    }
}
