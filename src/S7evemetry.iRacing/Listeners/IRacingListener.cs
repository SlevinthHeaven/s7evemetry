using irsdkSharp.Serialization;
using irsdkSharp.Serialization.Models.Data;
using irsdkSharp.Serialization.Models.Session;
using Microsoft.Extensions.Logging;
using S7evemetry.Core;
using S7evemetry.iRacing.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace S7evemetry.iRacing.Listeners
{
    public class IRacingListener :
        IObservable<IRacingSessionModel>,
        IObservable<ConnectedModel>,
        IObservable<DisconnectedModel>

    {
        private readonly ILogger<IRacingListener> _logger;
        private readonly irsdkSharp.IRacingSDK _sdk;

        private readonly ICollection<IObserver<IRacingSessionModel>> _sessionObservers;
        private readonly ICollection<IObserver<ConnectedModel>> _connectedObservers;
        private readonly ICollection<IObserver<DisconnectedModel>> _disconnectedObservers;

        private bool _hasConnected;
        private int _waitTime = 17;
        private bool _IsConnected = false;
        private readonly int _connectSleepTime = 1000;
        private readonly Stopwatch _stopWatch = new Stopwatch();

        public IRacingListener(ILogger<IRacingListener> logger)
        {
            _logger = logger;
            _sdk = new irsdkSharp.IRacingSDK();

            _sessionObservers = new List<IObserver<IRacingSessionModel>>();
            _connectedObservers = new List<IObserver<ConnectedModel>>();
            _disconnectedObservers = new List<IObserver<DisconnectedModel>>();

            Task.Run(() => Loop());
        }


        public IDisposable Subscribe(IObserver<IRacingSessionModel> observer)
        {
            if (!_sessionObservers.Contains(observer))
            {
                _sessionObservers.Add(observer);
            }
            return new Unsubscriber<IRacingSessionModel>(_sessionObservers, observer);
        }

        public IDisposable Subscribe(IObserver<ConnectedModel> observer)
        {
            if (!_connectedObservers.Contains(observer))
            {
                _connectedObservers.Add(observer);
            }
            return new Unsubscriber<ConnectedModel>(_connectedObservers, observer);
        }

        public IDisposable Subscribe(IObserver<DisconnectedModel> observer)
        {
            if (!_disconnectedObservers.Contains(observer))
            {
                _disconnectedObservers.Add(observer);
            }
            return new Unsubscriber<DisconnectedModel>(_disconnectedObservers, observer);
        }

        protected void NotifyData(IRacingSessionModel data)
        {
            foreach (var observer in _sessionObservers)
            {
                observer.OnNext(data);
            }
        }

        protected void NotifyData(ConnectedModel data)
        {
            foreach (var observer in _connectedObservers)
            {
                observer.OnNext(data);
            }
        }

        protected void NotifyData(DisconnectedModel data)
        {
            foreach (var observer in _disconnectedObservers)
            {
                observer.OnNext(data);
            }
        }

        private void Loop()
        {
            int lastUpdate = -1;

            while (true)
            {
                // Check if we can find the sim
                if (_sdk.IsConnected())
                {
                    if (!_IsConnected)
                    {
                        _logger.LogInformation("Now Connected");
                        // If this is the first time, raise the Connected event
                        NotifyData(new ConnectedModel());
                    }

                    _hasConnected = true;
                    _IsConnected = true;

                    int attempts = 0;
                    const int maxAttempts = 99;

                    var sessionnum = TryGetSessionNum();
                    while (sessionnum == -1 && attempts <= maxAttempts)
                    {
                        attempts++;
                        sessionnum = TryGetSessionNum();
                    }
                    if (attempts >= maxAttempts)
                    {
                        _logger.LogWarning("Too many attempts to connect");
                        continue;
                    }

                    // Is the session info updated?
                    int newUpdate = _sdk.Header.SessionInfoUpdate;
                    if (newUpdate != lastUpdate)
                    {
                        lastUpdate = newUpdate;
                        // Get the session info string
                        _stopWatch.Restart();
                        NotifyData(_sdk.GetSerializedSessionInfo());
                        _stopWatch.Stop();
                        _logger.LogInformation($"Get Serialized Session took {_stopWatch.ElapsedMilliseconds}ms");
                    }

                }
                else if (_hasConnected)
                {

                    if (_IsConnected)
                    {
                        NotifyData(new DisconnectedModel());
                    }
                    _sdk.Shutdown();
                    lastUpdate = -1;
                    _IsConnected = false;
                    _hasConnected = false;
                }
                else
                {
                    if(_IsConnected)
                    {
                        NotifyData(new DisconnectedModel());
                    }
                    _IsConnected = false;
                    _hasConnected = false;

                    //Try to find the sim
                    _sdk.Startup();
                }

                // Sleep for a short amount of time until the next update is available
                if (_IsConnected)
                {
                    if (_waitTime <= 0 || _waitTime > 1000) _waitTime = 15;
                    Thread.Sleep(_waitTime);
                }
                else
                {
                    // Not connected yet, no need to check every 16 ms, let's try again in some time
                    Thread.Sleep(_connectSleepTime);
                }
            }

        }

        private int TryGetSessionNum()
        {
            try
            {
                var sessionnum = _sdk.GetData("SessionNum");
                return int.Parse(sessionnum.ToString());
            }
            catch
            {
                return -1;
            }
        }


        public bool IsConnected()
        {
            try
            {
                return _sdk.IsConnected();
            }
            catch
            {
                return false;
            }
            
        }


        public IRacingDataModel? GetDataModel()
        {
            if (!IsConnected()) return null;

            return _sdk.GetSerializedData();
        }
    }
}
