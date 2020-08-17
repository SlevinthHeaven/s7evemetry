using S7evemetry.Core.Enums.F1;

namespace S7evemetry.F1_Legacy.Helpers
{
    public static class TeamHelper
    {
        public static string GetTeamById(int id)
        {
            switch (id)
            {
                case 0: return "Mercedes";
                case 1: return "Ferrari";
                case 2: return "Red Bull";
                case 3: return "Williams";
                case 4: return "Force India";
                case 5: return "Renault";
                case 6: return "Toro Rosso";
                case 7: return "Haas";
                case 8: return "McLaren";
                case 9: return "Sauber";
                case 10: return "McLaren 1988";
                case 11: return "McLaren 1991";
                case 12: return "Williams 1992";
                case 13: return "Ferrari 1995";
                case 14: return "Williams 1996";
                case 15: return "McLaren 1998";
                case 16: return "Ferrari 2002";
                case 17: return "Ferrari 2004";
                case 18: return "Renault 2006";
                case 19: return "Ferrari 2007";
                case 20: return "McLaren 2008";
                case 21: return "Red Bull 2010";
                case 22: return "Ferrari 1976";
                case 34: return "McLaren 1976";
                case 35: return "Lotus 1972";
                case 36: return "Ferrari 1979";
                case 37: return "McLaren 1982";
                case 38: return "Williams 2003";
                case 39: return "Brawn 2009";
                case 40: return "Lotus 1978";
                default:
                    break;
            }
            return "";
        }
    }
}
