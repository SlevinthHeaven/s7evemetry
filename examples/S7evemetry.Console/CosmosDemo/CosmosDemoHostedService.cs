using Microsoft.Extensions.Hosting;
using S7evemetry.F1_2020.Listeners;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace S7evemetry.Console.CosmosDemo
{
    public class CosmosDemoHostedService : IHostedService, IAsyncDisposable
    {
        private readonly CosmosDemoCarLap _cosmosDemoCarLap;
        private readonly F1_2020Listener _f1_2019Listener;

        public CosmosDemoHostedService(
            CosmosDemoCarLap cosmosDemoCarLap,
            F1_2020Listener f1_2019Listener)
        {
            _cosmosDemoCarLap = cosmosDemoCarLap;
            _f1_2019Listener = f1_2019Listener;
        }

        public ValueTask DisposeAsync()
        {
            return new ValueTask(Task.CompletedTask);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _cosmosDemoCarLap.Subscribe(_f1_2019Listener);
            _f1_2019Listener.Listen(cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _cosmosDemoCarLap.Unsubscribe();
            return Task.CompletedTask;
        }
    }
}
