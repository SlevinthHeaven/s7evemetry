using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace S7evemetry.Console._2019
{
    public class F1_2019_HostedService : IHostedService, IAsyncDisposable
    {
        private readonly F1_2019_DataVisualizer _f1_2019_DataVisualizer;

        public F1_2019_HostedService(F1_2019_DataVisualizer f1_2019_DataVisualizer)
        {
            _f1_2019_DataVisualizer = f1_2019_DataVisualizer;
        }

        public ValueTask DisposeAsync()
        {
            return new ValueTask(Task.CompletedTask);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _f1_2019_DataVisualizer.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _f1_2019_DataVisualizer.Stop();
            return Task.CompletedTask;
        }
    }
}
