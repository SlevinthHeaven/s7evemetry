
using System;
using System.Threading.Tasks;

namespace S7evemetry.Core.Interfaces
{
	public interface IS7evemetryClient<T>
    {
        event EventHandler<T>? OnDataReceived;

        Task Start();

        Task Stop();
    }
}
