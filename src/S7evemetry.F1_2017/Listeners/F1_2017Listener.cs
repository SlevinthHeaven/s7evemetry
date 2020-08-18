using Microsoft.Extensions.Options;
using S7evemetry.Core;
using S7evemetry.F1_2017.Packets;
using S7evemetry.F1_2017.Readers;
using S7evemetry.Udp;
using System;
using System.Collections.Generic;

namespace S7evemetry.F1_2017.Listeners
{
    public class F1_2017Listener : UdpStreamListener, IObservable<UdpPacketData>
    {
        private readonly ICollection<IObserver<UdpPacketData>> _udpDataObservers;
        private readonly UdpPacketDataReader _udpDataReader;

        public F1_2017Listener(IOptions<UdpListenerSettings> options) : base(options)
        {
            _udpDataObservers = new List<IObserver<UdpPacketData>>();

            _udpDataReader = new UdpPacketDataReader();
        }

        public IDisposable Subscribe(IObserver<UdpPacketData> observer)
        {
            if (!_udpDataObservers.Contains(observer))
            {
                _udpDataObservers.Add(observer);
            }
            return new Unsubscriber<UdpPacketData>(_udpDataObservers, observer);
        }

        protected override void NotifyData(byte[] data)
        {
            base.NotifyData(data);

            try
            {
                var udpDataPacket = _udpDataReader.Read(new Span<byte>(data));
                if (udpDataPacket != null)
                    NotifyData(udpDataPacket);
            }
            catch (Exception ex)
            {
                // read exception: notified to observers
                NotifyError(new DataException("An error occurred while trying to read data", ex));
            }
        }

        protected void NotifyData(UdpPacketData data)
        {
            foreach (var observer in _udpDataObservers)
            {
                observer.OnNext(data);
            }
        }

        protected void NotifyError(DataException error)
        {
            foreach (var observer in _udpDataObservers)
            {
                observer.OnError(error);
            }
        }

        protected override void NotifyCompletion()
        {
            base.NotifyCompletion();

            foreach (var observer in _udpDataObservers)
            {
                observer.OnCompleted();
            }
        }
    }
}
