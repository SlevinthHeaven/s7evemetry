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


        /// <summary>
        /// Reads the common data for CarSetup.
        /// </summary>
        /// <typeparam name="T">An inherited Type of CarSetupCommon</typeparam>
        /// <param name="input">
        /// The Span of byte which contain the common CarSetup data packet
        /// </param>
        /// <param name="gapSize">There is a gap where extra data should be placed, instead of 2 spans we supply a gap</param>
        /// <returns>Instance of T with deserialized data from input</returns>
        protected static T Read<T>(Span<byte> input, int gapSize) where T: CarSetupCommon, new()
        {
            return new T
            {
                FrontWing = input[0], // 1 byte
                RearWing = input[1], // 1 byte
                OnThrottle = input[2], // 1 byte
                OffThrottle = input[3], // 1 byte
                FrontCamber = BitConverter.ToSingle(input.Slice(4, 4)), // 4 byte
                RearCamber = BitConverter.ToSingle(input.Slice(8, 4)), // 4 byte
                FrontToe = BitConverter.ToSingle(input.Slice(12, 4)), // 4 byte
                RearToe = BitConverter.ToSingle(input.Slice(16, 4)), // 4 byte
                FrontSuspension = input[20], // 1 byte
                RearSuspension = input[21], // 1 byte
                FrontAntiRollBar = input[22], // 1 byte
                RearAntiRollBar = input[23], // 1 byte
                FrontSuspensionHeight = input[24], // 1 byte
                RearSuspensionHeight = input[25], // 1 byte
                BrakePressure = input[26], // 1 byte
                BrakeBias = input[27], // 1 byte
                
                Ballast = input[gapSize], // 1 byte
                FuelLoad = BitConverter.ToSingle(input.Slice(gapSize + 1, 4)) // 4 byte
            };
        }
    }
}
