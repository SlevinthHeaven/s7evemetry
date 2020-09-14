using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Helpers;
using System;
using System.Text;

namespace S7evemetry.Core.Structures
{
    public class ParticipantCommon
    {

        /// <summary>
        /// Whether the vehicle is AI (1) or Human (0) controlled
        /// </summary>
        public bool AiControlled { get; set; }

        /// <summary>
        /// byte of DriverId converted to string
        /// </summary>
        public string Driver { get; set; } = string.Empty;

        /// <summary>
        /// byte of TeamId converted to string
        /// </summary>  
        public string Team { get; set; } = string.Empty;

        public byte RaceNumber { get; set; }

        /// <summary>
        /// Nationality of the driver
        /// byte of Nationality converted to string
        /// </summary>  
        public string Nationality { get; set; } = string.Empty;

        /// <summary>
        /// Name of participant in UTF-8 format – null terminated [48 bytes long]
        /// Will be truncated with … (U+2026) if too long
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Size of the Participant data
        /// </summary>
        public static int Size { get; } = 54;

        /// <summary>
        /// Reads the common data for Participant.
        /// </summary>
        /// <typeparam name="T">An inherited Type of ParticipantCommon</typeparam>
        /// <param name="input">
        /// The Span of byte which contain the common Participant data packet
        /// </param>
        /// <returns>Instance of T with deserialized data from input</returns>
        protected static T Read<T>(Span<byte> input) where T : ParticipantCommon, new()
        {
            return new T
            {
                AiControlled = Convert.ToBoolean(input[0]),
                RaceNumber = input[3],
                Name = Encoding.UTF8.GetString(input.Slice(5, 48)).Trim('\0')
            };
        }
    }
}
