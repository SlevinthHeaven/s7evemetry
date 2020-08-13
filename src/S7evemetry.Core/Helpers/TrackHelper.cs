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
            return id switch
            {
                0 => "Melbourne",
                1 => "Paul Ricard",
                2 => "Shanghai",
                3 => "Sakhir (Bahrain)",
                4 => "Catalunya",
                5 => "Monaco",
                6 => "Montreal",
                7 => "Silverstone",
                8 => "Hockenheim",
                9 => "Hungaroring",
                10 => "Spa",
                11 => "Monza",
                12 => "Singapore",
                13 => "Suzuka",
                14 => "Abu Dhabi",
                15 => "Texas",
                16 => "Brazil",
                17 => "Austria",
                18 => "Sochi",
                19 => "Mexico",
                20 => "Baku (Azerbaijan)",
                21 => "Sakhir Short",
                22 => "Silverstone Short",
                23 => "Texas Short",
                24 => "Suzuka Short",
                25 => "Hanoi",
                26 => "Zandvoort",
                _ => "Unknown",
            };
        }
    }
}
