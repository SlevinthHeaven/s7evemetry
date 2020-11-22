using S7evemetry.Console.Data;
using S7evemetry.Core;
using S7evemetry.Core.Packets.F1;
using S7evemetry.F1_2020.Observers;
using S7evemetry.F1_2020.Packets;
using S7evemetry.F1_2020.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.Console.CosmosDemo
{
    public class CosmosDemoEvent : EventDataObserver
    {
        //private readonly SetupRepository _carLapRepository;
        private DateTime _lastSave = DateTime.MinValue;
        //public CosmosDemoEvent(SetupRepository carLapRepository)
        //{
        //    _carLapRepository = carLapRepository;
        //}

        public override void OnCompleted()
        {
        }

        public override void OnError(DataException error)
        {
        }

        public override void OnError(Exception error)
        {
        }

        public override void OnNext(PacketData<PacketHeader, EventData> value)
        {
            var now = DateTime.UtcNow;
            if (_lastSave.AddSeconds(1) < now)
            {
                _lastSave = now;
            }
        }
    }
}
