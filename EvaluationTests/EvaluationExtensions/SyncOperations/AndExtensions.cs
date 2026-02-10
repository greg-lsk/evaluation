using Evaluation.Tests.Common.Stubs;
using Evaluation.Tests.Common.Fixtures;
using Evaluation.Tests.EvaluationExtensions.Data.ForSyncOperations;
using Evaluation.Tests.EvaluationExtensions.Utils;


namespace Evaluation.Tests.EvaluationExtensions.SyncOperations;

public class AndExtensions(EvaluationFactoryFixture<Evaluation> evaluationFactory)
    : IClassFixture<EvaluationFactoryFixture<Evaluation>>
{
    [Theory]
    [ClassData(typeof(AndOperationNoDataSync))]
    internal void AndAsync_OnNoData_UpdatesStateCorrectly(
        (EvaluationState CurrentState, Check Check, EvaluationState ResolvesTo) data)
    {
        var evaluation = evaluationFactory.CreateWithState(data.CurrentState)
                                          .RunExtension(e => e.And(data.Check));

        Assert.Equal(data.ResolvesTo, evaluation.State);
    }

    [Theory]
    [ClassData(typeof(AndOperationRefTypeDataSync))]
    internal void AndAsync_OnRefTypeData_UpdatesStateCorrectly(
        (EvaluationState CurrentState, Check<DataStub> Check, DataStub CheckData, EvaluationState ResolvesTo) data)
    {
        var evaluation = evaluationFactory.CreateWithState(data.CurrentState)
                                          .RunExtension(e => e.And(data.Check, data.CheckData));

        Assert.Equal(data.ResolvesTo, evaluation.State);
    }

    [Theory]
    [ClassData(typeof(AndOperationValueTypeDataSync))]
    internal void AndAsync_OnValueTypeData_UpdatesStateCorrectly(
        (EvaluationState CurrentState, CheckOnStruct<int> Check, int CheckData, EvaluationState ResolvesTo) data)
    {
        var evaluation = evaluationFactory.CreateWithState(data.CurrentState)
                                          .RunExtension(e => e.And(data.Check, data.CheckData));

        Assert.Equal(data.ResolvesTo, evaluation.State);
    }
}