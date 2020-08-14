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

namespace S7evemetry.FM7
{
	public class ForzaMotorsport7DataListener : UdpStreamListener,
		IObservable<PacketData<SledData, CarDashData>>,
		IObservable<PacketData<SledData>>
	{
		private readonly ICollection<IObserver<PacketData<SledData>>> _sledObservers;
		private readonly ICollection<IObserver<PacketData<SledData, CarDashData>>> _carDashObservers;
		private readonly ForzaMotorsport7DataReader _reader;

		public ForzaMotorsport7DataListener(IOptions<UdpListenerSettings> options) : base(options)
		{
			_sledObservers = new List<IObserver<PacketData<SledData>>>();
			_carDashObservers = new List<IObserver<PacketData<SledData, CarDashData>>>();
			_reader = new ForzaMotorsport7DataReader();
		}

		public IDisposable Subscribe(IObserver<PacketData<SledData, CarDashData>> observer)
		{
			if (!_carDashObservers.Contains(observer))
			{
				_carDashObservers.Add(observer);
			}
			return new Unsubscriber<PacketData<SledData, CarDashData>>(_carDashObservers, observer);
		}

		public IDisposable Subscribe(IObserver<PacketData<SledData>> observer)
		{
			if (!_sledObservers.Contains(observer))
			{
				_sledObservers.Add(observer);
			}
			return new Unsubscriber<PacketData<SledData>>(_sledObservers, observer);
		}

		protected override void NotifyData(byte[] data)
		{
			base.NotifyData(data);

			try
			{
				var sledData = _reader.ReadSled(data);
				var carDashData = _reader.ReadCarDash(data);

				if(sledData != null)
					NotifyData(sledData);

				if (carDashData != null)
					NotifyData(carDashData);
			}
			catch (Exception ex)
			{
				// read exception: notified to observers
				NotifyError(new DataException("An error occurred while trying to read data", ex));
			}
		}

		protected void NotifyData(PacketData<SledData> data)
		{
			foreach (var observer in _sledObservers)
			{
				observer.OnNext(data);
			}
		}

		protected void NotifyData(PacketData<SledData, CarDashData> data)
		{
			foreach (var observer in _carDashObservers)
			{
				observer.OnNext(data);
			}
		}

		protected void NotifyError(DataException error)
		{
			foreach (var observer in _sledObservers)
			{
				observer.OnError(error);
			}
			foreach (var observer in _carDashObservers)
			{
				observer.OnError(error);
			}
		}

		protected override void NotifyCompletion()
		{
			base.NotifyCompletion();

			foreach (var observer in _sledObservers)
			{
				observer.OnCompleted();
			}
			foreach (var observer in _carDashObservers)
			{
				observer.OnCompleted();
			}
		}
	}
}
