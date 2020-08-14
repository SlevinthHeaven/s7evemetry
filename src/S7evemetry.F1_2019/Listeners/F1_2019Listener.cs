using S7evemetry.Core;
using S7evemetry.Core.Enums.F1;
using S7evemetry.Core.Packets.F1;
using S7evemetry.Core.Structures;
using S7evemetry.F1_2019.Packets;
using S7evemetry.F1_2019.Readers;
using S7evemetry.F1_2019.Structures;
using S7evemetry.Udp;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace S7evemetry.F1_2019.Listeners
{
    public class F1_2019Listener : UdpStreamListener,
        IObservable<PacketData<PacketHeader, EventData>>,
        IObservable<PacketData<PacketHeader, MotionData, CarMotion>>,
        IObservable<PacketData<PacketHeader, ParticipantData, Participant>>,
        IObservable<PacketData<PacketHeader, CarSetupData, CarSetup>>,
        IObservable<PacketData<PacketHeader, CarStatusData, CarStatus>>,
        IObservable<PacketData<PacketHeader, CarTelemetryData, CarTelemetry>>,
        IObservable<PacketData<PacketHeader, LapData, CarLap>>,
        IObservable<PacketData<PacketHeader, SessionData>>
    {
        private readonly ICollection<IObserver<PacketData<PacketHeader, EventData>>> _eventDataObservers;
        private readonly ICollection<IObserver<PacketData<PacketHeader, MotionData, CarMotion>>> _motionDataObservers;
        private readonly ICollection<IObserver<PacketData<PacketHeader, ParticipantData, Participant>>> _participantsDataObservers;
        private readonly ICollection<IObserver<PacketData<PacketHeader, CarSetupData, CarSetup>>> _carSetupObservers;
        private readonly ICollection<IObserver<PacketData<PacketHeader, CarStatusData, CarStatus>>> _carStatusObservers;
        private readonly ICollection<IObserver<PacketData<PacketHeader, CarTelemetryData, CarTelemetry>>> _carTelemetryObservers;
        private readonly ICollection<IObserver<PacketData<PacketHeader, LapData, CarLap>>> _lapDataObservers;
        private readonly ICollection<IObserver<PacketData<PacketHeader, SessionData>>> _sessionDataObservers;

        private readonly CarSetupDataReader _carSetupDataReader;
        private readonly CarStatusDataReader _carStatusDataReader;
        private readonly CarTelemetryDataReader _carTelemetryDataReader;
        private readonly EventDataReader _eventDataReader;
        private readonly LapDataReader _lapDataReader;
        private readonly MotionDataReader _motionDataReader;
        private readonly ParticipantsDataReader _participantsDataReader;
        private readonly SessionDataReader _sessionDataReader;

        public F1_2019Listener(IOptions<UdpListenerSettings> options) : base(options)
        {
            _eventDataObservers = new List<IObserver<PacketData<PacketHeader, EventData>>>();
            _motionDataObservers = new List<IObserver<PacketData<PacketHeader, MotionData, CarMotion>>>();
            _participantsDataObservers = new List<IObserver<PacketData<PacketHeader, ParticipantData, Participant>>>();

            _carSetupObservers = new List<IObserver<PacketData<PacketHeader, CarSetupData, CarSetup>>>();
            _carStatusObservers = new List<IObserver<PacketData<PacketHeader, CarStatusData, CarStatus>>>();
            _carTelemetryObservers = new List<IObserver<PacketData<PacketHeader, CarTelemetryData, CarTelemetry>>>();
            _lapDataObservers = new List<IObserver<PacketData<PacketHeader, LapData, CarLap>>>();
            _sessionDataObservers = new List<IObserver<PacketData<PacketHeader, SessionData>>>();

            _carSetupDataReader = new CarSetupDataReader();
            _carStatusDataReader = new CarStatusDataReader();
            _carTelemetryDataReader = new CarTelemetryDataReader();
            _eventDataReader = new EventDataReader();
            _lapDataReader = new LapDataReader();
            _motionDataReader = new MotionDataReader();
            _participantsDataReader = new ParticipantsDataReader();
            _sessionDataReader = new SessionDataReader();
        }

        public IDisposable Subscribe(IObserver<PacketData<PacketHeader, CarSetupData, CarSetup>> observer)
        {
            if (!_carSetupObservers.Contains(observer))
            {
                _carSetupObservers.Add(observer);
            }
            return new Unsubscriber<PacketData<PacketHeader, CarSetupData, CarSetup>>(_carSetupObservers, observer);
        }

        public IDisposable Subscribe(IObserver<PacketData<PacketHeader, CarStatusData, CarStatus>> observer)
        {
            if (!_carStatusObservers.Contains(observer))
            {
                _carStatusObservers.Add(observer);
            }
            return new Unsubscriber<PacketData<PacketHeader, CarStatusData, CarStatus>>(_carStatusObservers, observer);
        }

        public IDisposable Subscribe(IObserver<PacketData<PacketHeader, CarTelemetryData, CarTelemetry>> observer)
        {
            if (!_carTelemetryObservers.Contains(observer))
            {
                _carTelemetryObservers.Add(observer);
            }
            return new Unsubscriber<PacketData<PacketHeader, CarTelemetryData, CarTelemetry>>(_carTelemetryObservers, observer);
        }

        public IDisposable Subscribe(IObserver<PacketData<PacketHeader, EventData>> observer)
        {
            if (!_eventDataObservers.Contains(observer))
            {
                _eventDataObservers.Add(observer);
            }
            return new Unsubscriber<PacketData<PacketHeader, EventData>>(_eventDataObservers, observer);
        }

        public IDisposable Subscribe(IObserver<PacketData<PacketHeader, LapData, CarLap>> observer)
        {
            if (!_lapDataObservers.Contains(observer))
            {
                _lapDataObservers.Add(observer);
            }
            return new Unsubscriber<PacketData<PacketHeader, LapData, CarLap>>(_lapDataObservers, observer);
        }

        public IDisposable Subscribe(IObserver<PacketData<PacketHeader, MotionData, CarMotion>> observer)
        {
            if (!_motionDataObservers.Contains(observer))
            {
                _motionDataObservers.Add(observer);
            }
            return new Unsubscriber<PacketData<PacketHeader, MotionData, CarMotion>>(_motionDataObservers, observer);
        }

        public IDisposable Subscribe(IObserver<PacketData<PacketHeader, ParticipantData, Participant>> observer)
        {
            if (!_participantsDataObservers.Contains(observer))
            {
                _participantsDataObservers.Add(observer);
            }
            return new Unsubscriber<PacketData<PacketHeader, ParticipantData, Participant>>(_participantsDataObservers, observer);
        }

        public IDisposable Subscribe(IObserver<PacketData<PacketHeader, SessionData>> observer)
        {
            if (!_sessionDataObservers.Contains(observer))
            {
                _sessionDataObservers.Add(observer);
            }
            return new Unsubscriber<PacketData<PacketHeader, SessionData>>(_sessionDataObservers, observer);
        }

        protected override void NotifyData(byte[] data)
        {
            base.NotifyData(data);

            try
            {
                var spanData = new Span<byte>(data);
                var packetHeader = PacketHeader.Read(spanData);

                var input = spanData.Slice(packetHeader.Size);

                switch (packetHeader.PacketId)
                {
                    case PacketType.CarSetups:
                        {
                            var carSetupDataPacket = _carSetupDataReader.Read(input, packetHeader);
                            if (carSetupDataPacket != null)
                                NotifyData(carSetupDataPacket);
                            break;
                        }
                    case PacketType.CarStatus:
                        {
                            var carStatusDataPacket = _carStatusDataReader.Read(input, packetHeader);
                            if (carStatusDataPacket != null)
                                NotifyData(carStatusDataPacket);
                            break;
                        }
                    case PacketType.CarTelemetry:
                        {
                            var carTelemetryDataPacket = _carTelemetryDataReader.Read(input, packetHeader);
                            if (carTelemetryDataPacket != null)
                                NotifyData(carTelemetryDataPacket);
                            break;
                        }
                    case PacketType.Event:
                        {
                            var eventDataPacket = _eventDataReader.Read(input, packetHeader);
                            if(eventDataPacket != null)
                                NotifyData(eventDataPacket);
                            break;
                        }
                    case PacketType.LapData:
                        {
                            var lapDataPacket = _lapDataReader.Read(input, packetHeader);
                            if (lapDataPacket != null)
                                NotifyData(lapDataPacket);
                            break;
                        }
                    case PacketType.Motion:
                        {
                            var motionDataPacket = _motionDataReader.Read(input, packetHeader);
                            if (motionDataPacket != null)
                                NotifyData(motionDataPacket);
                            break;
                        }
                    case PacketType.Participants:
                        {
                            var participantsDataPacket = _participantsDataReader.Read(input, packetHeader);
                            if (participantsDataPacket != null)
                                NotifyData(participantsDataPacket);
                            break;
                        }
                    case PacketType.Session:
                        {
                            var sessionDataPacket = _sessionDataReader.Read(input, packetHeader);
                            if (sessionDataPacket != null)
                                NotifyData(sessionDataPacket);
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException(nameof(packetHeader.PacketId));
                }
            }
            catch (Exception ex)
            {
                // read exception: notified to observers
                NotifyError(new DataException("An error occurred while trying to read data", ex));
            }
        }

        protected void NotifyData(PacketData<PacketHeader, CarSetupData, CarSetup> data)
        {
            foreach (var observer in _carSetupObservers)
            {
                observer.OnNext(data);
            }
        }

        protected void NotifyData(PacketData<PacketHeader, CarStatusData, CarStatus> data)
        {
            foreach (var observer in _carStatusObservers)
            {
                observer.OnNext(data);
            }
        }

        protected void NotifyData(PacketData<PacketHeader, CarTelemetryData, CarTelemetry> data)
        {
            foreach (var observer in _carTelemetryObservers)
            {
                observer.OnNext(data);
            }
        }

        protected void NotifyData(PacketData<PacketHeader, EventData> data)
        {
            foreach (var observer in _eventDataObservers)
            {
                observer.OnNext(data);
            }
        }

        protected void NotifyData(PacketData<PacketHeader, LapData, CarLap> data)
        {
            foreach (var observer in _lapDataObservers)
            {
                observer.OnNext(data);
            }
        }

        protected void NotifyData(PacketData<PacketHeader, MotionData, CarMotion> data)
        {
            foreach (var observer in _motionDataObservers)
            {
                observer.OnNext(data);
            }
        }

        protected void NotifyData(PacketData<PacketHeader, ParticipantData, Participant> data)
        {
            foreach (var observer in _participantsDataObservers)
            {
                observer.OnNext(data);
            }
        }

        protected void NotifyData(PacketData<PacketHeader, SessionData> data)
        {
            foreach (var observer in _sessionDataObservers)
            {
                observer.OnNext(data);
            }
        }

        protected void NotifyError(DataException error)
        {
            foreach (var observer in _carSetupObservers)
            {
                observer.OnError(error);
            }
            foreach (var observer in _carStatusObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _carTelemetryObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _eventDataObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _lapDataObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _motionDataObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _participantsDataObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _sessionDataObservers)
            {
                observer.OnCompleted();
            }
        }

        protected override void NotifyCompletion()
        {
            base.NotifyCompletion();

            foreach (var observer in _carSetupObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _carStatusObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _carTelemetryObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _eventDataObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _lapDataObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _motionDataObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _participantsDataObservers)
            {
                observer.OnCompleted();
            }
            foreach (var observer in _sessionDataObservers)
            {
                observer.OnCompleted();
            }
        }
    }
}
