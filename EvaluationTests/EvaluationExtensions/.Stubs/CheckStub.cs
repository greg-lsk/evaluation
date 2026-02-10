namespace Evaluation.Tests.EvaluationExtensions.Stubs;

internal static class CheckStub
{
    internal static bool ChecksTrue() => true;
    internal static bool ChecksFalse() => false;

    internal static bool ChecksTrue<T>(T data) where T : class => true;
    internal static bool ChecksFalse<T>(T data) where T : class => false;

    internal static bool ChecksTrue<T>(in T data) where T : struct => true;
    internal static bool ChecksFalse<T>(in T data) where T : struct => false;

    internal static async Task<bool> ChecksTrueAsync() { await Task.Delay(1000); return true; }
    internal static async Task<bool> ChecksFalseAsync() { await Task.Delay(1000); return false; }

    internal static async Task<bool> ChecksTrueOnRefAsync<T>(T data) where T: class { await Task.Delay(1000); return true; }
    internal static async Task<bool> ChecksFalseOnRefAsync<T>(T data) where T : class { await Task.Delay(1000); return false; }

    internal static async Task<bool> ChecksTrueOnValueAsync<T>(T data) where T : struct { await Task.Delay(1000); return true; }
    internal static async Task<bool> ChecksFalseOnValueAsync<T>(T data) where T : struct { await Task.Delay(1000); return false; }
}