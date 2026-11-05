using System;

namespace DesignPatterns.Creational.Singleton;

public sealed class ThreadSafeLazySingleton {
    private static readonly Lazy<ThreadSafeLazySingleton> _instance = 
        new(() => new ThreadSafeLazySingleton());

    private ThreadSafeLazySingleton() { }

    public static ThreadSafeLazySingleton Instance => _instance.Value;
    public string GetStatus() => "ThreadSafeLazySingleton is operational.";
}
