using FluentAssertions;
using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Tests.Core.Structures.MockStructures;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace S7evemetry.Tests.Core.Structures
{
    public class PacketHeaderCommonTests
    {
        private readonly Random _random;

        public PacketHeaderCommonTests()
        {
            _random = new Random();
        }

        [Fact]
        public void PacketHeaderSize()
        {
            var result = PacketHeader.Size;
            result.Should().Be(21);
        }

        [Fact]
        public void PacketHeaderGridSize()
        {
            var result = new  PacketHeader().GridSize;
            result.Should().Be(20);
        }

        [Fact]
        public void PacketHeaderWrongSize()
        {
            var result = PacketHeader.Read(new byte[142]);
            result.Should().BeNull();
        }


        [Fact]
        public void PacketHeaderRead()
        {

            //PacketFormat = (PacketFormat)BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(0, 2)),
               //// PacketVersion = input[2],
               // //PacketId = (PacketType)input[3],
               // //SessionUID = BinaryPrimitives.ReadUInt64LittleEndian(input.Slice(4, 8)),
               // SessionTime = BitConverter.ToSingle(input.Slice(12, 4)),
               // FrameIdentifier = BinaryPrimitives.ReadUInt32LittleEndian(input.Slice(16, 4)),
               // PlayerCarIndex = input[20]



            IEnumerable<byte> data = new List<byte>();

            data = data.Concat(BitConverter.GetBytes((ushort)2020));
            data = data.Concat(new byte[] { 1, 2 });
            data = data.Concat(new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 });

            for (var i = 0; i < 2; i++)
            {
                double mantissa = (_random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, _random.Next(-126, 128));
                data = data.Concat(BitConverter.GetBytes((float)(mantissa * exponent)));
            }

            data = data.Concat(new byte[] { 14 });

         

            var spanInput = new Span<byte>(data.ToArray());
            var result = PacketHeader.Read(spanInput);
            result.Should().NotBeNull();
            if (result != null)
            {
                result.PacketFormat.Should().Be(PacketFormat.F1_2020);
                result.PacketVersion.Should().Be(1);
                result.PacketId.Should().Be(PacketType.LapData);
                result.SessionUID.Should().Be(BinaryPrimitives.ReadUInt64LittleEndian(spanInput.Slice(4, 8)));
                result.SessionTime.Should().Be(BitConverter.ToSingle(spanInput.Slice(12, 4)));
                result.FrameIdentifier.Should().Be(BinaryPrimitives.ReadUInt32LittleEndian(spanInput.Slice(16, 4)));
                result.PlayerCarIndex.Should().Be(14);
                
            }
        }
    }
}
