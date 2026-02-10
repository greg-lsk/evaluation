using Evaluation.Tests.Common.Stubs;
using Evaluation.Tests.Common.Fixtures;
using Evaluation.Tests.EvaluationExtensions.Data.ForSyncOperations;


namespace Evaluation.Tests.EvaluationExtensions.SyncOperations;

public class AndExtensions(EvaluationFactoryFixture<Evaluation> evaluationFactory)
    : IClassFixture<EvaluationFactoryFixture<Evaluation>>
{
    [Theory]
    [ClassData(typeof(AndOperationNoDataSync))]
    internal void AndAsync_OnNoData_UpdatesStateCorrectly(
        (EvaluationState CurrentState, Check Check, EvaluationState ResolvesTo) data)
    {
        var evaluation = ((Evaluation)evaluationFactory.CreateWithState(data.CurrentState)).And(data.Check);

        Assert.Equal(data.ResolvesTo, (evaluation as IEvaluationStateHandler<Evaluation>).State);
    }

    [Theory]
    [ClassData(typeof(AndOperationRefTypeDataSync))]
    internal void AndAsync_OnRefTypeData_UpdatesStateCorrectly(
        (EvaluationState CurrentState, Check<ReportDataStub> Check, ReportDataStub CheckData, EvaluationState ResolvesTo) data)
    {
        var evaluation = ((Evaluation)evaluationFactory.CreateWithState(data.CurrentState)).And(data.Check, data.CheckData);

        Assert.Equal(data.ResolvesTo, (evaluation as IEvaluationStateHandler<Evaluation>).State);
    }

    [Theory]
    [ClassData(typeof(AndOperationValueTypeDataSync))]
    internal void AndAsync_OnValueTypeData_UpdatesStateCorrectly(
        (EvaluationState CurrentState, CheckOnStruct<int> Check, int CheckData, EvaluationState ResolvesTo) data)
    {
        var evaluation = ((Evaluation)evaluationFactory.CreateWithState(data.CurrentState)).And(data.Check, data.CheckData);

        Assert.Equal(data.ResolvesTo, (evaluation as IEvaluationStateHandler<Evaluation>).State);
    }
}