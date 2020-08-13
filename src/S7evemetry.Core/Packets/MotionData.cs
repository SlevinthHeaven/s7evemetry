using System;

namespace S7evemetry.Core.Packets
{
    /// <summary>
    /// The base packet data which comes with each Motion PacketType
    /// </summary>
    public class MotionData
    {
        /// <summary>
        /// Suspension position
        /// Wheel array with order: RL, RR, FL, FR
        /// </summary>
        public float[] SuspensionPosition { get; set; } = new float[4];

        /// <summary>
        /// Suspension velocity
        /// Wheel array with order: RL, RR, FL, FR
        /// </summary>
        public float[] SuspensionVelocity { get; set; } = new float[4];

        /// <summary>
        /// Suspension acceleration 
        /// Wheel array with order: RL, RR, FL, FR
        /// </summary>
        public float[] SuspensionAcceleration { get; set; } = new float[4];

        /// <summary>
        /// Wheel speed in meters per second
        /// Wheel array with order: RL, RR, FL, FR
        /// </summary>
        public float[] WheelSpeed { get; set; } = new float[4];

        /// <summary>
        /// Slip ratio for each wheel
        /// Wheel array with order: RL, RR, FL, FR
        /// </summary>
        public float[] WheelSlip { get; set; } = new float[4];

        /// <summary>
        /// Velocity in local space along the X axis
        /// </summary>
        public float LocalVelocityX { get; set; }

        /// <summary>
        /// Velocity in local space along the Y axis
        /// </summary>
        public float LocalVelocityY { get; set; }

        /// <summary>
        /// Velocity in local space along the Z axis
        /// </summary>
        public float LocalVelocityZ { get; set; }

        /// <summary>
        /// Angular velocity along the X axis
        /// </summary>
        public float AngularVelocityX { get; set; }

        /// <summary>
        /// Angular velocity along the Y axis
        /// </summary>
        public float AngularVelocityY { get; set; }

        /// <summary>
        /// Angular velocity along the Z axis
        /// </summary>
        public float AngularVelocityZ { get; set; }

        /// <summary>
        /// Angular acceleration along the X axis
        /// </summary>
        public float AngularAccelerationX { get; set; }

        /// <summary>
        /// Angular acceleration along the Y axis
        /// </summary>
        public float AngularAccelerationY { get; set; }

        /// <summary>
        /// Angular acceleration along the Z axis
        /// </summary>
        public float AngularAccelerationZ { get; set; }

        /// <summary>
        /// Current front wheels angle in radians
        /// </summary>
        public float FrontWheelsAngle { get; set; }

        /// <summary>
        /// Size in bytes of the base data contained in the Motion PacketType
        /// </summary>
        public static int Size { get; } = 120;

        /// <summary>
        /// Read motion data from the input
        /// </summary>
        /// <param name="input">A Span of byte to be deserialized</param>
        /// <returns>The MotionData</returns>
        public static MotionData Read(Span<byte> input)
        {
            var _motionData = new MotionData
            {
                SuspensionPosition = new float[] {
                    BitConverter.ToSingle(input.Slice(0, 4)),
                    BitConverter.ToSingle(input.Slice(4, 4)),
                    BitConverter.ToSingle(input.Slice(8, 4)),
                    BitConverter.ToSingle(input.Slice(12, 4))
                },
                SuspensionVelocity = new float[] {
                    BitConverter.ToSingle(input.Slice(16, 4)),
                    BitConverter.ToSingle(input.Slice(20, 4)),
                    BitConverter.ToSingle(input.Slice(24, 4)),
                    BitConverter.ToSingle(input.Slice(28, 4))
                },
                SuspensionAcceleration = new float[] {
                    BitConverter.ToSingle(input.Slice(32, 4)),
                    BitConverter.ToSingle(input.Slice(36, 4)),
                    BitConverter.ToSingle(input.Slice(40, 4)),
                    BitConverter.ToSingle(input.Slice(44, 4))
                },
                WheelSpeed = new float[] {
                    BitConverter.ToSingle(input.Slice(48, 4)),
                    BitConverter.ToSingle(input.Slice(52, 4)),
                    BitConverter.ToSingle(input.Slice(56, 4)),
                    BitConverter.ToSingle(input.Slice(60, 4))
                },
                WheelSlip = new float[] {
                    BitConverter.ToSingle(input.Slice(64, 4)),
                    BitConverter.ToSingle(input.Slice(68, 4)),
                    BitConverter.ToSingle(input.Slice(72, 4)),
                    BitConverter.ToSingle(input.Slice(76, 4))
                },
                LocalVelocityX = BitConverter.ToSingle(input.Slice(80, 4)),
                LocalVelocityY = BitConverter.ToSingle(input.Slice(84, 4)),
                LocalVelocityZ = BitConverter.ToSingle(input.Slice(88, 4)),
                AngularVelocityX = BitConverter.ToSingle(input.Slice(92, 4)),
                AngularVelocityY = BitConverter.ToSingle(input.Slice(96, 4)),
                AngularVelocityZ = BitConverter.ToSingle(input.Slice(100, 4)),
                AngularAccelerationX = BitConverter.ToSingle(input.Slice(104, 4)),
                AngularAccelerationY = BitConverter.ToSingle(input.Slice(108, 4)),
                AngularAccelerationZ = BitConverter.ToSingle(input.Slice(112, 4)),
                FrontWheelsAngle = BitConverter.ToSingle(input.Slice(116, 4))
            };

            return _motionData;
		}
    }
}
