using System;

namespace S7evemetry.F1_2020.Structures
{
    public class WeatherForecastSample
    {
        public static int Size { get; } = 5;

        public byte SessionType { get; set; }                    // 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P, 5 = Q1
                                                                 // 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ, 10 = R, 11 = R2
                                                                 // 12 = Time Trial
        public byte TimeOffset { get; set; } // Time in minutes the forecast is for
        public byte Weather { get; set; }// Weather - 0 = clear, 1 = light cloud, 2 = overcast
                                         // 3 = light rain, 4 = heavy rain, 5 = storm
        public sbyte TrackTemperature { get; set; }                // Track temp. in degrees celsius
        public sbyte AirTemperature { get; set; }                // Air temp. in degrees celsius

        public static WeatherForecastSample Read(Span<byte> input)
        {
            return new WeatherForecastSample
            {
                SessionType = input[0],
                TimeOffset = input[1],
                Weather = input[2],
                TrackTemperature = (sbyte)input[3],
                AirTemperature = (sbyte)input[4]
            };
        }
    }
}
