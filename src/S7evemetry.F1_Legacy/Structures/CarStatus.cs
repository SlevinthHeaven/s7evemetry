using S7evemetry.Core.Enums.F1;
using System;
using System.Buffers.Binary;

namespace S7evemetry.F1_Legacy.Structures
{
    public class CarStatus
    {
        public static int Size { get; } = 52;

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

        public byte TyreCompound { get; set; }  
        
        public byte[] TyresDamage { get; set; } = new byte[4];        // Tyre damage (percentage)

        public byte FrontLeftWingDamage { get; set; }      // Front left wing damage (percentage)

        public byte FrontRightWingDamage { get; set; }     // Front right wing damage (percentage)

        public byte RearWingDamage { get; set; }           // Rear wing damage (percentage)

        public byte EngineDamage { get; set; }             // Engine damage (percentage)

        public byte GearBoxDamage { get; set; }
        public byte ExhaustDamage { get; set; }           // Gear box damage (percentage)

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
                TractionControl = (TractionControl)input[0], //1
                AreAntiLockBrakesOn = Convert.ToBoolean(input[1]), //2
                FuelMix = (FuelMix)input[2], //3
                FrontBrakeBias = input[3], //4
                IsPitLimiterOn = Convert.ToBoolean(input[4]), //5
                FuelInTank = BitConverter.ToSingle(input.Slice(5, 4)), //9 
                FuelCapacity = BitConverter.ToSingle(input.Slice(9, 4)), //13
                MaxRPM = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(13, 2)), //15
                IdleRPM = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(15, 2)), //17
                MaxGears = input[17], //18
                DrsAllowed = (DrsAllowed)input[18], //19
                TyresWear = new byte[] { input[19], input[20], input[21], input[22] }, //23
                TyreCompound = input[23], //24
                TyresDamage = new byte[] { input[24], input[25], input[26], input[27] }, //28
                FrontLeftWingDamage = input[28], //29
                FrontRightWingDamage = input[29], //30
                RearWingDamage = input[30], //31
                EngineDamage = input[31], //3
                GearBoxDamage = input[32], //33
                ExhaustDamage = input[33], //34
                VehicleFiaFlags = (VehicleFiaFlag)((sbyte)input[34]), //35
                ErsStoreEnergy = BitConverter.ToSingle(input.Slice(35, 4)), // 39
                ErsDeployMode = (ErsDeployMode)input[39], //40
                ErsHarvestedThisLapMGUK = BitConverter.ToSingle(input.Slice(40, 4)), // 44
                ErsHarvestedThisLapMGUH = BitConverter.ToSingle(input.Slice(44, 4)), // 48
                ErsDeployedThisLap = BitConverter.ToSingle(input.Slice(48, 4)) // 52
            };
        }
    }
}
