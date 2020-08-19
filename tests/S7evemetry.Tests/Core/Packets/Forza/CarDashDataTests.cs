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
        [Fact]
        public void CarDashDataSize()
        {
            var result = CarDashData.Size;
            result.Should().Be(79);
        }

        [Fact]
        public void MotionDataWrongSize()
        {
            var result = CarDashData.Read(new byte[121]);
            result.Should().BeNull();
        }


        [Fact]
        public void MotionDataRead()
        {
            //IEnumerable<byte> data = new List<byte>();
            //for (var i = 0; i < 30; i++)
            //{
            //    double mantissa = (_random.NextDouble() * 2.0) - 1.0;
            //    // choose -149 instead of -126 to also generate subnormal floats (*)
            //    double exponent = Math.Pow(2.0, _random.Next(-126, 128));
            //    data = data.Concat(BitConverter.GetBytes((float)(mantissa * exponent)));
            //}

            //var spanInput = new Span<byte>(data.ToArray());
            //var result = CarDashData.Read(spanInput);
            //result.Should().NotBeNull();
            //if (result != null)
            //{
              
            //}
        }
    }
}
