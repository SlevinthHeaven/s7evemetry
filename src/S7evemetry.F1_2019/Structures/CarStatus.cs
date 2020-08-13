using S7evemetry.Core.Enums;
using System;
using System.Buffers.Binary;

namespace S7evemetry.F1_2019.Structures
{
    public class CarStatus
    {
        public static int Size { get; } = 56;

        public TractionControl TractionControl { get; set; }

        /// <summary>
        /// Originally a byte value converted to bool and renamed AntiLockBrakes => AreAntiLockBrakesOn
        /// </summary>
        public bool AreAntiLockBrakesOn { get; set; }

        public FuelMix FuelMix { get; set; }

        public byte FrontBrakeBias { get; set; }           // Front brake bias (percentage)

        /// <summary>
        /// Originally a byte value converted to bool and renamed PitLimiterStatus => IsPitLimiterOn
        /// </summary>
        public bool IsPitLimiterOn { get; set; }

        public float FuelInTank { get; set; }

        public float FuelCapacity { get; set; }

        /// <summary>
        /// Fuel remaining in terms of laps (value on MFD)
        /// </summary>
        public float FuelRemainingLaps { get; set; }

        /// <summary>
        /// Cars max RPM, point of rev limiter
        /// </summary>
        public ushort MaxRPM { get; set; }

        public ushort IdleRPM { get; set; }                  // Cars idle RPM

        public byte MaxGears { get; set; }                 // Maximum number of gears

        public DrsAllowed DrsAllowed { get; set; }

        /// <summary>
        /// Tyre wear percentage
        /// </summary>
        public byte[] TyresWear { get; set; } = new byte[4];             // Tyre wear percentage

        public TyreCompoundActual ActualTyreCompound { get; set; }

        public TyreCompoundVisual TyreVisualCompound { get; set; }

        public byte[] TyresDamage { get; set; } = new byte[4];        // Tyre damage (percentage)

        public byte FrontLeftWingDamage { get; set; }      // Front left wing damage (percentage)

        public byte FrontRightWingDamage { get; set; }     // Front right wing damage (percentage)

        public byte RearWingDamage { get; set; }           // Rear wing damage (percentage)

        public byte EngineDamage { get; set; }             // Engine damage (percentage)

        public byte GearBoxDamage { get; set; }            // Gear box damage (percentage)

        public VehicleFiaFlag VehicleFiaFlags { get; set; }

        public float ErsStoreEnergy { get; set; }           // ERS energy store in Joules

        public ErsDeployMode ErsDeployMode { get; set; }

        public float ErsHarvestedThisLapMGUK { get; set; }  // ERS energy harvested this lap by MGU-K

        public float ErsHarvestedThisLapMGUH { get; set; }  // ERS energy harvested this lap by MGU-H

        public float ErsDeployedThisLap { get; set; }       // ERS energy deployed this lap

        public static CarStatus Read(Span<byte> input)
        {
            return new CarStatus
            {
                TractionControl = (TractionControl)input[0],
                AreAntiLockBrakesOn = Convert.ToBoolean(input[1]),
                FuelMix = (FuelMix)input[2],
                FrontBrakeBias = input[3],
                IsPitLimiterOn = Convert.ToBoolean(input[4]),
                FuelInTank = BitConverter.ToSingle(input.Slice(5, 4)), // 4 byte
                FuelCapacity = BitConverter.ToSingle(input.Slice(9, 4)), // 4 byte
                FuelRemainingLaps = BitConverter.ToSingle(input.Slice(13, 4)), // 4 byte
                MaxRPM = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(17, 2)),
                IdleRPM = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(19, 2)),
                MaxGears = input[21],
                DrsAllowed = (DrsAllowed)input[22],
                TyresWear = new byte[] { input[23], input[24], input[25], input[26] },
                ActualTyreCompound = (TyreCompoundActual)input[27],
                TyreVisualCompound = (TyreCompoundVisual)input[28],
                TyresDamage = new byte[] { input[29], input[30], input[31], input[32] },
                FrontLeftWingDamage = input[33],
                FrontRightWingDamage = input[34],
                RearWingDamage = input[35],
                EngineDamage = input[36],
                GearBoxDamage = input[37],
                VehicleFiaFlags = (VehicleFiaFlag)((sbyte)input[38]),
                ErsStoreEnergy = BitConverter.ToSingle(input.Slice(39, 4)), // 4 byte
                ErsDeployMode = (ErsDeployMode)input[43],
                ErsHarvestedThisLapMGUK = BitConverter.ToSingle(input.Slice(44, 4)), // 4 byte
                ErsHarvestedThisLapMGUH = BitConverter.ToSingle(input.Slice(48, 4)), // 4 byte
                ErsDeployedThisLap = BitConverter.ToSingle(input.Slice(52, 4)) // 4 byte
            };
        }
    }
}
