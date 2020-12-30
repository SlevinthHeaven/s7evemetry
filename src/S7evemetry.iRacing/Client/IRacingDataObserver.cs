using irsdkSharp.Serialization.Models.Data;
using S7evemetry.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.iRacing.Client
{
    public class IRacingDataObserver : Observers.DataObserver
    {
        public event EventHandler<IRacingDataModel>? OnDataModelCreated;

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

        public override void OnNext(IRacingDataModel value)
        {
            OnDataModelCreated?.Invoke(this, value);
        }
    }
}
