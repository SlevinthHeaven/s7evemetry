using S7evemetry.F1_2017.Structures;
using System;
using System.Collections.Generic;
using System.Text;

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

        public float SpeedMph { get; set; } // Speed of car in MPH

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

        public float[] SuspensionPosition { get; set; }= new float[4]; // Note: All wheel arrays have the order:

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

        public float Era { get; set; }                     // era, 2017 (modern) or 1980 (classic)

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
    }
}
