using FluentAssertions;
using S7evemetry.Core.Packets.Forza;
using S7evemetry.Core.Structures;
using Xunit;

namespace S7evemetry.Tests.Core.Packets.Forza
{
    public class PacketDataTests
    {
        [Fact]
        public void PacketDataSledAndDash()
        {
            var result = new PacketData<SledData, CarDashData>();
            result.Sled.Should().NotBeNull();
            result.CarDash.Should().NotBeNull();

            result.Sled = new SledData();
            result.CarDash = new CarDashData();
        }

        [Fact]
        public void PacketDataSledOnly()
        {
            var result = new PacketData<SledData>();
            result.Sled.Should().NotBeNull();

            result.Sled = new SledData();
        }

    }
}
