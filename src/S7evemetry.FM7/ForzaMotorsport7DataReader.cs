using S7evemetry.Core.Enums.Forza;
using S7evemetry.Core.Packets.Forza;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace S7evemetry.FM7
{
	public class ForzaMotorsport7DataReader
	{
		private const int SledPacketSize = 232;
		private const int CarDashPacketSize = SledPacketSize + 79;

		public PacketData<SledData>? ReadSled(byte[] input)
		{
			if (input.Length != SledPacketSize) return null;
			PacketData<SledData> output = new PacketData<SledData>();

			var spanData = new Span<byte>(input);

			var sled = SledData.Read(spanData.Slice(0, SledData.Size));
			if (sled != null)
			{
				output.Sled = sled;
			}

			return output;
		}

		public PacketData<SledData, CarDashData>? ReadCarDash(byte[] input)
		{

			if (input.Length != CarDashPacketSize) return null;
			PacketData<SledData, CarDashData> output = new PacketData<SledData, CarDashData>();

			var spanData = new Span<byte>(input);

			var sled = SledData.Read(spanData.Slice(0, SledData.Size));
			if (sled != null)
			{
				output.Sled = sled;
			}

			var carDash = CarDashData.Read(spanData.Slice(SledData.Size, CarDashData.Size));
			if (carDash != null)
			{
				output.CarDash = carDash;
			}

			return output;
		}

	}
}
