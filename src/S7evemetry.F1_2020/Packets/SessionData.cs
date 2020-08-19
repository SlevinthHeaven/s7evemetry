using S7evemetry.Core.Packets.F1;
using S7evemetry.F1_2020.Structures;
using System;

namespace S7evemetry.F1_2020.Packets
{
    public class SessionData : SessionDataCommon
    {
        public static new int Size { get; } = 227;
        public byte NumberOfWeatherForecastSamples; // Number of weather samples to follow
        public WeatherForecastSample[] WeatherForecastSamples { get; set; } = new WeatherForecastSample[20];   // Array of weather forecast samples

        public static SessionData? Read(Span<byte> input)
        {
            if (input.Length != 227) return null;

            var baseData = Read<SessionData>(input.Slice(0, 126));

            if (baseData == null) return null;

            baseData.NumberOfWeatherForecastSamples = input[126];

            for (var i = 0; i < 20; i++)
            {
                baseData.WeatherForecastSamples[i] = WeatherForecastSample.Read(input.Slice(18 + (i * WeatherForecastSample.Size), WeatherForecastSample.Size));
            }

            return baseData;
        }

    }
}
