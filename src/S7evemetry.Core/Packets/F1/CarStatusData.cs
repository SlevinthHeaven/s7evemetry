namespace S7evemetry.Core.Packets.F1
{
    /// <summary>
    /// The base CarStatus Packet does not contain extra data
    /// this is base class with base size incase data is added in the future.
    /// </summary>
    public class CarStatusData
    {
        /// <summary>
        /// As we are using this as a base that currently holds no data we always return a size of 0 (zero)
        /// </summary>
        public static int Size { get; } = 0;
    }
}
