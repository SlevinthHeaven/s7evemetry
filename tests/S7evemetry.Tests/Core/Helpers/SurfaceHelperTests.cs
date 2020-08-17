using FluentAssertions;
using S7evemetry.Core.Helpers;
using Xunit;

namespace S7evemetry.Tests.Core.Helpers
{
    public class SurfaceHelperTests
    {
        [Theory]
        [InlineData(0, "Tarmac")]
        [InlineData(1, "Rumble strip")]
        [InlineData(2, "Concrete")]
        [InlineData(3, "Rock")]
        [InlineData(4, "Gravel")]
        [InlineData(5, "Mud")]
        [InlineData(6, "Sand")]
        [InlineData(7, "Grass")]
        [InlineData(8, "Water")]
        [InlineData(9, "Cobblestone")]
        [InlineData(10, "Metal")]
        [InlineData(11, "Ridged")]
        [InlineData(12, "Unknown")]
        public void SurfaceTests(int id, string expected)
        {
            var result = SurfaceHelper.GetSurfaceById(id);
            result.Should().Be(expected);
        }
    }
}
