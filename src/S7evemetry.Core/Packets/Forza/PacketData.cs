namespace S7evemetry.Core.Packets.Forza
{

    public class PacketData<SledDataType>
        where SledDataType : SledData, new()
    {
        public SledDataType Sled { get; set; } = new SledDataType();

    }

    public class PacketData<SledDataType, CarDashDataType>
        where SledDataType : SledData, new()
        where CarDashDataType: CarDashData, new()
    {
        public SledDataType Sled { get; set; } = new SledDataType();
        public CarDashDataType CarDash { get; set; } = new CarDashDataType();

    }

}
