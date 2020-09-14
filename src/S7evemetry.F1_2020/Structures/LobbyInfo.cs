using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Helpers;
using S7evemetry.F1_2020.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.F1_2020.Structures
{
    public class LobbyInfo
    {
        /// <summary>
        /// Whether the vehicle is AI (1) or Human (0) controlled
        /// </summary>
        public bool AiControlled { get; set; }

        /// <summary>
        /// byte of TeamId converted to string
        /// </summary>  
        public string Team { get; set; } = string.Empty;

        /// <summary>
        /// Nationality of the driver
        /// byte of Nationality converted to string
        /// </summary>  
        public string Nationality { get; set; } = string.Empty;

        /// <summary>
        /// Name of participant in UTF-8 format – null terminated [48 bytes long]
        /// Will be truncated with … (U+2026) if too long
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 0 = not ready, 1 = ready, 2 = spectating
        /// </summary>
        public byte ReadyStatus { get; set; }

        public static int Size { get; } = 52;

        public static LobbyInfo Read(Span<byte> input)
        {
            return new LobbyInfo
            {
                AiControlled = Convert.ToBoolean(input[0]), //1
                Team = TeamHelper.GetTeamById(input[2]), //2
                Nationality = NationalityHelper.GetNationalityById(input[1]), //3
                Name = Encoding.UTF8.GetString(input.Slice(3, 48)).Trim('\0'), //51
                ReadyStatus = input[51]
            };
        }
    }
}
