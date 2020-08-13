
using System;

namespace S7evemetry.Udp
{
    public abstract class MemoryUdpStreamObserver : IObserver<Memory<byte>>
	{
		private IDisposable? _unsubscriber;

		public MemoryUdpStreamObserver()
		{
			
		}

		public void Subscribe(IObservable<Memory<byte>> listener)
		{
			_unsubscriber = listener.Subscribe(this);
		}

		public void Unsubscribe()
        {
            if (_unsubscriber == null) 
                return;

            _unsubscriber.Dispose();
            _unsubscriber = null;
        }

		public abstract void OnCompleted();

		public abstract void OnError(Exception error);

		public abstract void OnNext(Memory<byte> value);
	}
}
