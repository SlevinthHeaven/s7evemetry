
using S7evemetry.Core;
using S7evemetry.F1_2017.Packets;
using System;

namespace S7evemetry.F1_2017.Observers
{
    public abstract class UdpPacketDataObserver : IObserver<UdpPacketData>
    {
        private IDisposable? _unsubscriber;

        public void Subscribe(IObservable<UdpPacketData> listener)
        {
            _unsubscriber = listener.Subscribe(this);
        }

        public void Unsubscribe()
        {
            if (_unsubscriber != null)
            {
                _unsubscriber.Dispose();
                _unsubscriber = null;
            }
        }

        public abstract void OnCompleted();

        public abstract void OnError(DataException error);

        public abstract void OnError(Exception error);

        public abstract void OnNext(UdpPacketData value);
    }
}
