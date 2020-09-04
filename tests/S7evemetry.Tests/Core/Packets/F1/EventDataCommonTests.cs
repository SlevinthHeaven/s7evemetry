using FluentAssertions;
using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Tests.Core.Packets.F1.MockPackets;
using System.Text;
using Xunit;

namespace S7evemetry.Tests.Core.Packets.F1
{
    public class EventDataCommonTests
    {


        [Theory]
        [InlineData(EventCode.SSTA)]
        [InlineData(EventCode.SEND)]
        [InlineData(EventCode.RTMT)]
        [InlineData(EventCode.FTLP)]
        [InlineData(EventCode.DRSE)]
        [InlineData(EventCode.DRSD)]
        [InlineData(EventCode.TMPT)]
        [InlineData(EventCode.CHQF)]
        [InlineData(EventCode.RCWN)]
        [InlineData(EventCode.SPTP)]
        [InlineData(EventCode.PENA)]

        public void EventDataCommonRead(EventCode input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input.ToString());
            var result = EventData.Read(bytes);

            result.Should().NotBeNull().And.Subject.As<EventData>().EventCode.Should().Be(input);
        }
        [Fact]
        public void EventDataCommonSize()
        {
            var result = EventDataCommon.Size;
            result.Should().Be(4);
        }

        [Fact]
        public void EventDataCommonWrongSize()
        {
            var result = EventData.Read(new byte[5]);

            result.Should().BeNull();
        }
    }
}
