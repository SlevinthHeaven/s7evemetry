using FluentAssertions;
using S7evemetry.Core.Packets.F1;
using Xunit;

namespace S7evemetry.Tests.Core.Packets.F1
{
    public class CarStatusDataTests
    {
        [Fact]
        public void CarStatusDataSize()
        {
            var result = CarStatusData.Size;
            result.Should().Be(0);
        }
    }
}
