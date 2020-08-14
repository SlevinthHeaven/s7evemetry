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

			output.Sled = SledData.Read(spanData.Slice(0, SledData.Size));

			return output;
		}

		public PacketData<SledData, CarDashData>? ReadCarDash(byte[] input)
		{

			if (input.Length != CarDashPacketSize) return null;
			PacketData<SledData, CarDashData> output = new PacketData<SledData, CarDashData>();

			var spanData = new Span<byte>(input);

			output.Sled = SledData.Read(spanData.Slice(0, SledData.Size));
			output.CarDash = CarDashData.Read(spanData.Slice(SledData.Size, CarDashData.Size));

			return output;
		}

	}
}
