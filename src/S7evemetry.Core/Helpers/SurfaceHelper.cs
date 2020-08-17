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
            string? result;
            switch (id)
            {
                case 0: result = "Tarmac"; break;
                case 1: result = "Rumble strip"; break;
                case 2: result = "Concrete"; break;
                case 3: result = "Rock"; break;
                case 4: result = "Gravel"; break;
                case 5: result = "Mud"; break;
                case 6: result = "Sand"; break;
                case 7: result = "Grass"; break;
                case 8: result = "Water"; break;
                case 9: result = "Cobblestone"; break;
                case 10: result = "Metal"; break;
                case 11: result = "Ridged"; break;
                default: result = "Unknown"; break;
            }
            return result;
        }
    }
}
