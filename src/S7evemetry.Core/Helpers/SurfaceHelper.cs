namespace S7evemetry.Core.Helpers
{
    public static class SurfaceHelper
    {
        /// <summary>
        /// Convert the SurfaceId into the Surface Name
        /// </summary>
        /// <param name="id">The Id of the Surface</param>
        /// <returns>String representing the name of the Surface</returns>
        public static string GetSurfaceById(int id)
        {
            return id switch
            {
                0 => "Tarmac",
                1 => "Rumble strip",
                2 => "Concrete",
                3 => "Rock",
                4 => "Gravel",
                5 => "Mud",
                6 => "Sand",
                7 => "Grass",
                8 => "Water",
                9 => "Cobblestone",
                10 => "Metal",
                11 => "Ridged",
                _ => "",
            };
        }
    }
}
