using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.Core.Enums
{
    /// <summary>
    /// ERS deployment mode, 0 = none, 1 = low, 
    /// 2 = medium, 3 = high, 4 = overtake, 5 = hotlap
    /// </summary>
    public enum ErsDeployMode
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Overtake = 4,
        Hotlap = 5
    }
}
