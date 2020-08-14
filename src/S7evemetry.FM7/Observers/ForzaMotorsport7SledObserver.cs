using S7evemetry.Core;
using S7evemetry.Core.Packets.Forza;
using S7evemetry.FM7;
using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.FM7.Observers
{
	public abstract class ForzaMotorsport7SledObserver : IObserver<PacketData<SledData>>
	{
		private IDisposable? _unsubscriber;

		public ForzaMotorsport7SledObserver()
		{
			
		}

		public void Subscribe(IObservable<PacketData<SledData>> listener)
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

		public abstract void OnNext(PacketData<SledData> value);
	}
}
