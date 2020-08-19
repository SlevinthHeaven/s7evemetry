using FluentAssertions;
using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Tests.Core.Packets.F1.MockPackets;
using System;
using System.Text;
using Xunit;

namespace S7evemetry.Tests.Core.Packets.F1
{
    public class ParticipantDataTests
    {
        [Fact]
        public void ParticipantDataSize()
        {
            var result = ParticipantData.Size;
            result.Should().Be(1);
        }

        [Fact]
        public void ParticipantDataWrongSize()
        {
            var result = ParticipantData.Read(new byte[2]);

            result.Should().BeNull();
        }


        [Fact]

        public void ParticipantDataRead()
        {
            var result = ParticipantData.Read(new byte[] { 1 });

            result.Should().NotBeNull().And.Subject.As<ParticipantData>().NumActiveCars.Should().Be(1);
        }
    }
}
