using irsdkSharp.Serialization.Models.Session;
using S7evemetry.iRacing.Models;
using S7evemetry.Core;
using System;

namespace S7evemetry.iRacing.Client
{
    public class IRacingConnectedObserver : Observers.ConnectedObserver
    {
        public event EventHandler<ConnectedModel>? OnConnectedModelCreated;
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

        public override void OnNext(ConnectedModel value)
        {
            OnConnectedModelCreated?.Invoke(this, value);
        }
    }
}
