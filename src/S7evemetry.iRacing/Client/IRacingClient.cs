using irsdkSharp.Serialization.Models.Data;
using irsdkSharp.Serialization.Models.Session;
using S7evemetry.Core.Interfaces;
using S7evemetry.iRacing.Listeners;
using System;
using System.Threading.Tasks;

namespace S7evemetry.iRacing.Client
{
    public class IRacingClient : IS7evemetryClient<IRacingSessionModel>
    {
        private readonly IRacingListener _racingListener;
        private readonly IRacingSessionObserver _iRacingSessionObserver;
        private readonly IRacingConnectedObserver _iRacingConnectedObserver;
        private readonly IRacingDisconnectedObserver _iRacingDisconnectedObserver;

        public event EventHandler<IRacingSessionModel>? OnDataReceived;
        public event EventHandler? OnConnected;
        public event EventHandler? OnDisconnected;
        
        public IRacingClient(
            IRacingListener racingListener,
            IRacingSessionObserver iRacingSessionObserver,
            IRacingConnectedObserver iRacingConnectedObserver,
            IRacingDisconnectedObserver iRacingDisconnectedObserver
            )
        {
            _racingListener = racingListener;
            _iRacingSessionObserver = iRacingSessionObserver;
            _iRacingConnectedObserver = iRacingConnectedObserver;
            _iRacingDisconnectedObserver = iRacingDisconnectedObserver;

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
            OnDataReceived?.Invoke(this, e);
        }

        public Task Start()
        {
            _iRacingSessionObserver.Subscribe(_racingListener);
            _iRacingDisconnectedObserver.Subscribe(_racingListener);
            _iRacingConnectedObserver.Subscribe(_racingListener);
            return Task.CompletedTask;
        }

        public Task Stop()
        {
            _iRacingSessionObserver.Unsubscribe();
            _iRacingDisconnectedObserver.Unsubscribe();
            _iRacingConnectedObserver.Unsubscribe();
            return Task.CompletedTask;
        }

        public bool IsConnected()
        {
            return _racingListener.IsConnected();
        }

        public IRacingDataModel? GetDataModel()
        {
            return _racingListener.GetDataModel();
        }
    }
}
