using FluentAssertions;
using S7evemetry.Core.Helpers;
using Xunit;

namespace S7evemetry.Tests.Core.Helpers
{
    public class TrackHelperTests
    {

        [Theory]
        [InlineData(0, "Melbourne")]
        [InlineData(1, "Paul Ricard")]
        [InlineData(2, "Shanghai")]
        [InlineData(3, "Sakhir (Bahrain)")]
        [InlineData(4, "Catalunya")]
        [InlineData(5, "Monaco")]
        [InlineData(6, "Montreal")]
        [InlineData(7, "Silverstone")]
        [InlineData(8, "Hockenheim")]
        [InlineData(9, "Hungaroring")]
        [InlineData(10, "Spa")]
        [InlineData(11, "Monza")]
        [InlineData(12, "Singapore")]
        [InlineData(13, "Suzuka")]
        [InlineData(14, "Abu Dhabi")]
        [InlineData(15, "Texas")]
        [InlineData(16, "Brazil")]
        [InlineData(17, "Austria")]
        [InlineData(18, "Sochi")]
        [InlineData(19, "Mexico")]
        [InlineData(20, "Baku (Azerbaijan)")]
        [InlineData(21, "Sakhir Short")]
        [InlineData(22, "Silverstone Short")]
        [InlineData(23, "Texas Short")]
        [InlineData(24, "Suzuka Short")]
        [InlineData(25, "Hanoi")]
        [InlineData(26, "Zandvoort")]
        [InlineData(27, "Unknown")]
        public void SurfaceTests(int id, string expected)
        {
            var result = TrackHelper.GetTrackById(id);
            result.Should().Be(expected);
        }
    }
}
