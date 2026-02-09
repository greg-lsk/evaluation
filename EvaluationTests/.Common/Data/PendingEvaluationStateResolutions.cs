namespace Evaluation.Tests.Common.Data;

internal class PendingEvaluationStateResolutions
{
    internal static TheoryData<(EvaluationState CurrentState, Operation, bool CheckResult, EvaluationState ResolvesTo)>
    OrOperations =>
    [
        (CurrentState: EvaluationState.True,  Operation.Or, CheckResult: true,  ResolvesTo: EvaluationState.True | EvaluationState.Pending),
        (CurrentState: EvaluationState.True,  Operation.Or, CheckResult: false, ResolvesTo: EvaluationState.True | EvaluationState.Pending),
        (CurrentState: EvaluationState.False, Operation.Or, CheckResult: true,  ResolvesTo: EvaluationState.True | EvaluationState.Pending),
        (CurrentState: EvaluationState.False, Operation.Or, CheckResult: false, ResolvesTo: EvaluationState.False | EvaluationState.Pending)
    ];


    internal static TheoryData<(EvaluationState CurrentState, Operation, bool CheckResult, EvaluationState ResolvesTo)>
    AndOperations =>
    [
        (CurrentState: EvaluationState.True,  Operation.And, CheckResult: true,  ResolvesTo: EvaluationState.True | EvaluationState.Pending),
        (CurrentState: EvaluationState.True,  Operation.And, CheckResult: false, ResolvesTo: EvaluationState.False | EvaluationState.Pending),
        (CurrentState: EvaluationState.False, Operation.And, CheckResult: true,  ResolvesTo: EvaluationState.False | EvaluationState.Pending),
        (CurrentState: EvaluationState.False, Operation.And, CheckResult: false, ResolvesTo: EvaluationState.False | EvaluationState.Pending)
    ];


    internal static TheoryData<(EvaluationState CurrentState, Operation, bool CheckResult, EvaluationState ResolvesTo)>
    MustOperations =>
    [
        (CurrentState: EvaluationState.True,  Operation.Must, CheckResult: true,  ResolvesTo: EvaluationState.True | EvaluationState.Pending),
        (CurrentState: EvaluationState.True,  Operation.Must, CheckResult: false, ResolvesTo: EvaluationState.False | EvaluationState.Determined),
        (CurrentState: EvaluationState.False, Operation.Must, CheckResult: true,  ResolvesTo: EvaluationState.False | EvaluationState.Pending),
        (CurrentState: EvaluationState.False, Operation.Must, CheckResult: false, ResolvesTo: EvaluationState.False | EvaluationState.Determined)
    ];


    internal static TheoryData<(EvaluationState CurrentState, Operation, bool CheckResult, EvaluationState ResolvesTo)>
    AllOperations 
    {
        get
        {
            var combinedData = new TheoryData<(EvaluationState, Operation, bool, EvaluationState)>();
            foreach (var tuple in OrOperations) combinedData.Add(tuple);
            foreach (var tuple in AndOperations) combinedData.Add(tuple);
            foreach (var tuple in MustOperations) combinedData.Add(tuple);
            return combinedData;
        }
    }
}