using Microsoft.Extensions.Hosting;
using S7evemetry.F1_2020.Listeners;
using S7evemetry.iRacing.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace S7evemetry.Console.IracingDemo
{
    public class IRacingHostedService : IHostedService, IAsyncDisposable
    {
        private readonly IRacingClient _racingClient;

        public IRacingHostedService(IRacingClient racingClient)
        {
            _racingClient = racingClient;
            _racingClient.OnDataReceived += _racingClient_OnDataReceived;
            _racingClient.OnConnected += _racingClient_OnConnected; 
            _racingClient.OnDisconnected += _racingClient_OnDisconnected;
        }

        private void _racingClient_OnDisconnected(object sender, EventArgs e)
        {
            var a = "Disconnected";
        }

        private void _racingClient_OnConnected(object sender, EventArgs e)
        {
            var a = "Connected";
        }

        private void _racingClient_OnDataReceived(object sender, iRacing.Client.Models.IRacingModel e)
        {
            var a = "Data";
        }

        public ValueTask DisposeAsync()
        {
            return new ValueTask(Task.CompletedTask);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _racingClient.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _racingClient.Stop();
            return Task.CompletedTask;
        }
    }
}
