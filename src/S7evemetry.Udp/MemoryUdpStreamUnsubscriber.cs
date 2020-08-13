using System;
using System.Collections.Generic;

namespace S7evemetry.Udp
{
    internal class MemoryUdpStreamUnsubscriber : IDisposable
	{
		private readonly ICollection<IObserver<Memory<byte>>> _observers;
		private readonly IObserver<Memory<byte>> _observer;

		internal MemoryUdpStreamUnsubscriber(ICollection<IObserver<Memory<byte>>> observers, IObserver<Memory<byte>> observer)
		{
			_observers = observers;
			_observer = observer;
		}

		public void Dispose()
		{
			if (_observers.Contains(_observer))
			{
				_observers.Remove(_observer);
			}
		}
	}
}
