namespace Evaluation.Tests.IEvaluationStateHandler.Data;

public class PendingToDeterminedMapping : TheoryData<(EvaluationState CurrentPending, EvaluationState MapsTo)>
{
    public PendingToDeterminedMapping()
    {
        Add((EvaluationState.True | EvaluationState.Pending, MapsTo: EvaluationState.True | EvaluationState.Determined));
        Add((EvaluationState.False | EvaluationState.Pending, MapsTo: EvaluationState.False | EvaluationState.Determined));
    }
}