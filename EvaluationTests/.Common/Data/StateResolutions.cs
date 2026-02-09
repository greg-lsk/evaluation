namespace Evaluation.Tests.Common.Data;

internal class StateResolutions
{
    internal static TheoryData<(EvaluationState CurrentState, Operation, bool CheckResult, EvaluationState ExpectedState)>
    OrOperationResolutions =>
    [
        (CurrentState: EvaluationState.True,  Operation.Or, CheckResult: true,  ExpectedState: EvaluationState.True | EvaluationState.Pending),
        (CurrentState: EvaluationState.True,  Operation.Or, CheckResult: false, ExpectedState: EvaluationState.True | EvaluationState.Pending),
        (CurrentState: EvaluationState.False, Operation.Or, CheckResult: true,  ExpectedState: EvaluationState.True | EvaluationState.Pending),
        (CurrentState: EvaluationState.False, Operation.Or, CheckResult: false, ExpectedState: EvaluationState.False | EvaluationState.Pending)
    ];


    internal static TheoryData<(EvaluationState CurrentState, Operation, bool CheckResult, EvaluationState ExpectedState)>
    AndOperationResolutions =>
    [
        (CurrentState: EvaluationState.True,  Operation.And, CheckResult: true,  ExpectedState: EvaluationState.True | EvaluationState.Pending),
        (CurrentState: EvaluationState.True,  Operation.And, CheckResult: false, ExpectedState: EvaluationState.False | EvaluationState.Pending),
        (CurrentState: EvaluationState.False, Operation.And, CheckResult: true,  ExpectedState: EvaluationState.False | EvaluationState.Pending),
        (CurrentState: EvaluationState.False, Operation.And, CheckResult: false, ExpectedState: EvaluationState.False | EvaluationState.Pending)
    ];


    internal static TheoryData<(EvaluationState CurrentState, Operation, bool CheckResult, EvaluationState ExpectedState)>
    MustOperationResolutions =>
    [
        (CurrentState: EvaluationState.True,  Operation.Must, CheckResult: true,  ExpectedState: EvaluationState.True | EvaluationState.Pending),
        (CurrentState: EvaluationState.True,  Operation.Must, CheckResult: false, ExpectedState: EvaluationState.False | EvaluationState.Determined),
        (CurrentState: EvaluationState.False, Operation.Must, CheckResult: true,  ExpectedState: EvaluationState.False | EvaluationState.Pending),
        (CurrentState: EvaluationState.False, Operation.Must, CheckResult: false, ExpectedState: EvaluationState.False | EvaluationState.Determined)
    ];


    internal static TheoryData<(EvaluationState CurrentState, Operation, bool CheckResult, EvaluationState ExpectedState)>
    AllOperationResolutions 
    {
        get
        {
            var combinedData = new TheoryData<(EvaluationState, Operation, bool, EvaluationState)>();
            foreach (var tuple in OrOperationResolutions) combinedData.Add(tuple);
            foreach (var tuple in AndOperationResolutions) combinedData.Add(tuple);
            foreach (var tuple in MustOperationResolutions) combinedData.Add(tuple);
            return combinedData;
        }
    }
}