using FluentAssertions;
using S7evemetry.Core.Packets.Forza;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace S7evemetry.Tests.Core.Packets.Forza
{
    public class CarDashDataTests
    {
        private readonly Random _random;

        public CarDashDataTests()
        {
            _random = new Random();
        }

        [Fact]
        public void CarDashDataSize()
        {
            var result = CarDashData.Size;
            result.Should().Be(79);
        }

        [Fact]
        public void CarDashDataWrongSize()
        {
            var result = CarDashData.Read(new byte[121]);
            result.Should().BeNull();
        }


        [Fact]
        public void CarDashDataRead()
        {
            IEnumerable<byte> data = new List<byte>();
            for (var i = 0; i < 17; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((float)(mantissa * exponent)));
            }

            data = data.Concat(BitConverter.GetBytes((ushort)_random.Next(ushort.MinValue, ushort.MaxValue)));

            data = data.Concat(new byte[] { 1, 2, 3, 4, 5, 6 });
            data = data.Concat(new byte[] { 7, 8, 9 });
            
            var spanInput = new Span<byte>(data.ToArray());
            var result = CarDashData.Read(spanInput);
            result.Should().NotBeNull();
            if (result != null)
            {
                result.PositionX.Should().Be(BitConverter.ToSingle(spanInput.Slice(0, 4)));
                result.PositionY.Should().Be(BitConverter.ToSingle(spanInput.Slice(4, 4)));
                result.PositionZ.Should().Be(BitConverter.ToSingle(spanInput.Slice(8, 4)));
                result.Speed.Should().Be(BitConverter.ToSingle(spanInput.Slice(12, 4)));
                result.Power.Should().Be(BitConverter.ToSingle(spanInput.Slice(16, 4)));
                result.Torque.Should().Be(BitConverter.ToSingle(spanInput.Slice(20, 4)));
                result.TireTempFrontLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(24, 4)));
                result.TireTempFrontRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(28, 4)));
                result.TireTempRearLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(32, 4)));
                result.TireTempRearRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(36, 4)));
                result.Boost.Should().Be(BitConverter.ToSingle(spanInput.Slice(40, 4)));
                result.Fuel.Should().Be(BitConverter.ToSingle(spanInput.Slice(44, 4)));
                result.DistanceTraveled.Should().Be(BitConverter.ToSingle(spanInput.Slice(48, 4)));
                result.BestLap.Should().Be(BitConverter.ToSingle(spanInput.Slice(52, 4)));
                result.LastLap.Should().Be(BitConverter.ToSingle(spanInput.Slice(56, 4)));
                result.CurrentLap.Should().Be(BitConverter.ToSingle(spanInput.Slice(60, 4)));
                result.CurrentRaceTime.Should().Be(BitConverter.ToSingle(spanInput.Slice(64, 4)));
                result.LapNumber.Should().Be(BitConverter.ToUInt16(spanInput.Slice(68, 2)));
                result.RacePosition.Should().Be(1);
                result.Accelerator.Should().Be(2);
                result.Brake.Should().Be(3);
                result.Clutch.Should().Be(4);
                result.HandBrake.Should().Be(5);
                result.Gear.Should().Be(6);
                result.Steer.Should().Be(7);
                result.NormalizedDrivingLine.Should().Be(8);
                result.NormalizedAIBrakeDifference.Should().Be(9);
            }
        }
    }
}
