using S7evemetry.Core.Enums.Forza;
using S7evemetry.Core.Packets.Forza;
using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.FM7
{
	/// <summary>
	/// Forza Horizon 4 / Forza Motorsport 7 Data Out structure
	/// </summary>
	public struct ForzaDataStruct
	{
		/// <summary>
		/// Protocol version
		/// </summary>
		public PacketFormat Version;

		/// <summary>
		/// Sled data
		/// </summary>
		public SledData Sled;

		/// <summary>
		/// Car dash data
		/// </summary>
		public CarDashData CarDash;

		/// <summary>
		/// Horizon specific data part 1
		/// </summary>
		public byte[] HorizonData1;

		/// <summary>
		/// Horizon specific data part 2
		/// </summary>
		public byte[] HorizonData2;
	}
}
