using irsdkSharp.Serialization.Models.Session;
using S7evemetry.Core;
using S7evemetry.iRacing.Models;
using System;

namespace S7evemetry.iRacing.Client
{
    public class IRacingDisconnectedObserver : Observers.DisconnectedObserver
    {
        public event EventHandler<DisconnectedModel>? OnDisconnectedModelCreated;
        public override void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public override void OnError(DataException error)
        {
            throw new NotImplementedException();
        }

        public override void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public override void OnNext(DisconnectedModel value)
        {
            OnDisconnectedModelCreated?.Invoke(this, value);
        }
    }
}
