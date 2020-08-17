using FluentAssertions;
using S7evemetry.Core.Packets.F1;
using Xunit;

namespace S7evemetry.Tests.Core.Packets.F1
{
    public class LapDataTests
    {
        [Fact]
        public void LapDataSize()
        {
            var result = LapData.Size;
            result.Should().Be(0);
        }
    }
}
