using Evaluation.Tests.Common.Data;
using Evaluation.Tests.Common.Stubs;
using Evaluation.Tests.EvaluationExtensions.Stubs;


namespace Evaluation.Tests.EvaluationExtensions.Data.ForSyncOperations;

public class AndOperationNoDataSync : TheoryData<(EvaluationState CurrentState, Check Rule, EvaluationState ResolvesTo)>
{
    public AndOperationNoDataSync()
    {
        foreach (var tuple in PendingEvaluationStateResolutions.AndOperations) Add(
        (
            tuple.CurrentState, 
            tuple.CheckResult ? CheckStubs.CheckTrue : CheckStubs.CheckFalse, 
            tuple.ResolvesTo
        ));
    }
}

public class AndOperationRefTypeDataSync 
    : TheoryData<(EvaluationState CurrentState, Check<DataStub> Rule, DataStub Data, EvaluationState ResolvesTo)>
{
    public AndOperationRefTypeDataSync()
    {
        foreach (var tuple in PendingEvaluationStateResolutions.AndOperations) Add(
        (
            tuple.CurrentState,
            tuple.CheckResult ? CheckStubs.CheckTrue : CheckStubs.CheckFalse,
            new(),
            tuple.ResolvesTo
        ));
    }
}

public class AndOperationValueTypeDataSync
    : TheoryData<(EvaluationState CurrentState, CheckOnStruct<int> Rule, int Data, EvaluationState ResolvesTo)>
{
    public AndOperationValueTypeDataSync()
    {
        foreach (var tuple in PendingEvaluationStateResolutions.AndOperations) Add(
        (
            tuple.CurrentState,
            tuple.CheckResult ? CheckStubs.CheckTrue : CheckStubs.CheckFalse,
            default,
            tuple.ResolvesTo
        ));
    }
}