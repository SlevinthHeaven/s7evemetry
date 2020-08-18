using S7evemetry.Core;
using S7evemetry.F1_2017.Observers;
using S7evemetry.F1_2017.Packets;
using System;
using System.Diagnostics;

namespace S7evemetry.Console._2017
{
    public class F1_2017_Telemetry : UdpPacketDataObserver
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

		public override void OnNext(UdpPacketData value)
		{
			UpdateUI(value);
		}

		protected virtual void UpdateUI(UdpPacketData data)
		{
			var index = (int)data.PlayerCarIndex;
            lock (SyncRoot)
            {
                // engine
                ConsoleWriteAt(7, 3, $"{data.EngineRate, 6:#####0}", 6);


                ////// speed, power, torque
                ConsoleWriteAt(27, 4, $"{data.Speed * 1.6, 7:####0.0}", 7);
                ConsoleWriteAt(27, 5, $"{data.Speed, 7:####0.0}", 7);

                //// controls
                ConsoleWriteAt(63, 7, $"{data.Throttle * 100f, 3:##0}", 3);
                ConsoleWriteAt(63, 8, $"{data.Brake * 100f, 3:##0}", 3);
                ConsoleWriteAt(63, 9, $"{data.Clutch * 100f, 3:##0}", 3);
                ConsoleWriteAt(63, 10, $"{data.EngineTemperature, 3:##0}", 3);
                ConsoleWriteAt(63, 11, $"{data.Gear, 3:##0}", 3);
                ConsoleWriteAt(62, 12, $"{data.Steer * 100f, 3:+0;-0;0}", 4);
            }
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
