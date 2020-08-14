using S7evemetry.Core;
using S7evemetry.Core.Packets.F1;
using S7evemetry.F1_2020.Structures;
using System;

namespace S7evemetry.F1_2020.Observers
{
    public abstract class LapDataObserver : IObserver<PacketData<PacketHeader, LapData, CarLap>>
    {
        private IDisposable? _unsubscriber;

        public void Subscribe(IObservable<PacketData<PacketHeader, LapData, CarLap>> listener)
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

        public abstract void OnNext(PacketData<PacketHeader, LapData, CarLap> value);
    }
}
