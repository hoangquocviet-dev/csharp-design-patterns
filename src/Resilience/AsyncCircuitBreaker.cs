using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpDesignPatterns.Resilience;

public sealed class AsyncCircuitBreaker
{
    private enum State { Closed, Open, HalfOpen }

    private readonly int _failureThreshold;
    private readonly TimeSpan _durationOfBreak;
    private readonly SemaphoreSlim _halfOpenSemaphore = new(1, 1);
    
    private State _state = State.Closed;
    private int _failureCount;
    private DateTimeTicks _nextAttemptUtc = new(0);

    public AsyncCircuitBreaker(int failureThreshold = 3, TimeSpan? durationOfBreak = null)
    {
        _failureThreshold = failureThreshold;
        _durationOfBreak = durationOfBreak ?? TimeSpan.FromSeconds(30);
    }

    public async Task<T> ExecuteAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(action);

        if (IsCircuitOpen())
        {
            throw new InvalidOperationException("Circuit breaker is OPEN. Execution blocked.");
        }

        try
        {
            var result = await action(cancellationToken).ConfigureAwait(false);
            OnSuccess();
            return result;
        }
        catch (Exception)
        {
            OnFailure();
            throw;
        }
    }

    private bool IsCircuitOpen()
    {
        if (_state == State.Closed) return false;

        if (_state == State.Open)
        {
            if (DateTime.UtcNow.Ticks >= Volatile.Read(ref _nextAttemptUtc._ticks))
            {
                LockStateToHalfOpen();
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    private void LockStateToHalfOpen()
    {
        if (_halfOpenSemaphore.Wait(0))
        {
            Interlocked.Exchange(ref _state, State.HalfOpen);
        }
    }

    private void OnSuccess()
    {
        if (_state == State.HalfOpen)
        {
            _halfOpenSemaphore.Release();
        }
        Interlocked.Exchange(ref _failureCount, 0);
        Interlocked.Exchange(ref _state, State.Closed);
    }

    private void OnFailure()
    {
        var failures = Interlocked.Increment(ref _failureCount);
        if (_state == State.HalfOpen || failures >= _failureThreshold)
        {
            Volatile.Write(ref _nextAttemptUtc._ticks, DateTime.UtcNow.Add(_durationOfBreak).Ticks);
            Interlocked.Exchange(ref _state, State.Open);
            
            if (_state == State.HalfOpen)
            {
                _halfOpenSemaphore.Release();
            }
        }
    }

    private struct DateTimeTicks
    {
        public long _ticks;
        public DateTimeTicks(long ticks) => _ticks = ticks;
    }
}
