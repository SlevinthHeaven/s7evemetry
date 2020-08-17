using System;

namespace S7evemetry.Core.Enums.F1
{
    /// <summary>
    /// Bit flags specifying which buttons are being pressed currently
    /// </summary>
    [Flags]
    public enum Buttons
    {
        /// <summary>
        /// No buttons pressed
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// 0x0001	Cross or A
        /// </summary>
        A = 0x0001,

        /// <summary>
        /// 0x0002	Triangle or Y
        /// </summary>
        Y = 0x0002,

        /// <summary>
        /// 0x0004	Circle or B
        /// </summary>
        B = 0x0004,

        /// <summary>
        /// 0x0008	Square or X
        /// </summary>
        X = 0x0008,

        /// <summary>
        /// 0x0010	D-pad Left
        /// </summary>
        DLeft = 0x0010,

        /// <summary>
        /// 0x0020	D-pad Right
        /// </summary>
        DRight = 0x0020,

        /// <summary>
        /// 0x0040	D-pad Up
        /// </summary>
        DUp = 0x0040,

        /// <summary>
        /// 0x0080	D-pad Down
        /// </summary>
        DDown = 0x0080,

        /// <summary>
        /// 0x0100	Options or Menu
        /// </summary>
        Menu = 0x0100,

        /// <summary>
        /// 0x0200	L1 or LB
        /// </summary>
        LB = 0x0200,

        /// <summary>
        /// 0x0400	R1 or RB
        /// </summary>
        RB = 0x0400,

        /// <summary>
        /// 0x0800	L2 or LT
        /// </summary>
        LT = 0x0800,

        /// <summary>
        /// 0x1000	R2 or RT
        /// </summary>
        RT = 0x1000,

        /// <summary>
        /// 0x2000	Left Stick Click
        /// </summary>
        LeftStick = 0x2000,

        /// <summary>
        /// 0x4000	Right Stick Click
        /// </summary>
        RightStick = 0x4000
    }
}
