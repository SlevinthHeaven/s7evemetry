using S7evemetry.Core.Enums.F1;
using System;
using System.Buffers.Binary;

namespace S7evemetry.Core.Packets.F1
{
    /// <summary>
    /// CarTelemetryData packet received from UDP, this is the 
    /// Common (used in multiple games) data class.
    /// </summary>
    public abstract class CarTelemetryDataCommon
    {
        /// <summary>
        /// Bit flags specifying which buttons are being pressed currently
        /// </summary>
        public Buttons ButtonStatus { get; set; }

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
                ButtonStatus = (Buttons)BinaryPrimitives.ReadUInt32LittleEndian(input)
            };

        }
    }
}
