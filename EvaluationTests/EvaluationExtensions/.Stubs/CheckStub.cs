namespace Evaluation.Tests.EvaluationExtensions.Stubs;

internal static class CheckStub
{
    internal static bool ChecksTrue() => true;
    internal static bool ChecksFalse() => false;

    internal static bool ChecksTrue<T>(T data) where T : class => true;
    internal static bool ChecksFalse<T>(T data) where T : class => false;

    internal static bool ChecksTrue<T>(in T data) where T : struct => true;
    internal static bool ChecksFalse<T>(in T data) where T : struct => false;
}