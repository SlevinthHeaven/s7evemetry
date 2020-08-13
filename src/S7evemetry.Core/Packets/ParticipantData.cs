using System;

namespace S7evemetry.Core.Packets
{
    /// <summary>
    /// The base packet data which comes with each Participant PacketType
    /// </summary>
    public class ParticipantData
    {
        /// <summary>
        /// Number of active cars in the data – should match number of cars on HUD
        /// </summary>
        public byte NumActiveCars;

        /// <summary>
        /// Size in bytes of the base data contained in the Participant PacketType
        /// </summary>
        public static int Size { get; } = 1;

        /// <summary>
        /// Read motion data from the input
        /// </summary>
        /// <param name="input">A Span of byte to be deserialized</param>
        /// <returns>The ParticipantData</returns>
        public static ParticipantData Read(Span<byte> input)
        {
            return new ParticipantData
            {
                NumActiveCars = input[0],
            };
        }
    }
}
