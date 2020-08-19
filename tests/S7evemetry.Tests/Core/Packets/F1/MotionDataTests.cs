using FluentAssertions;
using S7evemetry.Core.Packets.F1;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace S7evemetry.Tests.Core.Packets.F1
{
    public class MotionDataTests
    {
        private readonly Random _random;

        public MotionDataTests()
        {
            _random = new Random();
        }

        [Fact]
        public void MotionDataSize()
        {
            var result = MotionData.Size;
            result.Should().Be(120);
        }

        [Fact]
        public void MotionDataWrongSize()
        {
            var result = MotionData.Read(new byte[121]);
            result.Should().BeNull();
        }


        [Fact]
        public void MotionDataRead()
        {
            IEnumerable<byte> data = new List<byte>();
            for (var i = 0; i < 30; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((float)(mantissa * exponent)));
            }

            var spanInput = new Span<byte>(data.ToArray());
            var result = MotionData.Read(spanInput);
            result.Should().NotBeNull();
            if (result != null)
            {
                result.SuspensionPosition[0].Should().Be(BitConverter.ToSingle(spanInput.Slice(0, 4)));
                result.SuspensionPosition[1].Should().Be(BitConverter.ToSingle(spanInput.Slice(4, 4)));
                result.SuspensionPosition[2].Should().Be(BitConverter.ToSingle(spanInput.Slice(8, 4)));
                result.SuspensionPosition[3].Should().Be(BitConverter.ToSingle(spanInput.Slice(12, 4)));
                result.SuspensionVelocity[0].Should().Be(BitConverter.ToSingle(spanInput.Slice(16, 4)));
                result.SuspensionVelocity[1].Should().Be(BitConverter.ToSingle(spanInput.Slice(20, 4)));
                result.SuspensionVelocity[2].Should().Be(BitConverter.ToSingle(spanInput.Slice(24, 4)));
                result.SuspensionVelocity[3].Should().Be(BitConverter.ToSingle(spanInput.Slice(28, 4)));
                result.SuspensionAcceleration[0].Should().Be(BitConverter.ToSingle(spanInput.Slice(32, 4)));
                result.SuspensionAcceleration[1].Should().Be(BitConverter.ToSingle(spanInput.Slice(36, 4)));
                result.SuspensionAcceleration[2].Should().Be(BitConverter.ToSingle(spanInput.Slice(40, 4)));
                result.SuspensionAcceleration[3].Should().Be(BitConverter.ToSingle(spanInput.Slice(44, 4)));
                result.WheelSpeed[0].Should().Be(BitConverter.ToSingle(spanInput.Slice(48, 4)));
                result.WheelSpeed[1].Should().Be(BitConverter.ToSingle(spanInput.Slice(52, 4)));
                result.WheelSpeed[2].Should().Be(BitConverter.ToSingle(spanInput.Slice(56, 4)));
                result.WheelSpeed[3].Should().Be(BitConverter.ToSingle(spanInput.Slice(60, 4)));
                result.WheelSlip[0].Should().Be(BitConverter.ToSingle(spanInput.Slice(64, 4)));
                result.WheelSlip[1].Should().Be(BitConverter.ToSingle(spanInput.Slice(68, 4)));
                result.WheelSlip[2].Should().Be(BitConverter.ToSingle(spanInput.Slice(72, 4)));
                result.WheelSlip[3].Should().Be(BitConverter.ToSingle(spanInput.Slice(76, 4)));
                result.LocalVelocityX.Should().Be(BitConverter.ToSingle(spanInput.Slice(80, 4)));
                result.LocalVelocityY.Should().Be(BitConverter.ToSingle(spanInput.Slice(84, 4)));
                result.LocalVelocityZ.Should().Be(BitConverter.ToSingle(spanInput.Slice(88, 4)));
                result.AngularVelocityX.Should().Be(BitConverter.ToSingle(spanInput.Slice(92, 4)));
                result.AngularVelocityY.Should().Be(BitConverter.ToSingle(spanInput.Slice(96, 4)));
                result.AngularVelocityZ.Should().Be(BitConverter.ToSingle(spanInput.Slice(100, 4)));
                result.AngularAccelerationX.Should().Be(BitConverter.ToSingle(spanInput.Slice(104, 4)));
                result.AngularAccelerationY.Should().Be(BitConverter.ToSingle(spanInput.Slice(108, 4)));
                result.AngularAccelerationZ.Should().Be(BitConverter.ToSingle(spanInput.Slice(112, 4)));
                result.FrontWheelsAngle.Should().Be(BitConverter.ToSingle(spanInput.Slice(116, 4)));
            }
        }
    }
}
