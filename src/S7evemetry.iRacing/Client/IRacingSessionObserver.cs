using irsdkSharp.Serialization.Models.Session;
using S7evemetry.Core;
using System;

namespace S7evemetry.iRacing.Client
{
    public class IRacingSessionObserver : Observers.SessionObserver
    {
        public event EventHandler<IRacingSessionModel>? OnSessionModelCreated;
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

        public override void OnNext(IRacingSessionModel value)
        {
            OnSessionModelCreated?.Invoke(this, value);
        }
    }
}
