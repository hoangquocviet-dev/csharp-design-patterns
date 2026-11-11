namespace DesignPatterns.CleanArchitecture;

using System;
using System.Runtime.CompilerServices;

public static class Guard
{
    public static T AgainstNull<T>(T? value, [CallerArgumentExpression("value")] string? paramName = null) where T : class
        => value ?? throw new ArgumentNullException(paramName);
}
