using S7evemetry.Core.Enums.F1;
using System;
using System.Buffers.Binary;

namespace S7evemetry.F1_2020.Structures
{
    public class CarStatus
    {
        public static int Size { get; } = 60; 
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

        public ushort DrsActivationDistance { get; set; }    // 0 = DRS not available, non-zero - DRS will be available
                                                             // in [X] metres

        /// <summary>
        /// Tyre wear percentage
        /// </summary>
        public byte[] TyresWear { get; set; } = new byte[4];             // Tyre wear percentage

        public TyreCompoundActual ActualTyreCompound { get; set; }

        public TyreCompoundVisual TyreVisualCompound { get; set; }
        public byte  TyresAgeLaps { get; set; }            // Age in laps of the current set of tyres

        public byte[] TyresDamage { get; set; } = new byte[4];        // Tyre damage (percentage)

        public byte FrontLeftWingDamage { get; set; }      // Front left wing damage (percentage)

        public byte FrontRightWingDamage { get; set; }     // Front right wing damage (percentage)

        public byte RearWingDamage { get; set; }           // Rear wing damage (percentage)


        public byte DrsFault { get; set; }                   // Indicator for DRS fault, 0 = OK, 1 = fault
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
                TractionControl = (TractionControl)input[0], //1
                AreAntiLockBrakesOn = Convert.ToBoolean(input[1]), //2
                FuelMix = (FuelMix)input[2], //3
                FrontBrakeBias = input[3], //4
                IsPitLimiterOn = Convert.ToBoolean(input[4]), //5
                FuelInTank = BitConverter.ToSingle(input.Slice(5, 4)), // 9
                FuelCapacity = BitConverter.ToSingle(input.Slice(9, 4)), // 13
                FuelRemainingLaps = BitConverter.ToSingle(input.Slice(13, 4)), // 17
                MaxRPM = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(17, 2)), //19
                IdleRPM = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(19, 2)), //21
                MaxGears = input[21], //22
                DrsAllowed = (DrsAllowed)input[22], //23
                DrsActivationDistance = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(23, 2)),//25
                TyresWear = new byte[] { input[25], input[26], input[27], input[28] }, //29
                ActualTyreCompound = (TyreCompoundActual)input[29], //30
                TyreVisualCompound = (TyreCompoundVisual)input[30], //31
                TyresAgeLaps = input[31], //32
                TyresDamage = new byte[] { input[32], input[33], input[34], input[35] }, //36
                FrontLeftWingDamage = input[36], //37
                FrontRightWingDamage = input[37], //38
                RearWingDamage = input[38], //39
                DrsFault = input[39], //40 
                EngineDamage = input[40], //41
                GearBoxDamage = input[41], //41
                VehicleFiaFlags = (VehicleFiaFlag)((sbyte)input[42]), //43
                ErsStoreEnergy = BitConverter.ToSingle(input.Slice(43, 4)), // 47
                ErsDeployMode = (ErsDeployMode)input[47], //48
                ErsHarvestedThisLapMGUK = BitConverter.ToSingle(input.Slice(48, 4)), // 52
                ErsHarvestedThisLapMGUH = BitConverter.ToSingle(input.Slice(52, 4)), // 56 
                ErsDeployedThisLap = BitConverter.ToSingle(input.Slice(56, 4)) // 60
            };
        }
    }
}
