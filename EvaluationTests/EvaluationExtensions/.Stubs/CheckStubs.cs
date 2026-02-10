namespace Evaluation.Tests.EvaluationExtensions.Stubs;

internal static class CheckStubs
{
    internal static bool CheckTrue() => true;
    internal static bool CheckFalse() => false;

    internal static bool CheckTrue<T>(T data) where T : class => true;
    internal static bool CheckFalse<T>(T data) where T : class => false;

    internal static bool CheckTrue<T>(in T data) where T : struct => true;
    internal static bool CheckFalse<T>(in T data) where T : struct => false;
}