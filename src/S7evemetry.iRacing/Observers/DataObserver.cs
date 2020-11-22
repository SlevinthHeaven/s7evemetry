using irsdkSharp.Serialization.Models.Data;
using S7evemetry.Core;
using System;

namespace S7evemetry.iRacing.Observers
{
    public abstract class DataObserver : IObserver<IRacingDataModel>
    {
        private IDisposable? _unsubscriber;

        public void Subscribe(IObservable<IRacingDataModel> listener)
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

        public abstract void OnNext(IRacingDataModel value);
    }
}
