namespace DesignPatterns.Creational.Singleton;

public sealed class DoubleCheckedLockingSingleton {
    private static DoubleCheckedLockingSingleton? _instance;
    private static readonly object _lock = new();

    private DoubleCheckedLockingSingleton() { }

    public static DoubleCheckedLockingSingleton Instance {
        get {
            if (_instance == null) {
                lock (_lock) {
                    _instance ??= new DoubleCheckedLockingSingleton();
                }
            }
            return _instance;
        }
    }
}
