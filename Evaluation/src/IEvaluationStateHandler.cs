using Evaluation.Internal;


namespace Evaluation;

public interface IEvaluationStateHandler<T> where T : struct
{
    internal bool Result { get; }
    internal bool IsDetermined { get; }
    internal EvaluationState State { get; }

    internal T Terminate();
    internal T WithState(EvaluationState state);

    internal EvaluationState DetermineNextState(Operation operation, bool evaluatedCheckResult);
}