namespace DesignPatterns.CleanArchitecture;

using System.Threading;
using System.Threading.Tasks;

public sealed class OutboxRelayWorker
{
    public Task ExecuteRelayCycleAsync(CancellationToken ct = default) => Task.CompletedTask;
}
