using irsdkSharp.Serialization.Models.Session;
using S7evemetry.Core;
using System;

namespace S7evemetry.iRacing.Observers
{
    public abstract class SessionObserver : IObserver<IRacingSessionModel>
    {
        private IDisposable? _unsubscriber;

        public void Subscribe(IObservable<IRacingSessionModel> listener)
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

        public abstract void OnNext(IRacingSessionModel value);
    }
}
