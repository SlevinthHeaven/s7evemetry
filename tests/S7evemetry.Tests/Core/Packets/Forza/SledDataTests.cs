using FluentAssertions;
using S7evemetry.Core.Packets.Forza;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace S7evemetry.Tests.Core.Packets.Forza
{
    public class SledDataTests
    {
        private readonly Random _random;

        public SledDataTests()
        {
            _random = new Random();
        }

        [Fact]
        public void SledDataSize()
        {
            var result = SledData.Size;
            result.Should().Be(232);
        }

        [Fact]
        public void SledDataWrongSize()
        {
            var result = SledData.Read(new byte[121]);
            result.Should().BeNull();
        }


        [Fact]
        public void SledDataRead()
        {
            IEnumerable<byte> data = new List<byte>();

            data = data.Concat(BitConverter.GetBytes(0));
            data = data.Concat(BitConverter.GetBytes((uint)0));
            for (var i = 0; i < 51; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((float)(mantissa * exponent)));
            }
            data = data.Concat(BitConverter.GetBytes(1));
            data = data.Concat(BitConverter.GetBytes(2));
            data = data.Concat(BitConverter.GetBytes(3));
            data = data.Concat(BitConverter.GetBytes(4));
            data = data.Concat(BitConverter.GetBytes(5));

            var spanInput = new Span<byte>(data.ToArray());
            var result = SledData.Read(spanInput);
            result.Should().NotBeNull();
            if (result != null)
            {
                result.IsRaceOn.Should().Be(BinaryPrimitives.ReadInt32LittleEndian(spanInput.Slice(0, 4)));
                result.TimestampMS.Should().Be(BinaryPrimitives.ReadUInt32LittleEndian(spanInput.Slice(4, 4)));
                result.EngineMaxRpm.Should().Be(BitConverter.ToSingle(spanInput.Slice(8, 4)));
                result.EngineIdleRpm.Should().Be(BitConverter.ToSingle(spanInput.Slice(12, 4)));
                result.CurrentEngineRpm.Should().Be(BitConverter.ToSingle(spanInput.Slice(16, 4)));
                result.AccelerationX.Should().Be(BitConverter.ToSingle(spanInput.Slice(20, 4)));
                result.AccelerationY.Should().Be(BitConverter.ToSingle(spanInput.Slice(24, 4)));
                result.AccelerationZ.Should().Be(BitConverter.ToSingle(spanInput.Slice(28, 4)));
                result.VelocityX.Should().Be(BitConverter.ToSingle(spanInput.Slice(32, 4)));
                result.VelocityY.Should().Be(BitConverter.ToSingle(spanInput.Slice(36, 4)));
                result.VelocityZ.Should().Be(BitConverter.ToSingle(spanInput.Slice(40, 4)));
                result.AngularVelocityX.Should().Be(BitConverter.ToSingle(spanInput.Slice(44, 4)));
                result.AngularVelocityY.Should().Be(BitConverter.ToSingle(spanInput.Slice(48, 4)));
                result.AngularVelocityZ.Should().Be(BitConverter.ToSingle(spanInput.Slice(52, 4)));
                result.Yaw.Should().Be(BitConverter.ToSingle(spanInput.Slice(56, 4)));
                result.Pitch.Should().Be(BitConverter.ToSingle(spanInput.Slice(60, 4)));
                result.Roll.Should().Be(BitConverter.ToSingle(spanInput.Slice(64, 4)));

                result.NormalizedSuspensionTravelFrontLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(68, 4)));
                result.NormalizedSuspensionTravelFrontRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(72, 4)));
                result.NormalizedSuspensionTravelRearLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(76, 4)));
                result.NormalizedSuspensionTravelRearRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(80, 4)));

                result.TireSlipRatioFrontLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(84, 4)));
                result.TireSlipRatioFrontRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(88, 4)));
                result.TireSlipRatioRearLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(92, 4)));
                result.TireSlipRatioRearRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(96, 4)));

                result.WheelRotationSpeedFrontLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(100, 4)));
                result.WheelRotationSpeedFrontRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(104, 4)));
                result.WheelRotationSpeedRearLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(108, 4)));
                result.WheelRotationSpeedRearRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(112, 4)));
                
                result.WheelOnRumbleStripFrontLeft.Should().Be(BinaryPrimitives.ReadInt32LittleEndian(spanInput.Slice(116, 4)));
                result.WheelOnRumbleStripFrontRight.Should().Be(BinaryPrimitives.ReadInt32LittleEndian(spanInput.Slice(120, 4)));
                result.WheelOnRumbleStripRearLeft.Should().Be(BinaryPrimitives.ReadInt32LittleEndian(spanInput.Slice(124, 4)));
                result.WheelOnRumbleStripRearRight.Should().Be(BinaryPrimitives.ReadInt32LittleEndian(spanInput.Slice(128, 4)));

                result.WheelInPuddleDepthFrontLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(132, 4)));
                result.WheelInPuddleDepthFrontRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(136, 4)));
                result.WheelInPuddleDepthRearLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(140, 4)));
                result.WheelInPuddleDepthRearRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(144, 4)));


                result.SurfaceRumbleFrontLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(148, 4)));
                result.SurfaceRumbleFrontRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(152, 4)));
                result.SurfaceRumbleRearLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(156, 4)));
                result.SurfaceRumbleRearRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(160, 4)));


                result.TireSlipAngleFrontLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(164, 4)));
                result.TireSlipAngleFrontRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(168, 4)));
                result.TireSlipAngleRearLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(172, 4)));
                result.TireSlipAngleRearRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(176, 4)));


                result.TireCombinedSlipFrontLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(180, 4)));
                result.TireCombinedSlipFrontRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(184, 4)));
                result.TireCombinedSlipRearLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(188, 4)));
                result.TireCombinedSlipRearRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(192, 4)));


                result.SuspensionTravelMetersFrontLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(196, 4)));
                result.SuspensionTravelMetersFrontRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(200, 4)));
                result.SuspensionTravelMetersRearLeft.Should().Be(BitConverter.ToSingle(spanInput.Slice(204, 4)));
                result.SuspensionTravelMetersRearRight.Should().Be(BitConverter.ToSingle(spanInput.Slice(208, 4)));

                result.CarOrdinal.Should().Be(1);
                result.CarClass.Should().Be(2);
                result.CarPerformanceIndex.Should().Be(3);
                result.DriveTrainType.Should().Be(4);
                result.NumCylinders.Should().Be(5);

            }
        }
    }
}
