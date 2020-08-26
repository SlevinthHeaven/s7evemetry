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
    public class CarSetupCommonTests
    {
        private readonly Random _random;

        public CarSetupCommonTests()
        {
            _random = new Random();
        }

        [Fact]
        public void CarSetupSize()
        {
            var result = CarSetup.Size;
            result.Should().Be(33);
        }

        [Fact]
        public void CarSetupWrongSize()
        {
            var result = CarSetup.Read(new byte[142]);
            result.Should().BeNull();
        }


        [Fact]
        public void CarSetupRead()
        {
            IEnumerable<byte> data = new List<byte>();

            data = data.Concat(new byte[] { 1, 2, 3, 4 });

            for (var i = 0; i < 4; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((float)(mantissa * exponent)));
            }

            data = data.Concat(new byte[] { 20, 21, 22, 23, 24, 25, 26, 27, 28 });

            for (var i = 0; i < 1; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((float)(mantissa * exponent)));
            }

            var spanInput = new Span<byte>(data.ToArray());
            var result = CarSetup.Read(spanInput);
            result.Should().NotBeNull();
            if (result != null)
            {
                result.FrontWing.Should().Be(spanInput[0]);
                result.RearWing.Should().Be(spanInput[1]);
                result.OnThrottle.Should().Be(spanInput[2]);
                result.OffThrottle.Should().Be(spanInput[3]);
                result.FrontCamber.Should().Be(BitConverter.ToSingle(spanInput.Slice(4, 4)));
                result.RearCamber.Should().Be(BitConverter.ToSingle(spanInput.Slice(8, 4)));
                result.FrontToe.Should().Be(BitConverter.ToSingle(spanInput.Slice(12, 4)));
                result.RearToe.Should().Be(BitConverter.ToSingle(spanInput.Slice(16, 4)));
                result.FrontSuspension.Should().Be(spanInput[20]);
                result.RearSuspension.Should().Be(spanInput[21]);
                result.FrontAntiRollBar.Should().Be(spanInput[22]);
                result.RearAntiRollBar.Should().Be(spanInput[23]);
                result.FrontSuspensionHeight.Should().Be(spanInput[24]);
                result.RearSuspensionHeight.Should().Be(spanInput[25]);
                result.BrakePressure.Should().Be(spanInput[26]);
                result.BrakeBias.Should().Be(spanInput[27]);
                result.Ballast.Should().Be(spanInput[28]);
                result.FuelLoad.Should().Be(BitConverter.ToSingle(spanInput.Slice(29, 4)));
            }
        }
    }
}
