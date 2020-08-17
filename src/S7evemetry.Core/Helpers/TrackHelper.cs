namespace S7evemetry.Core.Helpers
{
    public static class TrackHelper
    {

        /// <summary>
        /// Convert the TrackId into the Track Name
        /// </summary>
        /// <param name="id">The Id of the Track</param>
        /// <returns>String representing the name of the Track</returns>
        public static string GetTrackById(int id)
        {
            var result = "Unknown";
            switch (id)
            {
                case 0: result = "Melbourne"; break;
                case 1: result = "Paul Ricard"; break;
                case 2: result = "Shanghai"; break;
                case 3: result = "Sakhir (Bahrain)"; break;
                case 4: result = "Catalunya"; break;
                case 5: result = "Monaco"; break;
                case 6: result = "Montreal"; break;
                case 7: result = "Silverstone"; break;
                case 8: result = "Hockenheim"; break;
                case 9: result = "Hungaroring"; break;
                case 10: result = "Spa"; break;
                case 11: result = "Monza"; break;
                case 12: result = "Singapore"; break;
                case 13: result = "Suzuka"; break;
                case 14: result = "Abu Dhabi"; break;
                case 15: result = "Texas"; break;
                case 16: result = "Brazil"; break;
                case 17: result = "Austria"; break;
                case 18: result = "Sochi"; break;
                case 19: result = "Mexico"; break;
                case 20: result = "Baku (Azerbaijan)"; break;
                case 21: result = "Sakhir Short"; break;
                case 22: result = "Silverstone Short"; break;
                case 23: result = "Texas Short"; break;
                case 24: result = "Suzuka Short"; break;
                case 25: result = "Hanoi"; break;
                case 26: result = "Zandvoort"; break;
                default: result = "Unknown"; break;
            }
            return result;
        }

    } 
}
