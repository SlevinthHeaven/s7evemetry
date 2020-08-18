using S7evemetry.Core.Enums.F1;
using S7evemetry.F1_2017.Enums;
using S7evemetry.F1_2017.Helpers;
using System;

namespace S7evemetry.F1_2017.Structures
{
    public class CarUdpData
    {
        /// <summary>
        /// World co-ordinates of vehicle
        /// </summary>
        public float[] WorldPosition { get; set; } = new float[3];

        /// <summary>
        /// Last lap time in seconds
        /// </summary>
        public float LastLapTime { get; set; }

        /// <summary>
        /// Current lap time in seconds
        /// </summary>
        public float CurrentLapTime { get; set; }

        /// <summary>
        /// Best lap time in seconds
        /// </summary>
        public float BestLapTime { get; set; }

        /// <summary>
        /// Sector 1 time in seconds, of current lap (I think)
        /// </summary>
        public float Sector1Time { get; set; }

        /// <summary>
        /// Sector 2 time in seconds, of current lap (I think)
        /// </summary>
        public float Sector2Time { get; set; }

        /// <summary>
        /// Lap Distance, strange this is on each car
        /// </summary>
        public float LapDistance { get; set; }

        /// <summary>
        /// The current driver name
        /// </summary>
        public string Driver { get; set; } = string.Empty;

        /// <summary>
        /// The team of the car
        /// </summary>
        public string Team { get; set; } = string.Empty;

        /// <summary>
        /// track positions of vehicle
        /// </summary>
        public byte CarPosition { get; set; }

        public byte CurrentLapNumber { get; set; }

        /// <summary>
        /// The Tyre Compound in use
        /// </summary>
        public TyreCompound TyreCompound { get; set; }

        /// <summary>
        /// Is the car in the pits
        /// </summary>
        public PitStatus InPits { get; set; }

        /// <summary>
        /// Position in the lap
        /// </summary>
        public Sector Sector { get; set; }

        /// <summary>
        /// Current lap invalid
        /// False = valid
        /// True  = invalid
        /// </summary>
        public bool CurrentLapInvalid { get; set; }

        /// <summary>
        /// accumulated time penalties in seconds to be added
        /// </summary>
        public byte Penalties { get; set; }

        public static int Size { get; } = 45;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A Deserialized version of CarUdpData</returns>
        public static CarUdpData Read(Span<byte> input, Era era)
        {
            return new CarUdpData
            {
                WorldPosition = new float[]
                {
                    BitConverter.ToSingle(input.Slice(0, 4)),
                    BitConverter.ToSingle(input.Slice(4, 4)),
                    BitConverter.ToSingle(input.Slice(8, 4))
                },
                LastLapTime = BitConverter.ToSingle(input.Slice(12, 4)),
                CurrentLapTime = BitConverter.ToSingle(input.Slice(16, 4)),
                BestLapTime = BitConverter.ToSingle(input.Slice(20, 4)),
                Sector1Time = BitConverter.ToSingle(input.Slice(24, 4)),
                Sector2Time = BitConverter.ToSingle(input.Slice(28, 4)),
                LapDistance = BitConverter.ToSingle(input.Slice(32, 4)),
                Driver = era == Era.Modern ? DriverHelper.GetDriverById( input[36]) : DriverHelper.GetClassicDriverById(input[36]),
                Team = era == Era.Modern ? TeamHelper.GetTeamById(input[37]) : TeamHelper.GetClassicTeamById(input[37]),
                CarPosition = input[38],
                CurrentLapNumber = input[39],
                TyreCompound = (TyreCompound)input[40],
                InPits = (PitStatus)input[41],
                Sector = (Sector)input[42],
                CurrentLapInvalid = Convert.ToBoolean(input[43]),
                Penalties = input[44]
            };
        }
    }
}
