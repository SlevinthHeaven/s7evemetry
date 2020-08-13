using S7evemetry.Core.Packets;
using System;

namespace S7evemetry.F1_2020.Packets
{
    public class CarTelemetryData : CarTelemetryDataCommon
    {
        public static new int Size { get; } = 7;
        /// <summary>
        /// Index of MFD panel open - 255 = MFD closed
        /// Single player, race – 0 = Car setup, 1 = Pits
        /// 2 = Damage, 3 =  Engine, 4 = Temperatures
        /// May vary depending on game mode
        /// </summary>
        public byte MfdPanelIndex { get; set; }

        /// <summary>
        /// Index of MFD panel open - 255 = MFD closed
        /// Single player, race – 0 = Car setup, 1 = Pits
        /// 2 = Damage, 3 =  Engine, 4 = Temperatures
        /// May vary depending on game mode
        /// </summary>
        public byte MfdPanelIndexSecondaryPlayer { get; set; }

        /// <summary>
        /// Suggested gear for the player (1-8)
        /// 0 if no gear suggested
        /// </summary>
        public sbyte SuggestedGear { get; set; }

        public static CarTelemetryData Read(Span<byte> input)
        {
            var telemData =  Read<CarTelemetryData>(input);

            telemData.MfdPanelIndex = input[4];
            telemData.MfdPanelIndexSecondaryPlayer = input[5];
            telemData.SuggestedGear = (sbyte)input[6];

            return telemData;
        }
    }
}
