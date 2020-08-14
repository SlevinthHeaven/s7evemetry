using S7evemetry.Core;
using S7evemetry.F1_2019.Observers;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Core.Structures;
using System;
using System.Diagnostics;
using S7evemetry.F1_2019.Structures;

namespace S7evemetry.Console
{
    public class F1_2019_Motion : MotionDataObserver

    {
        private static readonly object SyncRoot = new object();

        private const ConsoleColor DefaultValueColor = ConsoleColor.White;
        private const ConsoleColor DefaultEngineLowRpmColor = ConsoleColor.Green;
        private const ConsoleColor DefaultEngineMediumRpmColor = ConsoleColor.Yellow;
        private const ConsoleColor DefaultEngineHighRpmColor = ConsoleColor.Red;
        private const float DefaultEngineMediumRpmPercent = 0.5f; // percent of maximum rpm
        private const float DefaultEngineHighRpmPercent = 0.85f; // percent of maximum rpm

        public virtual ConsoleColor ValueColor { get; set; } = DefaultValueColor;
        public virtual ConsoleColor EngineLowRpmColor { get; set; } = DefaultEngineLowRpmColor;
        public virtual ConsoleColor EngineMediumRpmColor { get; set; } = DefaultEngineMediumRpmColor;
        public virtual ConsoleColor EngineHighRpmColor { get; set; } = DefaultEngineHighRpmColor;
        public virtual float EngineMediumRpmPercent { get; set; } = DefaultEngineMediumRpmPercent;
        public virtual float EngineHighRpmPercent { get; set; } = DefaultEngineHighRpmPercent;

        public override void OnCompleted()
        {
        }
        public override void OnError(DataException error)
        {
        }

        public override void OnError(Exception error)
        {
        }

        public override void OnNext(PacketData<PacketHeader, MotionData, CarMotion> value)
        {
            UpdateUI(value);
        }

        protected virtual void UpdateUI(PacketData<PacketHeader, MotionData, CarMotion> data)
        {
            var index = (int)data.Header.PlayerCarIndex;
            lock (SyncRoot)
            {
                if (data.CarData[index] == null) return;

                // acceleration
                ConsoleWriteAt(13, 8, $"{data.Data.AngularAccelerationX,11:###0.000000}", 11);
                ConsoleWriteAt(25, 8, $"{data.Data.AngularAccelerationY,11:###0.000000}", 11);
                ConsoleWriteAt(37, 8, $"{data.Data.AngularAccelerationZ,11:###0.000000}", 11);

                // velocity
                ConsoleWriteAt(13, 9, $"{data.CarData[index].WorldVelocityX,11:###0.000000}", 11);
                ConsoleWriteAt(25, 9, $"{data.CarData[index].WorldVelocityY,11:###0.000000}", 11);
                ConsoleWriteAt(37, 9, $"{data.CarData[index].WorldVelocityZ,11:###0.000000}", 11);

                // angle
                ConsoleWriteAt(13, 12, $"{data.CarData[index].Yaw,11:###0.000000}", 11);
                ConsoleWriteAt(25, 12, $"{data.CarData[index].Pitch,11:###0.000000}", 11);
                ConsoleWriteAt(37, 12, $"{data.CarData[index].Roll,11:###0.000000}", 11);

                // angular velocity
                ConsoleWriteAt(13, 13, $"{data.Data.AngularVelocityX,11:###0.000000}", 11);
                ConsoleWriteAt(25, 13, $"{data.Data.AngularVelocityY,11:###0.000000}", 11);
                ConsoleWriteAt(37, 13, $"{data.Data.AngularVelocityZ,11:###0.000000}", 11);


                ConsoleWriteAt(56, 1, GetRaceTimeValue(data.Header.SessionTime), 14);


            }
        }

        protected virtual string GetRaceTimeValue(float time)
        {
            TimeSpan ts = TimeSpan.FromSeconds(time);

            string format = ts.Days > 0
                ? "d'.'hh':'mm':'ss'.'fff"
                : ts.Hours > 0
                    ? "hh':'mm':'ss'.'fff"
                    : ts.Minutes > 0
                        ? "mm':'ss'.'fff"
                        : "ss'.'fff";

            return ts.ToString(format).TrimStart('0');
        }

        protected void ConsoleWriteAt(int left, int top, string value, int length, ConsoleColor? color = null)
        {
            int bufferHeight = System.Console.BufferHeight;
            int bufferWidth = System.Console.BufferWidth;

            // avoid buffer-overflow writing
            if (top > bufferHeight || left > bufferWidth)
                return;

            System.Console.SetCursorPosition(left, top);

            int availableChars = Math.Min(length, (bufferWidth - left));
            if (value.Length > availableChars)
            {
                Debug.WriteLine($"Substring occurred on value \"{value}\" because of {availableChars} available chars");

                // substring value according buffer width or value max length
                value = value.Substring(0, availableChars);
            }
            else if (value.Length < availableChars)
            {
                // right-align value
                value = value.PadLeft(availableChars);
            }

            // set foreground color and retain previous one
            ConsoleColor fgColor = color ?? ValueColor;
            ConsoleColor? prevFgColor = null;
            if (System.Console.ForegroundColor != fgColor)
            {
                prevFgColor = System.Console.ForegroundColor;
                System.Console.ForegroundColor = fgColor;
            }

            System.Console.Write(value);

            // restore previous color
            if (prevFgColor.HasValue)
            {
                System.Console.ForegroundColor = prevFgColor.Value;
            }
        }
    }
}
