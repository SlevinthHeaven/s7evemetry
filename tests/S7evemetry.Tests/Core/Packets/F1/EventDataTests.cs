using FluentAssertions;
using Moq;
using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Core.Structures.EventDetails;
using S7evemetry.Tests.Core.Packets.F1.MockPackets;
using System;
using System.Linq;
using System.Text;
using Xunit;

namespace S7evemetry.Tests.Core.Helpers
{
    public class EventDataTests
    {
        [Fact]
        public void EventDataSize()
        {
            var result = EventData.Size;
            result.Should().Be(9);
        }

        [Theory]
        [InlineData(EventCode.CHQF)]
        [InlineData(EventCode.DRSD)]
        [InlineData(EventCode.DRSE)]
        [InlineData(EventCode.SEND)]
        [InlineData(EventCode.SSTA)]
        public void EventDataReadNullReturnData(EventCode input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input.ToString());

            var result = EventData.Read(bytes);

            result.EventCode.Should().Be(input);

                result.EventDetails.Should().BeNull();

        }

        [Theory]
        [InlineData(0, 123)]
        [InlineData(2, 1223)]
        [InlineData(12, 12)]
        [InlineData(3, 234)]
        [InlineData(19, 58)]
        public void EventDataReadFastestLap(byte carIndex, float laptime)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(EventCode.FTLP.ToString())
                .Concat(new byte[] { carIndex })
                .Concat(BitConverter.GetBytes(laptime))
                .ToArray();

            var result = EventData.Read(bytes);

            result.EventDetails.Should().NotBeNull()
                .And.Subject.GetType().Should().Be(typeof(FastestLap));

            result.EventDetails.As<FastestLap>().LapTime.Should().Be(TimeSpan.FromSeconds(laptime));
        }

        [Theory]
        [InlineData(EventCode.RTMT, 0)]
        [InlineData(EventCode.RCWN, 3)]
        [InlineData(EventCode.TMPT, 12)]
        public void EventDataReadEventDetailsCommon(EventCode input, byte carIndex)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input.ToString())
                .Concat(new byte[] { carIndex })
                .ToArray();

            var result = EventData.Read(bytes);

            result.EventDetails.Should().NotBeNull()
                .And.Subject.GetType().Should().Be(typeof(EventDetailsCommon));

            result.EventDetails.As<EventDetailsCommon>();
        }


        [Theory]
        [InlineData(0, 123)]
        [InlineData(2, 1223)]
        [InlineData(12, 12)]
        [InlineData(3, 234)]
        [InlineData(19, 58)]
        public void EventDataReadSpeedTrap(byte carIndex, float speed)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(EventCode.SPTP.ToString())
                .Concat(new byte[] { carIndex })
                .Concat(BitConverter.GetBytes(speed))
                .ToArray();

            var result = EventData.Read(bytes);

            result.EventDetails.Should().NotBeNull()
                .And.Subject.GetType().Should().Be(typeof(SpeedTrap));

            result.EventDetails.As<SpeedTrap>().Speed.Should().Be(speed);
        }


        [Theory]
        [InlineData(0, 123)]
        [InlineData(2, 1223)]
        [InlineData(12, 12)]
        [InlineData(3, 234)]
        [InlineData(19, 58)]
        public void EventDataReadPenalties(byte penaltyType, byte infringementType, 
            byte carIndex, byte otherCarIndex, byte time,
            byte lapNumber, byte placesGained)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(EventCode.PENA.ToString())
                .Concat(new byte[] { penaltyType, infringementType, carIndex, otherCarIndex, time, lapNumber, placesGained })
                .ToArray();

            var result = EventData.Read(bytes);

            result.EventDetails.Should().NotBeNull()
                .And.Subject.GetType().Should().Be(typeof(Penalty));

            result.EventDetails.As<Penalty>()
                .PenaltyType.Should().Be(penaltyType);
        }
    }
}
