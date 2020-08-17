using System;
using System.Buffers;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace S7evemetry.Udp
{
    public class MemoryUdpStreamListener : IDisposable, IObservable<Memory<byte>>
    {
        private readonly UdpClient _udpClient;
        private readonly ICollection<IObserver<Memory<byte>>> _observers;

        private IPEndPoint _serverEndPoint;
        private Memory<byte>? _lastData;

        public MemoryUdpStreamListener(int port, IPAddress serverIpAddress)
        {
            _udpClient = new UdpClient(port);
            _observers = new List<IObserver<Memory<byte>>>();
            _serverEndPoint = new IPEndPoint(serverIpAddress, 0);
            _lastData = null;
        }

        public void Close()
        {
            _udpClient.Close();
        }

        public void Dispose()
        {
            _udpClient.Dispose();
        }

        public IDisposable Subscribe(IObserver<Memory<byte>> observer)
        {
            if (_observers.Contains(observer))
                return new MemoryUdpStreamUnsubscriber(_observers, observer);

            _observers.Add(observer);

            if (_lastData.HasValue)
            {
                observer.OnNext(_lastData.Value);
            }
            return new MemoryUdpStreamUnsubscriber(_observers, observer);
        }

        protected virtual void NotifyData(Memory<byte> data)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(data);
            }
        }

        protected virtual void NotifyError(Exception error)
        {
            foreach (var observer in _observers)
            {
                observer.OnError(error);
            }
        }

        protected virtual void NotifyCompletion()
        {
            foreach (var observer in _observers)
            {
                observer.OnCompleted();
            }
        }

        public void Listen(CancellationToken cancellation)
        {
            Task.Factory.StartNew(async () =>
            {
                var memoryPool = MemoryPool<byte>.Shared;

                while (true)
                {
                    try
                    {
                        var buffer = memoryPool.Rent(512).Memory;

                        await _udpClient.Client.ReceiveAsync(buffer, SocketFlags.None, cancellation);

                        _lastData = buffer;
                        NotifyData(buffer);

                        if (!cancellation.IsCancellationRequested)
                            continue;

                        _udpClient.Close();
                        break;
                    }
                    catch (ObjectDisposedException)
                    {
                        // UDP client has been closed previously to abort connect/receive
                        // no need to notify observers or throw exception
                        return;
                    }
                    catch (Exception ex)
                    {
                        NotifyError(ex);
                        throw;
                    }
                }

                // end of notifications
                NotifyCompletion();

                // notify end of operations if requested
                cancellation.ThrowIfCancellationRequested();
            }, TaskCreationOptions.LongRunning);
        }
    }
}
