using S7evemetry.F1_2017.Packets;
using System;

namespace S7evemetry.F1_2017.Readers
{
    public class UdpPacketDataReader
    {
        public UdpPacketData? Read(Span<byte> input)
        {
            if (input.Length != UdpPacketData.Size) return null;
            return UdpPacketData.Read(input);
        }
    }
}
