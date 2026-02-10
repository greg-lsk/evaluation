namespace Evaluation.Tests.IEvaluationStateHandler.Data;

public class StatesOfDeterminedEvaluation : TheoryData<EvaluationState>
{
    public StatesOfDeterminedEvaluation()
    {
        Add(EvaluationState.True  | EvaluationState.Determined);
        Add(EvaluationState.False | EvaluationState.Determined);
    }
}