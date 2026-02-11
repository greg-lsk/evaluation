namespace Evaluation.Tests.EvaluationStateHandling.Data;

internal class EvaluationStates
{
    internal static IEnumerable<object[]> ResolvedStatesForUninitializedEvaluations =>
    [
        [(CheckResult: true, Operation.Or,   ExpectedState: EvaluationState.True | EvaluationState.Pending)],
        [(CheckResult: true, Operation.And,  ExpectedState: EvaluationState.True | EvaluationState.Pending)],
        [(CheckResult: true, Operation.Must, ExpectedState: EvaluationState.True | EvaluationState.Pending)],

        [(CheckResult: false, Operation.Or,   ExpectedState: EvaluationState.False| EvaluationState.Pending)],
        [(CheckResult: false, Operation.And,  ExpectedState: EvaluationState.False | EvaluationState.Pending)],
        [(CheckResult: false, Operation.Must, ExpectedState: EvaluationState.False | EvaluationState.Determined)],
    ];
}