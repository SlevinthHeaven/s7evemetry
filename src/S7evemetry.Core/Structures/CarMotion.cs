using System;
using System.Buffers.Binary;

namespace S7evemetry.Core.Structures
{
    /// <summary>
    /// CarMotion data for each Car
    /// </summary>
    public class CarMotion
    {
        /// <summary>
        /// World space X position
        /// </summary>
        public float WorldPositionX { get; set; }

        /// <summary>
        /// World space Y position
        /// </summary>
        public float WorldPositionY { get; set; }

        /// <summary>
        /// World space Z position
        /// </summary>
        public float WorldPositionZ { get; set; }

        /// <summary>
        /// Velocity in world space X
        /// </summary>
        public float WorldVelocityX { get; set; }

        /// <summary>
        /// Velocity in world space Y
        /// </summary>
        public float WorldVelocityY { get; set; }


        /// <summary>
        /// Velocity in world space Z
        /// </summary>
        public float WorldVelocityZ { get; set; }

        /// <summary>
        /// Normalized vector, to convert to float values divide by 32767.0f
        /// 16-bit signed values are used to pack the data and on the assumption that direction values are always between -1.0f and 1.0f.
        /// </summary>
        public short WorldForwardDirX { get; set; }

        /// <summary>
        /// Normalized vector, to convert to float values divide by 32767.0f 
        /// 16-bit signed values are used to pack the data and on the assumption that direction values are always between -1.0f and 1.0f.
        /// </summary>
        public short WorldForwardDirY { get; set; }

        /// <summary>
        /// Normalized vector, to convert to float values divide by 32767.0f 
        /// 16-bit signed values are used to pack the data and on the assumption that direction values are always between -1.0f and 1.0f.
        /// </summary>
        public short WorldForwardDirZ { get; set; }

        /// <summary>
        /// Normalized vector, to convert to float values divide by 32767.0f 
        /// 16-bit signed values are used to pack the data and on the assumption that direction values are always between -1.0f and 1.0f.
        /// </summary>
        public short WorldRightDirX { get; set; }

        /// <summary>
        /// Normalized vector, to convert to float values divide by 32767.0f 
        /// 16-bit signed values are used to pack the data and on the assumption that direction values are always between -1.0f and 1.0f.
        /// </summary>
        public short WorldRightDirY { get; set; }

        /// <summary>
        /// Normalized vector, to convert to float values divide by 32767.0f 
        /// 16-bit signed values are used to pack the data and on the assumption that direction values are always between -1.0f and 1.0f.
        /// </summary>
        public short WorldRightDirZ { get; set; }

        /// <summary>
        /// Lateral G-Force component
        /// </summary>
        public float GForceLateral { get; set; }

        /// <summary>
        /// Longitudinal G-Force component
        /// </summary>
        public float GForceLongitudinal { get; set; }

        /// <summary>
        /// Vertical G-Force component
        /// </summary>
        public float GForceVertical { get; set; }

        /// <summary>
        /// Yaw angle in radians
        /// </summary>
        public float Yaw { get; set; }

        /// <summary>
        /// Pitch angle in radians
        /// </summary>
        public float Pitch { get; set; }

        /// <summary>
        /// Roll angle in radians
        /// </summary>
        public float Roll { get; set; }

        /// <summary>
        /// Size of the CarMotion data for each car
        /// </summary>
        public static int Size { get; } = 60;

        /// <summary>
        /// Read motion data from the input
        /// </summary>
        /// <param name="input">A Span of byte to be deserialized</param>
        /// <returns>The CarMotion</returns>
        public static CarMotion? Read(Span<byte> input)
        {
            if (input.Length != Size) return null;
            return new CarMotion
            {
                WorldPositionX = BitConverter.ToSingle(input.Slice(0, 4)),
                WorldPositionY = BitConverter.ToSingle(input.Slice(4, 4)),
                WorldPositionZ = BitConverter.ToSingle(input.Slice(8, 4)),
                WorldVelocityX = BitConverter.ToSingle(input.Slice(12, 4)),
                WorldVelocityY = BitConverter.ToSingle(input.Slice(16, 4)),
                WorldVelocityZ = BitConverter.ToSingle(input.Slice(20, 4)),
                WorldForwardDirX = BinaryPrimitives.ReadInt16LittleEndian(input.Slice(24, 2)),
                WorldForwardDirY = BinaryPrimitives.ReadInt16LittleEndian(input.Slice(26, 2)),
                WorldForwardDirZ = BinaryPrimitives.ReadInt16LittleEndian(input.Slice(28, 2)),
                WorldRightDirX = BinaryPrimitives.ReadInt16LittleEndian(input.Slice(30, 2)),
                WorldRightDirY = BinaryPrimitives.ReadInt16LittleEndian(input.Slice(32, 2)),
                WorldRightDirZ = BinaryPrimitives.ReadInt16LittleEndian(input.Slice(34, 2)),
                GForceLateral = BitConverter.ToSingle(input.Slice(36, 4)),
                GForceLongitudinal = BitConverter.ToSingle(input.Slice(40, 4)),
                GForceVertical = BitConverter.ToSingle(input.Slice(44, 4)),
                Yaw = BitConverter.ToSingle(input.Slice(48, 4)),
                Pitch = BitConverter.ToSingle(input.Slice(52, 4)),
                Roll = BitConverter.ToSingle(input.Slice(56, 4))
            };
        }
    }
}
