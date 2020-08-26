using System;

namespace S7evemetry.Core.Structures
{

    /// <summary>
    /// CarSetup data for each Car
    /// </summary>
    public class CarSetupCommon
    {
        /// <summary>
        /// Front wing aero
        /// </summary>
        public byte FrontWing { get; set; }

        /// <summary>
        /// Rear wing aero
        /// </summary>
        public byte RearWing { get; set; }

        /// <summary>
        /// Differential adjustment on throttle (percentage)
        /// </summary>
        public byte OnThrottle { get; set; }

        /// <summary>
        /// Differential adjustment off throttle (percentage)
        /// </summary>
        public byte OffThrottle { get; set; }

        /// <summary>
        /// Front camber angle (suspension geometry)
        /// </summary>
        public float FrontCamber { get; set; }

        /// <summary>
        /// Rear camber angle (suspension geometry)
        /// </summary>
        public float RearCamber { get; set; }

        /// <summary>
        /// Front toe angle (suspension geometry)
        /// </summary>
        public float FrontToe { get; set; }

        /// <summary>
        /// Rear toe angle (suspension geometry)
        /// </summary>
        public float RearToe { get; set; }

        /// <summary>
        /// Front suspension
        /// </summary>
        public byte FrontSuspension { get; set; }

        /// <summary>
        /// Rear suspension
        /// </summary>
        public byte RearSuspension { get; set; }

        /// <summary>
        /// Front anti-roll bar
        /// </summary>
        public byte FrontAntiRollBar { get; set; }

        /// <summary>
        /// Front anti-roll bar
        /// </summary>
        public byte RearAntiRollBar { get; set; }

        /// <summary>
        /// Front ride height
        /// </summary>
        public byte FrontSuspensionHeight { get; set; }

        /// <summary>
        /// Rear ride height
        /// </summary>
        public byte RearSuspensionHeight { get; set; }

        /// <summary>
        /// Brake pressure (percentage)
        /// </summary>
        public byte BrakePressure { get; set; }

        /// <summary>
        /// Brake bias (percentage)
        /// </summary>
        public byte BrakeBias { get; set; }

        /// <summary>
        /// Ballast
        /// </summary>
        public byte Ballast { get; set; }

        /// <summary>
        /// Fuel load
        /// </summary>
        public float FuelLoad { get; set; }

        public static int Size { get; } = 33;

        public static int GapStartByte { get; } = 28;

        /// <summary>
        /// Reads the common data for CarSetup.
        /// </summary>
        /// <typeparam name="T">An inherited Type of CarSetupCommon</typeparam>
        /// <param name="input">
        /// The Span of byte which contain the common CarSetup data packet
        /// </param>
        /// <param name="gapSize">There is a gap where extra data should be placed, instead of 2 spans we supply a gap</param>
        /// <returns>Instance of T with deserialized data from input</returns>
        protected static T? Read<T>(Span<byte> input, int gapSize) where T: CarSetupCommon, new()
        {
            if (input.Length != Size + gapSize) return null;

            gapSize += GapStartByte;

            return new T
            {
                FrontWing = input[0], // 1 byte
                RearWing = input[1], // 2 byte
                OnThrottle = input[2], // 3 byte
                OffThrottle = input[3], // 4 byte
                FrontCamber = BitConverter.ToSingle(input.Slice(4, 4)), // 8 byte
                RearCamber = BitConverter.ToSingle(input.Slice(8, 4)), // 12 byte
                FrontToe = BitConverter.ToSingle(input.Slice(12, 4)), // 16 byte
                RearToe = BitConverter.ToSingle(input.Slice(16, 4)), // 20 byte
                FrontSuspension = input[20], // 21 byte
                RearSuspension = input[21], // 22 byte
                FrontAntiRollBar = input[22], // 23 byte
                RearAntiRollBar = input[23], // 24 byte
                FrontSuspensionHeight = input[24], // 25 byte
                RearSuspensionHeight = input[25], // 26 byte
                BrakePressure = input[26], // 27 byte
                BrakeBias = input[27], // 28 byte
                
                Ballast = input[gapSize], // 29 byte
                FuelLoad = BitConverter.ToSingle(input.Slice(gapSize + 1, 4)) // 33 byte
            };
        }
    }
}
