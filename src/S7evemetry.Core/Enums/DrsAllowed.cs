using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.Core.Enums
{
    /// <summary>
    /// 0 = not allowed, 1 = allowed, -1 = unknown
    /// </summary>
    public enum DrsAllowed
    {
        NotAllowed = 0,
        Allowed = 1,
        Unknown = -1,
    }
}
