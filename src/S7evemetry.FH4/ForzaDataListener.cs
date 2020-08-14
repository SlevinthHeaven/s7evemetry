using Microsoft.Extensions.Options;
using S7evemetry.Core;
using S7evemetry.Core.Packets.Forza;
using S7evemetry.Udp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace S7evemetry.FH4
{
	public class ForzaHorizon4Listener : UdpStreamListener, IObservable<PacketData<SledData, CarDashData>>
	{
		private readonly ICollection<IObserver<PacketData<SledData, CarDashData>>> _observers;
		private readonly ForzaHorizon4DataReader _reader;

		public ForzaHorizon4Listener(IOptions<UdpListenerSettings> options) : base(options)
		{
			_observers = new List<IObserver<PacketData<SledData, CarDashData>>>();
			_reader = new ForzaHorizon4DataReader();
		}

		public IDisposable Subscribe(IObserver<PacketData<SledData, CarDashData>> observer)
		{
			if (!_observers.Contains(observer))
			{
				_observers.Add(observer);
			}
			return new Unsubscriber<PacketData<SledData, CarDashData>>(_observers, observer);
		}

		protected override void NotifyData(byte[] data)
		{
			base.NotifyData(data);

			try
			{
				var forzaData = _reader.Read(data);
				if(forzaData != null)
                {
					// success reading
					NotifyData(forzaData);
				}

			}
			catch (Exception ex)
			{
				// read exception: notified to observers
				NotifyError(new DataException("An error occurred while trying to read data", ex));
			}
		}

		protected void NotifyData(PacketData<SledData, CarDashData> data)
		{
			foreach (var observer in _observers)
			{
				observer.OnNext(data);
			}
		}

		protected void NotifyError(DataException error)
		{
			foreach (var observer in _observers)
			{
				observer.OnError(error);
			}
		}

		protected override void NotifyCompletion()
		{
			base.NotifyCompletion();

			foreach (var observer in _observers)
			{
				observer.OnCompleted();
			}
		}
	}
}
