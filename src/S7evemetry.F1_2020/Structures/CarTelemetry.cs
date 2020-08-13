using S7evemetry.Core.Structures;
using System;
using System.Buffers.Binary;

namespace S7evemetry.F1_2020.Structures
{
    public class CarTelemetry : CarTelemetryCommon
    {
        public static new int Size { get; } = 58;

        public new byte[] TyresSurfaceTemperature { get; set; } = new byte[4];  // Tyres surface temperature (celsius)(8)
        public new byte[] TyresInnerTemperature { get; set; } = new byte[4];  // Tyres inner temperature (celsius)(8)


        public byte[] SurfaceType { get; set; } = new byte[4];            // Driving surface, see appendices(4)

		public static CarTelemetry Read(Span<byte> input)
		{
			return new CarTelemetry
			{
				Speed = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(0, 2)),
				Throttle = BitConverter.ToSingle(input.Slice(2, 4)),
				Steer = BitConverter.ToSingle(input.Slice(6, 4)),
				Brake = BitConverter.ToSingle(input.Slice(10, 4)),
				Clutch = input[14],
				Gear = (sbyte)input[15],
				EngineRPM = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(16, 2)),
				DRS = Convert.ToBoolean(input[18]),
				RevLightsPercent = input[19],
				BrakesTemperature = new ushort[] {
					BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(20, 2)),
					BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(22, 2)),
					BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(24, 2)),
					BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(26, 2))
				},
				TyresSurfaceTemperature = new byte[] { input[28], input[29], input[30], input[31] },
				TyresInnerTemperature = new byte[] { input[32], input[33], input[34], input[35] },
				EngineTemperature = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(36, 2)),
				TyresPressure = new float[] {
					BitConverter.ToSingle(input.Slice(38, 4)),
					BitConverter.ToSingle(input.Slice(42, 4)),
					BitConverter.ToSingle(input.Slice(46, 4)),
					BitConverter.ToSingle(input.Slice(50, 4))
				},
				SurfaceType = new byte[] { input[54], input[55], input[56], input[57] }
			};


		}
    }
}
