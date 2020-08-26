using System;
using System.Buffers.Binary;

namespace S7evemetry.Core.Structures
{

	/// <summary>
	/// CarSetup data for each Car
	/// </summary>
	public class CarTelemetryCommon
	{
		/// <summary>
		/// Speed of car in kilometres per hour
		/// </summary>
		public ushort Speed { get; set; }

		/// <summary>
		/// Amount of throttle applied (0.0 to 1.0)
		/// </summary>
		public float Throttle { get; set; }

		/// <summary>
		/// Steering (-1.0 (full lock left) to 1.0 (full lock right))
		/// </summary>
		public float Steer { get; set; }

		/// <summary>
		/// Amount of brake applied (0.0 to 1.0)
		/// </summary>
		public float Brake { get; set; }

		/// <summary>
		/// Amount of clutch applied (0 to 100)
		/// </summary>
		public byte Clutch { get; set; }

		/// <summary>
		/// Gear selected (1-8, N=0, R=-1)
		/// </summary>
		public sbyte Gear { get; set; }

		/// <summary>
		/// Engine RPM
		/// </summary>
		public ushort EngineRPM { get; set; }

		/// <summary>
		/// 0 = off, 1 = on(1)
		/// </summary>
		public bool DRS { get; set; }

		/// <summary>
		/// Rev lights indicator (percentage)
		/// </summary>
		public byte RevLightsPercent { get; set; }

		/// <summary>
		/// Brakes temperature (celsius)
		/// </summary>
		public ushort[] BrakesTemperature { get; set; } = new ushort[4];

		/// <summary>
		/// Tyres surface temperature (celsius)
		/// </summary>
		public ushort[] TyresSurfaceTemperature { get; set; } = new ushort[4];

		/// <summary>
		/// Tyres inner temperature (celsius)
		/// </summary>
		public ushort[] TyresInnerTemperature { get; set; } = new ushort[4];

		/// <summary>
		/// Engine temperature (celsius)
		/// </summary>
		public ushort EngineTemperature { get; set; }

		/// <summary>
		/// Tyres pressure (PSI)
		/// </summary>
		public float[] TyresPressure { get; set; } = new float[4];

		/// <summary>
		/// Size of the  CarTelemetry data for each car
		/// </summary>
		public static int Size { get; } = 62;

		/// <summary>
		/// Reads the common data for CarTelemetry.
		/// </summary>
		/// <typeparam name="T">An inherited Type of CarTelemetryCommon</typeparam>
		/// <param name="input">
		/// The Span of byte which contain the common CarTelemetry data packet
		/// </param>
		/// <returns>Instance of T with deserialized data from input</returns>
		public static T? Read<T>(Span<byte> input) where T : CarTelemetryCommon, new()
		{
			if (input.Length != Size) return null;
            return new T
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
				TyresSurfaceTemperature = new ushort[] {
					BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(28, 2)),
					BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(30, 2)),
					BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(32, 2)),
					BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(34, 2))
				},
				TyresInnerTemperature = new ushort[] {
					BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(36, 2)),
					BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(38, 2)),
					BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(40, 2)),
					BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(42, 2))
				},
				EngineTemperature = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(44, 2)),
				TyresPressure = new float[] {
					BitConverter.ToSingle(input.Slice(46, 4)),
					BitConverter.ToSingle(input.Slice(50, 4)),
					BitConverter.ToSingle(input.Slice(54, 4)),
					BitConverter.ToSingle(input.Slice(58, 4))
				}
			};
        }
    }
}
