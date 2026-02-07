namespace Evaluation.Internal.Resolution;

internal interface IResolver
{
    public static bool BooleanResolution(EvaluationState currentState, bool evaluatedCheckResult, Operation operation, bool currentResult)
    {
        return !currentState.IsInitialized() ? evaluatedCheckResult : operation switch
        {
            Operation.Or =>   evaluatedCheckResult || currentResult,
            Operation.And =>  evaluatedCheckResult && currentResult,
            Operation.Must => evaluatedCheckResult && currentResult,
            _ => throw new ArgumentException("PlaceholderMessage::[unexpected operation type]")
        };
    }

    public static EvaluationState StateResolution(bool booleanResolutionResult, Operation operation)
    {        
        return (operation, booleanResolutionResult) switch
        {
            (_, true) => EvaluationState.True | EvaluationState.Pending,

            (Operation.Or, false) =>   EvaluationState.False | EvaluationState.Pending,
            (Operation.And, false) =>  EvaluationState.False | EvaluationState.Pending,
            (Operation.Must, false) => EvaluationState.False | EvaluationState.Determined,

            _ => throw new ArgumentException("unexpected operation type")
        };
    }
}