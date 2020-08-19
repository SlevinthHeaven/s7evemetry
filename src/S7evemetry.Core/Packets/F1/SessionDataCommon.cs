using S7evemetry.Core.Helpers;
using S7evemetry.Core.Structures;
using System;
using System.Buffers.Binary;

namespace S7evemetry.Core.Packets.F1
{
	/// <summary>
	/// The base packet data which comes with each Session PacketType
	/// </summary>
	public abstract class SessionDataCommon
	{
		/// <summary>
		/// Weather - 0 = clear, 1 = light cloud, 2 = overcast, 
		/// 3 = light rain, 4 = heavy rain, 5 = storm
		/// </summary>
		public byte Weather { get; set; }

		/// <summary>
		/// Track temp. in degrees celsius
		/// </summary>
		public sbyte TrackTemperature { get; set; }

		/// <summary>
		/// Air temp. in degrees celsius
		/// </summary>
		public sbyte AirTemperature { get; set; }

		/// <summary>
		/// Total number of laps in this race
		/// </summary>
		public byte TotalLaps { get; set; }

		/// <summary>
		/// Track length in metres
		/// </summary>
		public ushort TrackLength { get; set; }

		/// <summary>
		/// 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P, 
		/// 5 = Q1, 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ, 
		/// 10 = R, 11 = R2, 12 = Time Trial
		/// </summary>
		public byte SessionType { get; set; }

		/// <summary>
		/// Converted version of the current track as string, defaults to "Unknown"
		/// -1 = Unknown
		/// 0 = Melbourne
		/// 1 = Paul Ricard
		/// 2 = Shanghai
		/// 3 = Sakhir (Bahrain)
		/// 4 = Catalunya
		/// 5 = Monaco
		/// 6 = Montreal
		/// 7 = Silverstone
		/// 8 = Hockenheim
		/// 9 = Hungaroring
		/// 10 = Spa
		/// 11 = Monza
		/// 12 = Singapore
		/// 13 = Suzuka
		/// 14 = Abu Dhabi
		/// 15 = Texas
		/// 16 = Brazil
		/// 17 = Austria
		/// 18 = Sochi
		/// 19 = Mexico
		/// 20 = Baku (Azerbaijan)
		/// 21 = Sakhir Short
		/// 22 = Silverstone Short
		/// 23 = Texas Short
		/// 24 = Suzuka Short
		/// 25 = Hanoi
		/// 26 = Zandvoort
		/// </summary>
		public string Track { get; protected set; } = "Unknown";

		/// <summary>
		/// Formula, 0 = F1 Modern, 1 = F1 Classic, 2 = F2, 3 = F1 Generic
		/// </summary>
		public byte Formula { get; set; }

		/// <summary>
		/// Time left in session in seconds
		/// </summary>
		public ushort SessionTimeLeft { get; set; }

		/// <summary>
		/// Session duration in seconds
		/// </summary>
		public ushort SessionDuration { get; set; }

		/// <summary>
		/// Pit speed limit in kilometres per hour
		/// </summary>
		public byte PitSpeedLimit { get; set; }

		/// <summary>
		/// Whether the game is paused
		/// </summary>
		public byte GamePaused { get; set; }

		/// <summary>
		/// Whether the player is spectating
		/// </summary>
		public byte IsSpectating { get; set; }

		/// <summary>
		/// Index of the car being spectated
		/// </summary>
		public byte SpectatorCarIndex { get; set; }

		/// <summary>
		/// SLI Pro support, 0 = inactive, 1 = active
		/// </summary>
		public byte SliProNativeSupport { get; set; }

		/// <summary>
		/// Number of marshal zones to follow
		/// </summary>
		public byte NumMarshalZones { get; set; }

		/// <summary>
		/// List of marshal zones – max 21
		/// </summary>
		public MarshalZone[] MarshalZones { get; } = new MarshalZone[21];

		/// <summary>
		/// 0 = no safety car, 1 = full safety car, 2 = virtual safety car
		/// </summary>
		public byte SafetyCarStatus { get; set; }

		/// <summary>
		/// 0 = offline, 1 = online
		/// </summary>
		public byte NetworkGame { get; set; }

		/// <summary>
		/// Size in bytes of the base data contained in the SessionData PacketType
		/// </summary>
		public static int Size { get; } = 126;

		/// <summary>
		/// Reads the common data for SessionData packets.
		/// </summary>
		/// <typeparam name="T">An inherited Type of SessionDataCommon</typeparam>
		/// <param name="input">
		/// The Span of byte which contain the common Session data packet
		/// </param>
		/// <returns>Instance of T with deserialized data from input</returns>
		protected static T? Read<T>(Span<byte> input) where T : SessionDataCommon, new()
		{
			if (input.Length != 126) return null;
			var output = new T
			{
				Weather = input[0],
				TrackTemperature = (sbyte)input[1],
				AirTemperature = (sbyte)input[2],
				TotalLaps = input[3],
				TrackLength = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(4, 2)),
				SessionType = input[6],
				Track = TrackHelper.GetTrackById((sbyte)input[7]),
				Formula = input[8],
				SessionTimeLeft = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(9, 2)),
				SessionDuration = BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(11, 2)),
				PitSpeedLimit = input[13],
				GamePaused = input[14],
				IsSpectating = input[15],
				SpectatorCarIndex = input[16],
				SliProNativeSupport = input[17],
				NumMarshalZones = input[18],
				SafetyCarStatus = input[124],
				NetworkGame = input[125]
			};

			for (var i = 0; i < 21; i++)
			{
				output.MarshalZones[i] = MarshalZone.Read(input.Slice(19 + (i * MarshalZone.Size), MarshalZone.Size));
			}
			return output;

		}
	}
}
