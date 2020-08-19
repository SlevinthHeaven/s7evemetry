using System;
using System.Buffers.Binary;

namespace S7evemetry.Core.Packets.Forza
{
	/// <summary>
	/// "Sled" data structure
	/// </summary>
	public class SledData
	{
		// = 1 when race is on. = 0 when in menus/race stopped …
		public int IsRaceOn;

		//Can overflow to 0 eventually
		public uint TimestampMS;

		public float EngineMaxRpm;
		public float EngineIdleRpm;
		public float CurrentEngineRpm;

		//In the car's local space; X = right, Y = up, Z = forward
		public float AccelerationX;
		public float AccelerationY;
		public float AccelerationZ;

		//In the car's local space; X = right, Y = up, Z = forward
		public float VelocityX;
		public float VelocityY;
		public float VelocityZ;

		//In the car's local space; X = pitch, Y = yaw, Z = roll
		public float AngularVelocityX; 
		public float AngularVelocityY;
		public float AngularVelocityZ;

		public float Yaw;
		public float Pitch;
		public float Roll;

		// Suspension travel normalized: 0.0f = max stretch; 1.0 = max compression
		public float NormalizedSuspensionTravelFrontLeft;
		public float NormalizedSuspensionTravelFrontRight;
		public float NormalizedSuspensionTravelRearLeft;
		public float NormalizedSuspensionTravelRearRight;

		// Tire normalized slip ratio, = 0 means 100% grip and |ratio| > 1.0 means loss of grip.
		public float TireSlipRatioFrontLeft;
		public float TireSlipRatioFrontRight;
		public float TireSlipRatioRearLeft;
		public float TireSlipRatioRearRight;

		// Wheel rotation speed radians/sec.
		public float WheelRotationSpeedFrontLeft;
		public float WheelRotationSpeedFrontRight;
		public float WheelRotationSpeedRearLeft;
		public float WheelRotationSpeedRearRight;

		// = 1 when wheel is on rumble strip, = 0 when off.
		public int WheelOnRumbleStripFrontLeft;
		public int WheelOnRumbleStripFrontRight;
		public int WheelOnRumbleStripRearLeft;
		public int WheelOnRumbleStripRearRight;

		// = from 0 to 1, where 1 is the deepest puddle
		public float WheelInPuddleDepthFrontLeft;
		public float WheelInPuddleDepthFrontRight;
		public float WheelInPuddleDepthRearLeft;
		public float WheelInPuddleDepthRearRight;

		// Non-dimensional surface rumble values passed to controller force feedback
		public float SurfaceRumbleFrontLeft;
		public float SurfaceRumbleFrontRight;
		public float SurfaceRumbleRearLeft;
		public float SurfaceRumbleRearRight;

		// Tire normalized slip angle, = 0 means 100% grip and |angle| > 1.0 means loss of grip.
		public float TireSlipAngleFrontLeft;
		public float TireSlipAngleFrontRight;
		public float TireSlipAngleRearLeft;
		public float TireSlipAngleRearRight;

		// Tire normalized combined slip, = 0 means 100% grip and |slip| > 1.0 means loss of grip.
		public float TireCombinedSlipFrontLeft;
		public float TireCombinedSlipFrontRight;
		public float TireCombinedSlipRearLeft;
		public float TireCombinedSlipRearRight;

		// Actual suspension travel in meters
		public float SuspensionTravelMetersFrontLeft;
		public float SuspensionTravelMetersFrontRight;
		public float SuspensionTravelMetersRearLeft;
		public float SuspensionTravelMetersRearRight;

		/// <summary>
		/// Unique ID of the car make/model
		/// </summary>
		public int CarOrdinal;

		/// <summary>
		/// Between 0 (D -- worst cars) and 7 (X class -- best cars) inclusive 
		/// </summary>
		public int CarClass;

		/// <summary>
		/// Between 100 (slowest car) and 999 (fastest car) inclusive
		/// </summary>
		public int CarPerformanceIndex;

		/// <summary>
		/// Corresponds to DriveTrainType; 0 = FWD, 1 = RWD, 2 = AWD
		/// </summary>
		public int DriveTrainType;

		/// <summary>
		/// Number of cylinders in the engine
		/// </summary>
		public int NumCylinders;

		public static int Size { get; } = 232;
		public static SledData? Read(Span<byte> input)
		{
			if (input.Length != Size) return null;

			return new SledData
			{
				IsRaceOn = BinaryPrimitives.ReadInt32LittleEndian(input.Slice(0, 4)), //4

				TimestampMS = BinaryPrimitives.ReadUInt32LittleEndian(input.Slice(4, 4)), //8

				EngineMaxRpm = BitConverter.ToSingle(input.Slice(8, 4)), //12
				EngineIdleRpm = BitConverter.ToSingle(input.Slice(12, 4)), //16
				CurrentEngineRpm = BitConverter.ToSingle(input.Slice(16, 4)), //20

				AccelerationX = BitConverter.ToSingle(input.Slice(20, 4)), //24
				AccelerationY = BitConverter.ToSingle(input.Slice(24, 4)), //28
				AccelerationZ = BitConverter.ToSingle(input.Slice(28, 4)), //32

				VelocityX = BitConverter.ToSingle(input.Slice(32, 4)), //36
				VelocityY = BitConverter.ToSingle(input.Slice(36, 4)), //40
				VelocityZ = BitConverter.ToSingle(input.Slice(40, 4)), //44

				AngularVelocityX = BitConverter.ToSingle(input.Slice(44, 4)), //48
				AngularVelocityY = BitConverter.ToSingle(input.Slice(48, 4)), //52
				AngularVelocityZ = BitConverter.ToSingle(input.Slice(52, 4)), //56

				Yaw = BitConverter.ToSingle(input.Slice(56, 4)), //60
				Pitch = BitConverter.ToSingle(input.Slice(60, 4)), //64
				Roll = BitConverter.ToSingle(input.Slice(64, 4)), //68

				NormalizedSuspensionTravelFrontLeft = BitConverter.ToSingle(input.Slice(68, 4)), //72
				NormalizedSuspensionTravelFrontRight = BitConverter.ToSingle(input.Slice(72, 4)), //76
				NormalizedSuspensionTravelRearLeft = BitConverter.ToSingle(input.Slice(76, 4)), //80
				NormalizedSuspensionTravelRearRight = BitConverter.ToSingle(input.Slice(80, 4)), //84

				TireSlipRatioFrontLeft = BitConverter.ToSingle(input.Slice(84, 4)), //88
				TireSlipRatioFrontRight = BitConverter.ToSingle(input.Slice(88, 4)), //92
				TireSlipRatioRearLeft = BitConverter.ToSingle(input.Slice(92, 4)), //96
				TireSlipRatioRearRight = BitConverter.ToSingle(input.Slice(96, 4)), //100

				WheelRotationSpeedFrontLeft = BitConverter.ToSingle(input.Slice(100, 4)), //104
				WheelRotationSpeedFrontRight = BitConverter.ToSingle(input.Slice(104, 4)), //108
				WheelRotationSpeedRearLeft = BitConverter.ToSingle(input.Slice(108, 4)), //112
				WheelRotationSpeedRearRight = BitConverter.ToSingle(input.Slice(112, 4)), //116

				WheelOnRumbleStripFrontLeft = BinaryPrimitives.ReadInt32LittleEndian(input.Slice(116, 4)), //120
				WheelOnRumbleStripFrontRight = BinaryPrimitives.ReadInt32LittleEndian(input.Slice(120, 4)), //124
				WheelOnRumbleStripRearLeft = BinaryPrimitives.ReadInt32LittleEndian(input.Slice(124, 4)), //128
				WheelOnRumbleStripRearRight = BinaryPrimitives.ReadInt32LittleEndian(input.Slice(128, 4)), //132

				WheelInPuddleDepthFrontLeft = BitConverter.ToSingle(input.Slice(132, 4)), //136
				WheelInPuddleDepthFrontRight = BitConverter.ToSingle(input.Slice(136, 4)), //140
				WheelInPuddleDepthRearLeft = BitConverter.ToSingle(input.Slice(140, 4)), //144
				WheelInPuddleDepthRearRight = BitConverter.ToSingle(input.Slice(144, 4)), //148

				SurfaceRumbleFrontLeft = BitConverter.ToSingle(input.Slice(148, 4)), //152
				SurfaceRumbleFrontRight = BitConverter.ToSingle(input.Slice(152, 4)), //156
				SurfaceRumbleRearLeft = BitConverter.ToSingle(input.Slice(156, 4)), //160
				SurfaceRumbleRearRight = BitConverter.ToSingle(input.Slice(160, 4)), //164

				TireSlipAngleFrontLeft = BitConverter.ToSingle(input.Slice(164, 4)), //168
				TireSlipAngleFrontRight = BitConverter.ToSingle(input.Slice(168, 4)), //172
				TireSlipAngleRearLeft = BitConverter.ToSingle(input.Slice(172, 4)), //176
				TireSlipAngleRearRight = BitConverter.ToSingle(input.Slice(176, 4)), //180

				TireCombinedSlipFrontLeft = BitConverter.ToSingle(input.Slice(180, 4)), //184
				TireCombinedSlipFrontRight = BitConverter.ToSingle(input.Slice(184, 4)), //188
				TireCombinedSlipRearLeft = BitConverter.ToSingle(input.Slice(188, 4)), //192
				TireCombinedSlipRearRight = BitConverter.ToSingle(input.Slice(192, 4)), //196

				SuspensionTravelMetersFrontLeft = BitConverter.ToSingle(input.Slice(196, 4)), //200
				SuspensionTravelMetersFrontRight = BitConverter.ToSingle(input.Slice(200, 4)), //204
				SuspensionTravelMetersRearLeft = BitConverter.ToSingle(input.Slice(204, 4)), //208
				SuspensionTravelMetersRearRight = BitConverter.ToSingle(input.Slice(208, 4)), //212

				CarOrdinal = BinaryPrimitives.ReadInt32LittleEndian(input.Slice(212, 4)), //216
				CarClass = BinaryPrimitives.ReadInt32LittleEndian(input.Slice(216, 4)), //220
				CarPerformanceIndex = BinaryPrimitives.ReadInt32LittleEndian(input.Slice(220, 4)), //224
				DriveTrainType = BinaryPrimitives.ReadInt32LittleEndian(input.Slice(224, 4)), //228
				NumCylinders = BinaryPrimitives.ReadInt32LittleEndian(input.Slice(228, 4)) //232
			};
		}

	}
}
