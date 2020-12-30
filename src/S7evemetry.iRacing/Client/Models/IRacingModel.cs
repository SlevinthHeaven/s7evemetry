using irsdkSharp.Serialization.Models.Data;
using irsdkSharp.Serialization.Models.Session;

namespace S7evemetry.iRacing.Client.Models
{
    public class IRacingModel
    {
        public IRacingDataModel? Data { get; set; }
        public IRacingSessionModel? Session { get; set; }
    }
}
