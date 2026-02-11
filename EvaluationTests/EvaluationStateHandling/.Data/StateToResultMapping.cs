namespace Evaluation.Tests.EvaluationStateHandling.Data;

public class StateToResultMapping : TheoryData<(EvaluationState State, bool YieldsResult)>
{
    public StateToResultMapping()
    {
        Add((EvaluationState.True  | EvaluationState.Pending,    YieldsResult: true));
        Add((EvaluationState.True  | EvaluationState.Determined, YieldsResult: true));
        Add((EvaluationState.False | EvaluationState.Pending,    YieldsResult: false));
        Add((EvaluationState.False | EvaluationState.Determined, YieldsResult: false));
    }
}