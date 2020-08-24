using FluentAssertions;
using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Tests.Core.Structures.MockStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace S7evemetry.Tests.Core.Structures
{
    public class CarLapCommonTests
    {
        private readonly Random _random;

        public CarLapCommonTests()
        {
            _random = new Random();
        }

        [Fact]
        public void CarLapSize()
        {
            var result = CarLap.Size;
            result.Should().Be(29);
        }

        [Fact]
        public void CarLapWrongSize()
        {
            var result = CarLap.Read(new byte[121]);
            result.Should().BeNull();
        }


        [Theory]
        [InlineData(PitStatus.None, Sector.Sector1, true, DriverStatus.InGarage, ResultStatus.Active)]
        [InlineData(PitStatus.InPitArea, Sector.Sector2, false, DriverStatus.FlyingLap, ResultStatus.Disqualified)]
        [InlineData(PitStatus.Pitting, Sector.Sector3, true, DriverStatus.InLap, ResultStatus.Finished)]
        [InlineData(PitStatus.None, Sector.Sector1, true, DriverStatus.OnTrack, ResultStatus.Inactive)]
        [InlineData(PitStatus.None, Sector.Sector1, true, DriverStatus.OutLap, ResultStatus.Invalid)]
        [InlineData(PitStatus.None, Sector.Sector1, true, DriverStatus.InGarage, ResultStatus.NotClassified)]
        [InlineData(PitStatus.None, Sector.Sector1, true, DriverStatus.InGarage, ResultStatus.Retired)]
        public void CarLapRead(PitStatus pitStatus, Sector sector, bool currentLapInvalid, DriverStatus driverStatus, ResultStatus resultStatus)
        {
            IEnumerable<byte> data = new List<byte>();
            for (var i = 0; i < 5; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((float)(mantissa * exponent)));
            }

            data = data.Concat(new byte[] { 1, 2 });
            data = data.Concat(new byte[] { (byte)pitStatus });
            data = data.Concat(new byte[] { (byte)sector });
            data = data.Concat(new byte[] { Convert.ToByte(currentLapInvalid) });
            data = data.Concat(new byte[] { 6, 7 });
            data = data.Concat(new byte[] { (byte)driverStatus });
            data = data.Concat(new byte[] { (byte)resultStatus });


            var spanInput = new Span<byte>(data.ToArray());
            var result = CarLap.Read(spanInput);
            result.Should().NotBeNull();
            if (result != null)
            {
                result.LastLapTime.Should().Be(BitConverter.ToSingle(spanInput.Slice(0, 4)));
                result.CurrentLapTime.Should().Be(BitConverter.ToSingle(spanInput.Slice(4, 4)));
                result.LapDistance.Should().Be(BitConverter.ToSingle(spanInput.Slice(8, 4)));
                result.TotalDistance.Should().Be(BitConverter.ToSingle(spanInput.Slice(12, 4)));
                result.SafetyCarDelta.Should().Be(BitConverter.ToSingle(spanInput.Slice(16, 4)));
                result.CarPosition.Should().Be(1);
                result.CurrentLapNum.Should().Be(2);
                result.PitStatus.Should().Be(pitStatus);
                result.Sector.Should().Be(sector);
                result.CurrentLapInvalid.Should().Be(currentLapInvalid);
                result.Penalties.Should().Be(6);
                result.GridPosition.Should().Be(7);
                result.DriverStatus.Should().Be(driverStatus);
                result.ResultStatus.Should().Be(resultStatus);
            }
        }
    }
}
