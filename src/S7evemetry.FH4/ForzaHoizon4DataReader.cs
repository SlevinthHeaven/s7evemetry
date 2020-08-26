using S7evemetry.Core.Enums.Forza;
using S7evemetry.Core.Packets.Forza;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace S7evemetry.FH4
{
	public class ForzaHorizon4DataReader
	{
		private static int Size { get; } = 324;

		public PacketData<SledData, CarDashData>? Read(byte[] input)
		{
			if (input.Length != Size) return null;
			PacketData<SledData, CarDashData> output = new PacketData<SledData, CarDashData>();

			var spanData = new Span<byte>(input);

			var sled = SledData.Read(spanData.Slice(0, SledData.Size));
			if(sled != null)
			{
				output.Sled = sled;
			}

			var carDash = CarDashData.Read(spanData.Slice(SledData.Size + 12, CarDashData.Size));
			if (carDash != null)
			{
				output.CarDash = carDash;
			}


			return output;
		}

		//private byte[] ReadHorizonData1(BinaryReader reader)
		//{
		//	return reader.ReadBytes(12);
		//}

		//private byte[] ReadHorizonData2(BinaryReader reader)
		//{
		//	int length = (int)(reader.BaseStream.Length - reader.BaseStream.Position);
		//	return reader.ReadBytes(length);
		//}
	}
}
