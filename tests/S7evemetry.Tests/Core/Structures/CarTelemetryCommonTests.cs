using FluentAssertions;
using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Tests.Core.Structures.MockStructures;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace S7evemetry.Tests.Core.Structures
{
    public class CarTelemetryCommonTests
    {
        private readonly Random _random;

        public CarTelemetryCommonTests()
        {
            _random = new Random();
        }

        [Fact]
        public void CarTelemetrySize()
        {
            var result = CarTelemetry.Size;
            result.Should().Be(62);
        }

        [Fact]
        public void CarTelemetryWrongSize()
        {
            var result = CarTelemetry.Read(new byte[142]);
            result.Should().BeNull();
        }


        [Fact]
        public void CarTelemetryRead()
        {
            IEnumerable<byte> data = new List<byte>();

            data = data.Concat(BitConverter.GetBytes((ushort)0));

            for (var i = 0; i < 3; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((float)(mantissa * exponent)));
            }

            data = data.Concat(new byte[] { 14, 15 });

            data = data.Concat(BitConverter.GetBytes((ushort)16));

            data = data.Concat(new byte[] { 0, 19 });

            for (var i = 0; i < 13; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((ushort)(mantissa * exponent)));
            }

            for (var i = 0; i < 4; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((float)(mantissa * exponent)));
            }

            var spanInput = new Span<byte>(data.ToArray());
            var result = CarTelemetry.Read(spanInput);
            result.Should().NotBeNull();
            if (result != null)
            {
                result.Speed.Should().Be(0);
                result.Throttle.Should().Be(BitConverter.ToSingle(spanInput.Slice(2, 4)));
                result.Steer.Should().Be(BitConverter.ToSingle(spanInput.Slice(6, 4)));
                result.Brake.Should().Be(BitConverter.ToSingle(spanInput.Slice(10, 4)));
                result.Clutch.Should().Be(14);
                result.Gear.Should().Be(15);
                result.EngineRPM.Should().Be(16);
                result.DRS.Should().Be(false);
                result.RevLightsPercent.Should().Be(19);
                result.BrakesTemperature[0].Should().Be(BinaryPrimitives.ReadUInt16LittleEndian(spanInput.Slice(20, 2)));
                result.TyresSurfaceTemperature[0].Should().Be(BinaryPrimitives.ReadUInt16LittleEndian(spanInput.Slice(28, 2)));
                result.TyresInnerTemperature[0].Should().Be(BinaryPrimitives.ReadUInt16LittleEndian(spanInput.Slice(36, 2)));
                result.EngineTemperature.Should().Be(BinaryPrimitives.ReadUInt16LittleEndian(spanInput.Slice(44, 2)));
                result.TyresPressure[0].Should().Be(BitConverter.ToSingle(spanInput.Slice(46, 4)));
            }
        }
    }
}
