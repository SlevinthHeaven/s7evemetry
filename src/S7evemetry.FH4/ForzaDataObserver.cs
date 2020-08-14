using S7evemetry.Core;
using S7evemetry.Core.Packets.Forza;
using System;

namespace S7evemetry.FH4
{
	public abstract class ForzaHoizon4DataObserver : IObserver<PacketData<SledData, CarDashData>>
	{
		private IDisposable? _unsubscriber;

		public ForzaHoizon4DataObserver()
		{
			
		}

		public void Subscribe(IObservable<PacketData<SledData, CarDashData>> listener)
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

		public abstract void OnNext(PacketData<SledData, CarDashData> value);
	}
}
