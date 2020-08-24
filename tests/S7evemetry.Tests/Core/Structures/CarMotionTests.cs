using FluentAssertions;
using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Core.Structures;
using S7evemetry.Tests.Core.Structures.MockStructures;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace S7evemetry.Tests.Core.Structures
{
    public class CarMotionTests
    {
        private readonly Random _random;

        public CarMotionTests()
        {
            _random = new Random();
        }

        [Fact]
        public void CarMotionSize()
        {
            var result = CarMotion.Size;
            result.Should().Be(60);
        }

        [Fact]
        public void CarMotionWrongSize()
        {
            var result = CarMotion.Read(new byte[61]);
            result.Should().BeNull();
        }


        [Fact]
        public void CarMotionRead()
        {
            IEnumerable<byte> data = new List<byte>();
            for (var i = 0; i < 6; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((float)(mantissa * exponent)));
            }

            for (var i = 0; i < 6; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((ushort)(mantissa * exponent)));
            }

            for (var i = 0; i < 6; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((float)(mantissa * exponent)));
            }



            var spanInput = new Span<byte>(data.ToArray());
            var result = CarMotion.Read(spanInput);
            result.Should().NotBeNull();
            if (result != null)
            {
                result.WorldPositionX.Should().Be(BitConverter.ToSingle(spanInput.Slice(0, 4)));
                result.WorldPositionY.Should().Be(BitConverter.ToSingle(spanInput.Slice(4, 4)));
                result.WorldPositionZ.Should().Be(BitConverter.ToSingle(spanInput.Slice(8, 4)));
                result.WorldVelocityX.Should().Be(BitConverter.ToSingle(spanInput.Slice(12, 4)));
                result.WorldVelocityY.Should().Be(BitConverter.ToSingle(spanInput.Slice(16, 4)));
                result.WorldVelocityZ.Should().Be(BitConverter.ToSingle(spanInput.Slice(20, 4)));

                result.WorldForwardDirX.Should().Be(BinaryPrimitives.ReadInt16LittleEndian(spanInput.Slice(24, 2)));
                result.WorldForwardDirY.Should().Be(BinaryPrimitives.ReadInt16LittleEndian(spanInput.Slice(26, 2)));
                result.WorldForwardDirZ.Should().Be(BinaryPrimitives.ReadInt16LittleEndian(spanInput.Slice(28, 2)));
                result.WorldRightDirX.Should().Be(BinaryPrimitives.ReadInt16LittleEndian(spanInput.Slice(30, 2)));
                result.WorldRightDirY.Should().Be(BinaryPrimitives.ReadInt16LittleEndian(spanInput.Slice(32, 2)));
                result.WorldRightDirZ.Should().Be(BinaryPrimitives.ReadInt16LittleEndian(spanInput.Slice(34, 2)));

                result.GForceLateral.Should().Be(BitConverter.ToSingle(spanInput.Slice(36, 4)));
                result.GForceLongitudinal.Should().Be(BitConverter.ToSingle(spanInput.Slice(40, 4)));
                result.GForceVertical.Should().Be(BitConverter.ToSingle(spanInput.Slice(44, 4)));
                result.Yaw.Should().Be(BitConverter.ToSingle(spanInput.Slice(48, 4)));
                result.Pitch.Should().Be(BitConverter.ToSingle(spanInput.Slice(52, 4)));
                result.Roll.Should().Be(BitConverter.ToSingle(spanInput.Slice(56, 4)));

            }
        }
    }
}
