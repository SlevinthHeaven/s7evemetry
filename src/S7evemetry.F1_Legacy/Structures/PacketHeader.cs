using S7evemetry.Core.Structures;
using System;

namespace S7evemetry.F1_Legacy.Structures
{
    public class PacketHeader : PacketHeaderCommon
    {
		public static PacketHeader Read(Span<byte> input)
		{
            return Read<PacketHeader>(input);
		}
	}
}
