namespace Evaluation.Tests.EvaluationStateHandling.Data;

public class StatesOfInitializedEvaluation : TheoryData<EvaluationState>
{
    public StatesOfInitializedEvaluation()
    {
        Add(EvaluationState.True | EvaluationState.Pending);
        Add(EvaluationState.True | EvaluationState.Determined);

        Add(EvaluationState.False | EvaluationState.Pending);
        Add(EvaluationState.False | EvaluationState.Determined);
    }
}