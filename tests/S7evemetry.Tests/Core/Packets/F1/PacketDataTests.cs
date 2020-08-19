using FluentAssertions;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Core.Structures;
using S7evemetry.Tests.Core.Packets.F1.MockPackets;
using S7evemetry.Tests.Core.Structures.MockStructures;
using Xunit;

namespace S7evemetry.Tests.Core.Packets.F1
{
    public class PacketDataTests
    {
        [Fact]
        public void PacketDataNoCars()
        {
            var result = new PacketData<PacketHeader, SessionData>();
            result.Header.Should().NotBeNull();
            result.Data.Should().NotBeNull();

            result.Header = new PacketHeader();
            result.Data = new SessionData();
        }

        [Fact]
        public void PacketDataWithCars()
        {
            var result = new PacketData<PacketHeader, SessionData, CarMotion>();
            result.Header.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.CarData.Should().NotBeNull();

            result.Header = new PacketHeader();
            result.Data = new SessionData();
        }

    }
}
