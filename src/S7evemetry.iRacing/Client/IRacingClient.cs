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
        private readonly IRacingConnectedObserver _iRacingConnectedObserver;
        private readonly IRacingDisconnectedObserver _iRacingDisconnectedObserver;

        public event EventHandler<IRacingModel>? OnDataReceived;
        public event EventHandler? OnConnected;
        public event EventHandler? OnDisconnected;

        private IRacingDataModel? _currentDataModel;
        private IRacingSessionModel? _currentSessionModel;

        public IRacingClient(
            IRacingListener racingListener,
            IRacingDataObserver iRacingDataObserver,
            IRacingSessionObserver iRacingSessionObserver,
            IRacingConnectedObserver iRacingConnectedObserver,
            IRacingDisconnectedObserver iRacingDisconnectedObserver
            )
        {
            _racingListener = racingListener;
            _iRacingDataObserver = iRacingDataObserver;
            _iRacingSessionObserver = iRacingSessionObserver;
            _iRacingConnectedObserver = iRacingConnectedObserver;
            _iRacingDisconnectedObserver = iRacingDisconnectedObserver;

            _iRacingDataObserver.OnDataModelCreated += IRacingDataObserver_OnDataModelCreated;
            _iRacingSessionObserver.OnSessionModelCreated += IRacingSessionObserver_OnSessionModelCreated;
            _iRacingConnectedObserver.OnConnectedModelCreated += _iRacingConnectedObserver_OnConnectedModelCreated;
            _iRacingDisconnectedObserver.OnDisconnectedModelCreated += _iRacingDisconnectedObserver_OnDisconnectedModelCreated;
        }

        private void _iRacingDisconnectedObserver_OnDisconnectedModelCreated(object sender, iRacing.Models.DisconnectedModel e)
        {
            OnDisconnected?.Invoke(this, new EventArgs { });
        }

        private void _iRacingConnectedObserver_OnConnectedModelCreated(object sender, iRacing.Models.ConnectedModel e)
        {
            OnConnected?.Invoke(this, new EventArgs { });
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
            _iRacingDisconnectedObserver.Subscribe(_racingListener);
            _iRacingConnectedObserver.Subscribe(_racingListener);
            return Task.CompletedTask;
        }

        public Task Stop()
        {
            _iRacingDataObserver.Unsubscribe();
            _iRacingSessionObserver.Unsubscribe();
            _iRacingDisconnectedObserver.Unsubscribe();
            _iRacingConnectedObserver.Unsubscribe();
            return Task.CompletedTask;
        }
    }
}
