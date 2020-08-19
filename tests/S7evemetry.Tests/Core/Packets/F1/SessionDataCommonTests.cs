using FluentAssertions;
using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Tests.Core.Packets.F1.MockPackets;
using System;
using System.Linq;
using System.Text;
using Xunit;

namespace S7evemetry.Tests.Core.Packets.F1
{
    public class SessionDataCommonTests
    {
        [Fact]
        public void SessionDataCommonSize()
        {
            var result = SessionData.Size;
            result.Should().Be(126);
        }

        [Fact]
        public void SessionDataCommonWrongSize()
        {
            var result = SessionData.Read(new byte[128]);

            result.Should().BeNull();
        }


        [Fact]
        public void SessionDataCommonRead()
        {
            byte[] bytes = new byte[] { 
                1,2,3,4,5,0,6,7,0, 12,0, 13,0,12,0,1,1,0,21
            };

            for (var i = 0; i< 21;  i++)
            {
                bytes = bytes.Concat(BitConverter.GetBytes(0.1f)).ToArray();
                bytes = bytes.Concat(new byte[] { 0 }).ToArray();
            }

            bytes = bytes.Concat(new byte[] { 0, 0 }).ToArray();

            var result = SessionData.Read(bytes);
            result.Should().NotBeNull();
            if (result != null)
            {
                result.Weather.Should().Be(1);
                result.TrackTemperature.Should().Be(2);
                result.AirTemperature.Should().Be(3);
                result.TotalLaps.Should().Be(4);
                result.TrackLength.Should().Be(5);
                result.SessionType.Should().Be(6);
                result.Track.Should().Be("Silverstone");
                result.Formula.Should().Be(0);
                result.SessionTimeLeft.Should().Be(12);
                result.SessionDuration.Should().Be(13);
                result.PitSpeedLimit.Should().Be(12);
                result.GamePaused.Should().Be(0);
                result.IsSpectating.Should().Be(1);
                result.SpectatorCarIndex.Should().Be(1);
                result.SliProNativeSupport.Should().Be(0);
                result.NumMarshalZones.Should().Be(21);

                result.MarshalZones[0].ZoneFlag.Should().Be(0);
                result.MarshalZones.Length.Should().Be(21);
                result.SafetyCarStatus.Should().Be(0);
                result.NetworkGame.Should().Be(0);
            }
                
        }
    }
}
