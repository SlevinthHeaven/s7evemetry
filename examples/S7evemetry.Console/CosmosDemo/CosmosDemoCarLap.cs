﻿using S7evemetry.Console.Data;
using S7evemetry.Core;
using S7evemetry.Core.Packets.F1;
using S7evemetry.F1_2020.Observers;
using S7evemetry.F1_2020.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace S7evemetry.Console.CosmosDemo
{
    public class CosmosDemoCarLap : LapDataObserver
    {
        private readonly CarLapRepository _carLapRepository;
        private DateTime _lastSave = DateTime.MinValue;
        public CosmosDemoCarLap(CarLapRepository carLapRepository)
        {
            _carLapRepository = carLapRepository;
        }

        public override void OnCompleted()
        {
        }

        public override void OnError(DataException error)
        {
        }

        public override void OnError(Exception error)
        {
        }

        public override void OnNext(PacketData<PacketHeader, LapData, CarLap> value)
        {
            var now = DateTime.UtcNow;
            if (_lastSave.AddMilliseconds(100) < now)
            {
                _lastSave = now;
                _carLapRepository.SaveAsync(value.Header.PlayerCarIndex, value.Header.SessionTime, value.CarData[value.Header.PlayerCarIndex]);
            }
        }
    }
}
