namespace Evaluation.Internal.Factories;

internal static class Create
{
    internal static T StatelessStruct<T>() where T : struct => new();
    internal static T EvaluationStateHandler<T>() where T : struct, IEvaluationStateHandler<T> => new();
}