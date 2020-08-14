using S7evemetry.Core.Structures;
using System.Collections.Generic;

namespace S7evemetry.Core.Packets.F1
{
    /// <summary>
    /// Each UDP packet from the Codemasters games has a distinct structure.
    /// This class covers the structure of Header, a List of Car data and base packet data
    /// </summary>
    /// <typeparam name="PacketHeader">The header sent with the UDP packet</typeparam>
    /// <typeparam name="MainPacketData">Base packet data</typeparam>
    /// <typeparam name="CarPacketData">The data sent for each Car</typeparam>
    public class PacketData<PacketHeader, MainPacketData, CarPacketData> 
        where MainPacketData : new() 
        where PacketHeader : PacketHeaderCommon, new()
    {
        public PacketHeader Header { get; set; } = new PacketHeader();

        public List<CarPacketData> CarData { get; set; } = new List<CarPacketData>();

        public MainPacketData Data { get; set; } = new MainPacketData();
    }

    /// <summary>
    /// Each UDP packet from the Codemasters games has a distinct structure.
    /// This class covers the structure of Header and base packet data
    /// </summary>
    /// <typeparam name="PacketHeader">The header sent with the UDP packet</typeparam>
    /// <typeparam name="MainPacketData">Base packet data</typeparam>
    public class PacketData<PacketHeader, MainPacketData>
        where MainPacketData : new()
        where PacketHeader : PacketHeaderCommon, new()
    {
        public PacketHeader Header { get; set; } = new PacketHeader();

        public MainPacketData Data { get; set; } = new MainPacketData();
    }
}
