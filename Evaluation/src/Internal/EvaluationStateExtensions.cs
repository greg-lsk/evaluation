namespace Evaluation.Internal;

internal static class EvaluationStateExtensions
{
    internal static bool Is(this EvaluationState currentState, EvaluationState state) => ((currentState & state) == state);
    internal static bool IsInitialized(this EvaluationState currentState) => currentState != EvaluationState.Uninitialized;
    
}