using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.Core.Enums
{
    /// <summary>
    /// Result status - 0 = invalid, 1 = inactive, 
    /// 2 = active,3 = finished, 4 = disqualified, 
    /// 5 = not classified, 6 = retired
    /// </summary>
    public enum ResultStatus
    {
        Invalid = 0,
        Inactive = 1,
        Active = 2,
        Finished = 3,
        Disqualified = 4,
        NotClassified = 5,
        Retired = 6
    }
}
