using FluentAssertions;
using S7evemetry.Core.Helpers;
using S7evemetry.Core.Packets.F1;
using Xunit;

namespace S7evemetry.Tests.Core.Helpers
{
    public class CarSetupDataTests
    {
        [Fact]
        public void CarSetupDataSize()
        {
            var result = CarSetupData.Size;
            result.Should().Be(0);
        }
    }
}
