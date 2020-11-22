using S7evemetry.Console.Data;
using S7evemetry.Core;
using S7evemetry.Core.Packets.F1;
using S7evemetry.F1_2020.Observers;
using S7evemetry.F1_2020.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.Console.CosmosDemo
{
    public class CosmosDemoSetup : CarSetupDataObserver
    {
        //private readonly SetupRepository _carLapRepository;
        private DateTime _lastSave = DateTime.MinValue;
        //public CosmosDemoSetup(SetupRepository carLapRepository)
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

        public override void OnNext(PacketData<PacketHeader, CarSetupData, CarSetup> value)
        {
            var now = DateTime.UtcNow;
            if (_lastSave.AddSeconds(1) < now)
            {
                _lastSave = now;
                for (var i = 0; i < value.CarData.Count; i++)
                {
                  // _carLapRepository.SaveAsync(i, value.Header.SessionTime, value.CarData[i]);
                }
            }
        }
    }
}
