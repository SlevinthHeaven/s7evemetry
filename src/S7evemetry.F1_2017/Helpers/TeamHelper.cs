namespace S7evemetry.F1_2017.Helpers
{
    public static class TeamHelper
    {
        public static string GetTeamById(int id)
        {
            switch (id)
            {
                case 0: return "Red Bull";
                case 1: return "Ferrari";
                case 2: return "McLaren";
                case 3: return "Renault";
                case 4: return "Mercedes";
                case 5: return "Sauber";
                case 6: return "Force India";
                case 7: return "Williams";
                case 8: return "Toro Rosso";
                case 11: return "Haas";
                default: return "Unknown";
            }
        }

        public static string GetClassicTeamById(int id)
        {
            switch (id)
            {
                case 0: return "Williams 1992";
                case 1: return "McLaren 1988";
                case 2: return "McLaren 2008";
                case 3: return "Ferrari 2004";
                case 4: return "Ferrari 1995";
                case 5: return "Ferrari 2007";
                case 6: return "McLaren 1998";
                case 7: return "Williams 1996";
                case 8: return "Renault 2006";
                case 10: return "Ferrari 2002";
                case 11: return "Red Bull 2010";
                case 12: return "McLaren 1991";
                default: return "Unknown";
            }
        }
    }
}
