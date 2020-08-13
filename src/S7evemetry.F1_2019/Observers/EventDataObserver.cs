using S7evemetry.Core;
using S7evemetry.Core.Packets;
using S7evemetry.F1_2019.Structures;
using System;

namespace S7evemetry.F1_2019.Observers
{
    public abstract class EventDataObserver : IObserver<PacketData<PacketHeader, EventData>>
	{
			private IDisposable? _unsubscriber;

			public void Subscribe(IObservable<PacketData<PacketHeader, EventData>> listener)
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

			public abstract void OnNext(PacketData<PacketHeader, EventData> value);
    }
}
