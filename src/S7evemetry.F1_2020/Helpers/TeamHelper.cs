using S7evemetry.Core.Enums.F1;

namespace S7evemetry.F1_2020.Helpers
{
    public static class TeamHelper
    {
        public static string GetTeamById(int id)
        {
            switch (id)
            {
                case 0: return "Mercedes";
                case 1: return "Ferrari";
                case 2: return "Red Bull Racing";
                case 3: return "Williams";
                case 4: return "Racing Point";
                case 5: return "Renault";
                case 6: return "Alpha Tauri";
                case 7: return "Haas";
                case 8: return "McLaren";
                case 9: return "Alfa Romeo";
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
                case 23: return "ART Grand Prix";
                case 24: return "Campos Vexatec Racing";
                case 25: return "Carlin";
                case 26: return "Charouz Racing System";
                case 27: return "DAMS";
                case 28: return "Russian Time";
                case 29: return "MP Motorsport";
                case 30: return "Pertamina";
                case 31: return "McLaren 1991";
                case 32: return "Trident";
                case 33: return "BWT Arden";
                case 34: return "McLaren 1976";
                case 35: return "Lotus 1972";
                case 36: return "Ferrari 1979";
                case 37: return "McLaren 1982";
                case 38: return "Williams 2003";
                case 39: return "Brawn 2009";
                case 40: return "Lotus 1978";
                case 41: return "F1 Generic car";
                case 42: return "Art GP ’19";
                case 43: return "Campos ’19";
                case 44: return "Carlin ’19";
                case 45: return " Sauber Junior Charouz ’19";
                case 46: return " Dams ’19";
                case 47: return " Uni-Virtuosi ‘19";
                case 48: return " MP Motorsport ‘19";
                case 49: return " Prema ’19";
                case 50: return " Trident ’19";
                case 51: return " Arden ’19";
                case 53: return "Benetton 1994";
                case 54: return "Benetton 1995";
                case 55: return "Ferrari 2000";
                case 56: return "Jordan 1991";
                case 255: return "My Team ";
                default:
                    break;
            }
            return "";
        }
    }
}
