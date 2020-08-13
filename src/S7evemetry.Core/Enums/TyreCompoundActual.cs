using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.Core.Enums
{
    /// <summary>
    /// F1 Modern - 16 = C5, 17 = C4, 18 = C3, 19 = C2, 20 = C1
    /// 7 = inter, 8 = wet
    /// F1 Classic - 9 = dry, 10 = wet
    /// F2 – 11 = super soft, 12 = soft, 13 = medium, 14 = hard
    /// 15 = wet
    /// </summary>
    public enum TyreCompoundActual
    {
        C5 = 16,
        C4 = 17,
        C3 = 18,
        C2 = 19,
        C1 = 20,
        Inter = 7,
        Wet = 8,
        ClassicDry = 9,
        ClassicWet = 10,
        F2SuperSoft = 11,
        F2Soft = 12,
        F2Medium = 13,
        F2Hard = 14,
        F2Wet = 15
    }
}
