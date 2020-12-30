using irsdkSharp.Serialization.Models.Data;
using irsdkSharp.Serialization.Models.Session;
using S7evemetry.Core.Interfaces;
using S7evemetry.iRacing.Client.Models;
using S7evemetry.iRacing.Listeners;
using System;
using System.Threading.Tasks;

namespace S7evemetry.iRacing.Client
{
    public class IRacingClient : IS7evemetryClient<IRacingModel>
    {
        private readonly IRacingListener _racingListener;
        private readonly IRacingDataObserver _iRacingDataObserver;
        private readonly IRacingSessionObserver _iRacingSessionObserver;

        public event EventHandler<IRacingModel>? OnDataReceived;

        private IRacingDataModel? _currentDataModel;
        private IRacingSessionModel? _currentSessionModel;

        public IRacingClient(
            IRacingListener racingListener,
            IRacingDataObserver iRacingDataObserver,
            IRacingSessionObserver iRacingSessionObserver
            )
        {
            _racingListener = racingListener;
            _iRacingDataObserver = iRacingDataObserver;
            _iRacingSessionObserver = iRacingSessionObserver;

            _iRacingDataObserver.OnDataModelCreated += IRacingDataObserver_OnDataModelCreated;
            _iRacingSessionObserver.OnSessionModelCreated += IRacingSessionObserver_OnSessionModelCreated;


        }

        private void IRacingSessionObserver_OnSessionModelCreated(object sender, IRacingSessionModel e)
        {
            _currentSessionModel = e;
            OnDataReceived?.Invoke(this, new IRacingModel
            {
                Data = _currentDataModel,
                Session = _currentSessionModel
            });
        }

        private void IRacingDataObserver_OnDataModelCreated(object sender, IRacingDataModel e)
        {
            _currentDataModel = e;
            OnDataReceived?.Invoke(this, new IRacingModel
            {
                Data = _currentDataModel,
                Session = _currentSessionModel
            });
        }


        public Task Start()
        {
            _iRacingDataObserver.Subscribe(_racingListener);
            _iRacingSessionObserver.Subscribe(_racingListener);
            return Task.CompletedTask;
        }

        public Task Stop()
        {
            _iRacingDataObserver.Unsubscribe();
            _iRacingSessionObserver.Unsubscribe();
            return Task.CompletedTask;
        }
    }
}
