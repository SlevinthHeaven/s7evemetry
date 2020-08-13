using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.F1_2020.Packets
{
    public class LobbyInfoData
    {
        public static int Size { get; } = 1;
        public byte NumberOfPlayers { get; set; }
        public static LobbyInfoData Read(Span<byte> input)
        {
            return new LobbyInfoData
            {
                NumberOfPlayers = input[0]
            };
        }
    }
}
