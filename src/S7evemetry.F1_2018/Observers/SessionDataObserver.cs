﻿using S7evemetry.Core;
using S7evemetry.Core.Packets.F1;
using S7evemetry.F1_2018.Packets;
using S7evemetry.F1_2018.Structures;
using System;

namespace S7evemetry.F1_2018.Observers
{
    public abstract class SessionDataObserver : IObserver<PacketData<PacketHeader, SessionData>>
	{
			private IDisposable? _unsubscriber;

			public void Subscribe(IObservable<PacketData<PacketHeader, SessionData>> listener)
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

			public abstract void OnNext(PacketData<PacketHeader, SessionData> value);
    }
}
