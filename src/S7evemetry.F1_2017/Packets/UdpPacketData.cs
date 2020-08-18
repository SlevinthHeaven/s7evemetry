using S7evemetry.F1_2017.Enums;
using S7evemetry.F1_2017.Structures;
using System;
using System.Collections.Generic;

namespace S7evemetry.F1_2017.Packets
{
    public class UdpPacketData
    {
        public float Time { get; set; }

        public float LapTime { get; set; }

        public float LapDistance { get; set; }

        public float TotalDistance { get; set; }

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

        public float Speed { get; set; } // Speed of car in MPH

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
        /// </summary>
        public float WorldRightDirX { get; set; }

        /// <summary>
        /// </summary>
        public float WorldRightDirY { get; set; }

        /// <summary>
        /// </summary>
        public float WorldRightDirZ { get; set; }

        /// <summary>
        /// </summary>
        public float WorldForwardDirX { get; set; }

        /// <summary>
        /// </summary>
        public float WorldForwardDirY { get; set; }

        /// <summary>
        /// </summary>
        public float WorldForwardDirZ { get; set; }

        public float[] SuspensionPosition { get; set; } = new float[4]; // Note: All wheel arrays have the order:

        public float[] SuspensionVelocity { get; set; } = new float[4]; // RL, RR, FL, FR

        public float[] WheelSpeed { get; set; } = new float[4];

        public float Throttle { get; set; }

        public float Steer { get; set; }

        public float Brake { get; set; }

        public float Clutch { get; set; }

        public float Gear { get; set; }

        /// <summary>
        /// Lateral G-Force component
        /// </summary>
        public float GForceLateral { get; set; }

        /// <summary>
        /// Longitudinal G-Force component
        /// </summary>
        public float GForceLongitudinal { get; set; }

        public float Lap { get; set; }

        public float EngineRate { get; set; }

        public float SliProNativeSupport { get; set; } // SLI Pro support

        public float CarPosition { get; set; } // car race position

        public float KersLevel { get; set; } // kers energy left

        public float KersMaxLevel { get; set; } // kers maximum energy

        public float Drs { get; set; } // 0 = off, 1 = on

        public float TractionControl { get; set; } // 0 (off) - 2 (high)

        public float AntiLockBrakes { get; set; } // 0 (off) - 1 (on)

        public float FuelInTank { get; set; } // current fuel mass

        public float FuelCapacity { get; set; } // fuel capacity

        public float InPits { get; set; } // 0 = none, 1 = pitting, 2 = in pit area

        public float Sector { get; set; } // 0 = sector1, 1 = sector2, 2 = sector3

        public float Sector1Time { get; set; } // time of sector1 (or 0)

        public float Sector2Time { get; set; } // time of sector2 (or 0)

        public float[] BrakesTemp { get; set; } = new float[4]; // brakes temperature (centigrade)

        public float[] TyresPressure { get; set; } = new float[4];  // tyres pressure PSI

        public float TeamInfo { get; set; } // team ID 

        public float TotalLaps { get; set; } // total number of laps in this race

        public float TrackSize { get; set; } // track size meters

        public float LastLapTime { get; set; } // last lap time

        public float MaxRpm { get; set; } // cars max RPM, at which point the rev limiter will kick in

        public float IdleRpm { get; set; } // cars idle RPM

        public float MaxGears { get; set; } // maximum number of gears

        public float SessionType { get; set; } // 0 = unknown, 1 = practice, 2 = qualifying, 3 = race

        public float DrsAllowed { get; set; } // 0 = not allowed, 1 = allowed, -1 = invalid / unknown

        public float TrackNumber { get; set; } // -1 for unknown, 0-21 for tracks

        public float VehicleFIAFlags { get; set; } // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red

        public Era Era { get; set; }                     // era, 2017 (modern) or 1980 (classic)

        public float EngineTemperature { get; set; }   // engine temperature (centigrade)

        /// <summary>
        /// Vertical G-Force component
        /// </summary>
        public float GForceVertical { get; set; }

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

        public byte[] TyresTemperature { get; set; } = new byte[4]; // tyres temperature (centigrade)

        public byte[] TyresWear { get; set; } = new byte[4]; // tyre wear percentage

        public byte TyreCompound { get; set; } // compound of tyre – 0 = ultra soft, 1 = super soft, 2 = soft, 3 = medium, 4 = hard, 5 = inter, 6 = wet

        public byte FrontBrakeBias { get; set; }         // front brake bias (percentage)

        public byte FuelMix { get; set; }                 // fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max

        public byte CurrentLapInvalid { get; set; }     // current lap invalid - 0 = valid, 1 = invalid

        public byte[] TyresDamage { get; set; } = new byte[4]; // tyre damage (percentage)

        public byte FrontLeftWingDamage { get; set; } // front left wing damage (percentage)

        public byte FrontRightWingDamage { get; set; } // front right wing damage (percentage)

        public byte RearWingDamage { get; set; } // rear wing damage (percentage)

        public byte EngineDamage { get; set; } // engine damage (percentage)

        public byte GearBoxDamage { get; set; } // gear box damage (percentage)

        public byte ExhaustDamage { get; set; } // exhaust damage (percentage)

        public byte PitLimiterStatus { get; set; } // pit limiter status – 0 = off, 1 = on

        public byte PitSpeedLimit { get; set; } // pit speed limit in mph

        public float SessionTimeLeft { get; set; }  // NEW: time left in session in seconds 

        public byte RevLightsPercent { get; set; }  // NEW: rev lights indicator (percentage)

        public byte IsSpectating { get; set; }  // NEW: whether the player is spectating

        public byte SpectatorCarIndex { get; set; }  // NEW: index of the car being spectated

        // Car data

        public byte NumberOfCars { get; set; }               // number of cars in data

        public byte PlayerCarIndex { get; set; }         // index of player's car in the array

        public List<CarUdpData> CarData { get; set; } = new List<CarUdpData>(20); // data for all cars on track

        public float Yaw { get; set; }  // NEW (v1.8)

        public float Pitch { get; set; }  // NEW (v1.8)

        public float Roll { get; set; }  // NEW (v1.8)

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

        public float[] SuspensionAcceleration { get; set; } = new float[4];  // NEW (v1.8) RL, RR, FL, FR

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

        public static int Size { get; } = 1289;


        public static UdpPacketData Read(Span<byte> input)
        {
            var firstDataSize = 337;
            var carDataSize = 20 * CarUdpData.Size;
            var item = new UdpPacketData
            {
                Time = BitConverter.ToSingle(input.Slice(0, 4)), //4
                LapTime = BitConverter.ToSingle(input.Slice(4, 4)), //8
                LapDistance = BitConverter.ToSingle(input.Slice(8, 4)), //12
                TotalDistance = BitConverter.ToSingle(input.Slice(12, 4)), //16
                WorldPositionX = BitConverter.ToSingle(input.Slice(16, 4)), //20
                WorldPositionY = BitConverter.ToSingle(input.Slice(20, 4)), //24
                WorldPositionZ = BitConverter.ToSingle(input.Slice(24, 4)), //28
                Speed = BitConverter.ToSingle(input.Slice(28, 4)), //32
                WorldVelocityX = BitConverter.ToSingle(input.Slice(32, 4)), //36
                WorldVelocityY = BitConverter.ToSingle(input.Slice(36, 4)), //40
                WorldVelocityZ = BitConverter.ToSingle(input.Slice(40, 4)), //44
                WorldRightDirX = BitConverter.ToSingle(input.Slice(44, 4)), //48 
                WorldRightDirY = BitConverter.ToSingle(input.Slice(48, 4)), //52
                WorldRightDirZ = BitConverter.ToSingle(input.Slice(52, 4)), //56
                WorldForwardDirX = BitConverter.ToSingle(input.Slice(56, 4)), //60
                WorldForwardDirY = BitConverter.ToSingle(input.Slice(60, 4)), //64
                WorldForwardDirZ = BitConverter.ToSingle(input.Slice(64, 4)), //68
                SuspensionPosition = new float[]
                {
                    BitConverter.ToSingle(input.Slice(68, 4)), //72
                    BitConverter.ToSingle(input.Slice(72, 4)), //76
                    BitConverter.ToSingle(input.Slice(76, 4)), //80
                    BitConverter.ToSingle(input.Slice(80, 4)), //84

                },                
                SuspensionVelocity = new float[]
                {
                    BitConverter.ToSingle(input.Slice(84, 4)), //88
                    BitConverter.ToSingle(input.Slice(88, 4)), //92
                    BitConverter.ToSingle(input.Slice(92, 4)), //96
                    BitConverter.ToSingle(input.Slice(96, 4)), //100

                },
                WheelSpeed = new float[]
                {
                    BitConverter.ToSingle(input.Slice(100, 4)), //104
                    BitConverter.ToSingle(input.Slice(104, 4)), //108
                    BitConverter.ToSingle(input.Slice(108, 4)), //112
                    BitConverter.ToSingle(input.Slice(112, 4)), //116

                },
                Throttle = BitConverter.ToSingle(input.Slice(116, 4)), //120
                Steer = BitConverter.ToSingle(input.Slice(120, 4)), //124
                Brake = BitConverter.ToSingle(input.Slice(124, 4)), //128
                Clutch = BitConverter.ToSingle(input.Slice(128, 4)), //132
                Gear = BitConverter.ToSingle(input.Slice(132, 4)), //136
                GForceLateral = BitConverter.ToSingle(input.Slice(136, 4)), //140
                GForceLongitudinal = BitConverter.ToSingle(input.Slice(140, 4)), //144
                Lap = BitConverter.ToSingle(input.Slice(144, 4)), //148
                EngineRate = BitConverter.ToSingle(input.Slice(148, 4)), //152
                SliProNativeSupport = BitConverter.ToSingle(input.Slice(152, 4)), //156
                CarPosition = BitConverter.ToSingle(input.Slice(156, 4)), //160
                KersLevel = BitConverter.ToSingle(input.Slice(160, 4)), //164
                KersMaxLevel = BitConverter.ToSingle(input.Slice(164, 4)), //168
                Drs = BitConverter.ToSingle(input.Slice(168, 4)), //172
                TractionControl = BitConverter.ToSingle(input.Slice(172, 4)), //176
                AntiLockBrakes = BitConverter.ToSingle(input.Slice(176, 4)), //180
                FuelInTank = BitConverter.ToSingle(input.Slice(180, 4)), //184
                FuelCapacity = BitConverter.ToSingle(input.Slice(184, 4)), //188
                InPits = BitConverter.ToSingle(input.Slice(188, 4)), //192
                Sector = BitConverter.ToSingle(input.Slice(192, 4)), //196
                Sector1Time = BitConverter.ToSingle(input.Slice(196, 4)), //200
                Sector2Time = BitConverter.ToSingle(input.Slice(200, 4)), //204
                BrakesTemp =  new float[]
                {
                    BitConverter.ToSingle(input.Slice(204, 4)), //208
                    BitConverter.ToSingle(input.Slice(208, 4)), //212
                    BitConverter.ToSingle(input.Slice(212, 4)), //216
                    BitConverter.ToSingle(input.Slice(216, 4)) //220

                },
                TyresPressure = new float[]
                {
                    BitConverter.ToSingle(input.Slice(220, 4)), //224
                    BitConverter.ToSingle(input.Slice(224, 4)), //228
                    BitConverter.ToSingle(input.Slice(228, 4)), //232
                    BitConverter.ToSingle(input.Slice(232, 4)) //236
                },
                TeamInfo = BitConverter.ToSingle(input.Slice(236, 4)), //240
                TotalLaps = BitConverter.ToSingle(input.Slice(240, 4)), //244
                TrackSize = BitConverter.ToSingle(input.Slice(244, 4)), //248
                LastLapTime = BitConverter.ToSingle(input.Slice(248, 4)), //252
                MaxRpm = BitConverter.ToSingle(input.Slice(252, 4)), //256
                IdleRpm = BitConverter.ToSingle(input.Slice(256, 4)), //260
                MaxGears = BitConverter.ToSingle(input.Slice(260, 4)), //254
                SessionType = BitConverter.ToSingle(input.Slice(264, 4)), //268
                DrsAllowed = BitConverter.ToSingle(input.Slice(268, 4)), //272
                TrackNumber = BitConverter.ToSingle(input.Slice(272, 4)), //276
                VehicleFIAFlags = BitConverter.ToSingle(input.Slice(276, 4)), //280
                Era = (Era)BitConverter.ToSingle(input.Slice(280, 4)), //284
                EngineTemperature = BitConverter.ToSingle(input.Slice(284, 4)), //288
                GForceVertical = BitConverter.ToSingle(input.Slice(288, 4)), //292
                AngularVelocityX = BitConverter.ToSingle(input.Slice(292, 4)), //296
                AngularVelocityY = BitConverter.ToSingle(input.Slice(296, 4)), //300
                AngularVelocityZ = BitConverter.ToSingle(input.Slice(300, 4)), //304
                TyresTemperature = new byte[] { input[304],input[305],input[306], input[307] }, //308
                TyresWear = new byte[] { input[308], input[309], input[310], input[311] }, //312
                TyreCompound = input[312], //313
                FrontBrakeBias = input[313], //314
                FuelMix = input[314], //315
                CurrentLapInvalid = input[315], //316
                TyresDamage = new byte[] { input[316], input[317], input[318], input[319] }, //320
                FrontLeftWingDamage = input[320], //321
                FrontRightWingDamage = input[321], //322
                RearWingDamage = input[322], //323
                EngineDamage = input[323], //324
                GearBoxDamage = input[324], //325
                ExhaustDamage = input[325], //326
                PitLimiterStatus = input[326], //327
                PitSpeedLimit = input[327], //328
                SessionTimeLeft = BitConverter.ToSingle(input.Slice(328, 4)), //332
                RevLightsPercent = input[332], //333
                IsSpectating = input[333], //334
                SpectatorCarIndex = input[334], //335
                NumberOfCars = input[335], //336
                PlayerCarIndex = input[336], //337
                //CarData Goes here skip it.
                Yaw = BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize, 4)),
                Pitch = BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize + 4, 4)),
                Roll = BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize + 8, 4)),
                LocalVelocityX = BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize + 12, 4)),
                LocalVelocityY = BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize + 16, 4)),
                LocalVelocityZ = BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize + 20, 4)),
                SuspensionAcceleration = new float[]
                {
                    BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize + 24, 4)),
                    BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize + 28, 4)),
                    BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize + 32, 4)),
                    BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize + 36, 4))
                },
                AngularAccelerationX = BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize + 40, 4)),
                AngularAccelerationY = BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize + 44, 4)),
                AngularAccelerationZ = BitConverter.ToSingle(input.Slice(firstDataSize + carDataSize + 48, 4)),
                
            };

            for (var i = 0; i < 20; i++)
            {
                item.CarData.Add(CarUdpData.Read(input.Slice((i * CarUdpData.Size) + firstDataSize, CarUdpData.Size), item.Era));
            }

            return item;
        }
    }
}
