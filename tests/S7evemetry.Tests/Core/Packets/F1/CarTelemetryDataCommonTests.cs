using FluentAssertions;
using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Tests.Core.Packets.F1.MockPackets;
using System;
using Xunit;

namespace S7evemetry.Tests.Core.Packets.F1
{
    public class CarTelemetryDataCommonTests
    {
        [Fact]
        public void CarTelemetryDataCommonSize()
        {
            var result = CarTelemetryDataCommon.Size;
            result.Should().Be(4);
        }

        [Fact]
        public void CarTelemetryZeroSize()
        {
            var result = CarTelemetryData.Read(new byte[0]);
            result.Should().BeNull();
        }

        [Theory]
        [InlineData(Buttons.A ^ Buttons.B, 5)]
        [InlineData(Buttons.None, 0)]
        [InlineData(Buttons.A ^ Buttons.Y, 3)]
        [InlineData(Buttons.B ^ Buttons.X, 12)]
        [InlineData(Buttons.B ^ Buttons.X ^ Buttons.LB, 524)]
        [InlineData(Buttons.B ^ Buttons.X ^ Buttons.LT, 2060)]
        [InlineData(Buttons.A ^ Buttons.B ^ Buttons.LT ^ Buttons.LeftStick, 10245)]

        public void CarTelemetryDataCommonRead(Buttons input, int expected)
        {
            byte[] bytes = BitConverter.GetBytes((uint)input);
            var result = CarTelemetryData.Read(bytes);
            result.Should().NotBeNull().And.Subject.As<CarTelemetryData>().ButtonStatus.Should().Be(expected);
        }
    }
}
