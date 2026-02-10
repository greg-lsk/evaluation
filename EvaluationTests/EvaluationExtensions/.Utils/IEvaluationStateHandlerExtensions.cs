namespace Evaluation.Tests.EvaluationExtensions.Utils;

internal static class IEvaluationStateHandlerExtensions
{
    internal static IEvaluationStateHandler<T> RunExtension<T>(this IEvaluationStateHandler<T> evaluation, Func<T, T> method) 
        where T : struct, IEvaluationStateHandler<T>
    {
        return method((T)evaluation);
    }
}