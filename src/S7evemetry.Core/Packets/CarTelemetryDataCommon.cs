using System;
using System.Buffers.Binary;

namespace S7evemetry.Core.Packets
{
    /// <summary>
    /// CarTelemetryData packet received from UDP, this is the 
    /// Common (used in multiple games) data class.
    /// </summary>
    public abstract class CarTelemetryDataCommon
    {
        /// <summary>
        /// Bit flags specifying which buttons are being pressed currently
        /// 
        /// Bit Flag	Button
        /// 0x0001	Cross or A
        /// 0x0002	Triangle or Y
        /// 0x0004	Circle or B
        /// 0x0008	Square or X
        /// 0x0010	D-pad Left
        /// 0x0020	D-pad Right
        /// 0x0040	D-pad Up
        /// 0x0080	D-pad Down
        /// 0x0100	Options or Menu
        /// 0x0200	L1 or LB
        /// 0x0400	R1 or RB
        /// 0x0800	L2 or LT
        /// 0x1000	R2 or RT
        /// 0x2000	Left Stick Click
        /// 0x4000	Right Stick Click
        /// </summary>
        public uint ButtonStatus { get; set; }

        public static int Size { get; } = 4;

        /// <summary>
        /// Reads the common data for CarTelemetryData packets.
        /// </summary>
        /// <typeparam name="T">An inherited Type of CarTelemetryDataCommon</typeparam>
        /// <param name="input">
        /// The Span of byte which contain the common Telemetry data packet
        /// </param>
        /// <returns>Instance of T with deserialized data from input</returns>
        protected static T Read<T>(Span<byte> input) where T : CarTelemetryDataCommon, new()
        {
            if (input.IsEmpty) return new T();


            return new T
            {
                ButtonStatus = BinaryPrimitives.ReadUInt32LittleEndian(input)
            };

        }
    }
}
