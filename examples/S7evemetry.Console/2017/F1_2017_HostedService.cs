using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace S7evemetry.Console._2017
{
    public class F1_2017_HostedService : IHostedService, IAsyncDisposable
    {
        private readonly F1_2017_DataVisualizer _f1_2017_DataVisualizer;

        public F1_2017_HostedService(F1_2017_DataVisualizer f1_2017_DataVisualizer)
        {
            _f1_2017_DataVisualizer = f1_2017_DataVisualizer;
        }

        public ValueTask DisposeAsync()
        {
            return new ValueTask(Task.CompletedTask);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _f1_2017_DataVisualizer.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _f1_2017_DataVisualizer.Stop();
            return Task.CompletedTask;
        }
    }
}
