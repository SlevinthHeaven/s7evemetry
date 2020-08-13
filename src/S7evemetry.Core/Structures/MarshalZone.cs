using S7evemetry.Core.Enums;
using System;

namespace S7evemetry.Core.Structures
{
    public class MarshalZone
	{
		/// <summary>
		/// Fraction (0..1) of way through the lap the marshal zone starts
		/// </summary>
		public float ZoneStart { get; set; }

		/// <summary>
		/// -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
		/// </summary>
		public ZoneFlag ZoneFlag { get; set; }

		/// <summary>
		/// Size of the MarshalZone data
		/// </summary>
		public static int Size { get; } = 5;

		/// <summary>
		/// Read marshal zone data from the input
		/// </summary>
		/// <param name="input">A Span of byte to be deserialized</param>
		/// <returns>The MarshalZone</returns>
		public static MarshalZone Read(Span<byte> input)
		{
			return new MarshalZone
			{
				ZoneStart = BitConverter.ToSingle(input.Slice(0, 4)),
				ZoneFlag = (ZoneFlag)input[4]
			};
		}
	}
}
