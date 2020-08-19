using System;
using System.Buffers.Binary;

namespace S7evemetry.Core.Packets.Forza
{
	/// <summary>
	/// "Car dash" data structure
	/// </summary>
	public class CarDashData
	{
		//Position (meters)
		public float PositionX { get; set; }
		public float PositionY { get; set; }
		public float PositionZ { get; set; }

		public float Speed { get; set; } // meters per second
		public float Power { get; set; } // watts
		public float Torque { get; set; } // newton meter

		public float TireTempFrontLeft { get; set; }
		public float TireTempFrontRight { get; set; }
		public float TireTempRearLeft { get; set; }
		public float TireTempRearRight { get; set; }

		public float Boost { get; set; }
		public float Fuel { get; set; }
		public float DistanceTraveled { get; set; }
		public float BestLap { get; set; }
		public float LastLap { get; set; }
		public float CurrentLap { get; set; }
		public float CurrentRaceTime { get; set; }

		public ushort LapNumber { get; set; }
		public byte RacePosition { get; set; }

		public byte Accelerator { get; set; }
		public byte Brake { get; set; }
		public byte Clutch { get; set; }
		public byte HandBrake { get; set; }
		public byte Gear { get; set; }
		public sbyte Steer { get; set; }

		public sbyte NormalizedDrivingLine { get; set; }
		public sbyte NormalizedAIBrakeDifference { get; set; }

		public static int Size { get; } = 79;
		public static CarDashData? Read(Span<byte> input)
		{
			if (input.Length != Size) return null;
			return new CarDashData
			{
				PositionX = BitConverter.ToSingle(input.Slice(0, 4)), //4
				PositionY = BitConverter.ToSingle(input.Slice(4, 4)), //8
				PositionZ = BitConverter.ToSingle(input.Slice(8, 4)), //12

				Speed = BitConverter.ToSingle(input.Slice(12, 4)), //16
				Power = BitConverter.ToSingle(input.Slice(16, 4)), //20
				Torque = BitConverter.ToSingle(input.Slice(20, 4)), //24

				TireTempFrontLeft = BitConverter.ToSingle(input.Slice(24, 4)), //28
				TireTempFrontRight = BitConverter.ToSingle(input.Slice(28, 4)), //32
				TireTempRearLeft = BitConverter.ToSingle(input.Slice(32, 4)), //36
				TireTempRearRight = BitConverter.ToSingle(input.Slice(36, 4)), //40

				Boost = BitConverter.ToSingle(input.Slice(40, 4)), //44
				Fuel = BitConverter.ToSingle(input.Slice(44, 4)), //48
				DistanceTraveled = BitConverter.ToSingle(input.Slice(48, 4)), //52
				BestLap = BitConverter.ToSingle(input.Slice(52, 4)), //56
				LastLap = BitConverter.ToSingle(input.Slice(56, 4)), //60
				CurrentLap = BitConverter.ToSingle(input.Slice(60, 4)), //64
				CurrentRaceTime = BitConverter.ToSingle(input.Slice(64, 4)), //68

				LapNumber = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(68,2)), //70
				RacePosition = input[70], //71

				Accelerator = input[71], //72
				Brake = input[72], //73
				Clutch = input[73], //74
				HandBrake = input[74], //75
				Gear = input[75], //76
				Steer = (sbyte)input[76], //77

				NormalizedDrivingLine = (sbyte)input[77], //78
				NormalizedAIBrakeDifference = (sbyte)input[78] //79
			};
		}
	}
}
