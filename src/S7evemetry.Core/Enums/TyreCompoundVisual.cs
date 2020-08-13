using System;

namespace S7evemetry.Core.Enums
{
    /// <summary>
    /// F1 visual (can be different from actual compound)
    /// 16 = soft, 17 = medium, 18 = hard, 7 = inter, 8 = wet
    /// F1 Classic – same as above
    /// F2 – same as above
    /// </summary>
    public enum TyreCompoundVisual
    {
        Soft = 16,
        Medium = 17,
        Hard = 18,
        Inter = 7,
        Wet = 8
    }
}
