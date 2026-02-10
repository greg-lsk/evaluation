using Evaluation.Tests.Common.Stubs;
using Evaluation.Tests.Common.Fixtures;
using Evaluation.Tests.EvaluationExtensions.Data;
using Evaluation.Tests.EvaluationExtensions.Utils;


namespace Evaluation.Tests.EvaluationExtensions;

public class AndOperationSync(EvaluationFactoryFixture<Evaluation> evaluationFactory)
    : IClassFixture<EvaluationFactoryFixture<Evaluation>>
{
    [Theory]
    [ClassData(typeof(OnNoDataAndOperation))]
    internal void And_OnNoData_UpdatesStateCorrectly(
        (EvaluationState CurrentState, Check Check, EvaluationState ResolvesTo) data)
    {
        var evaluation = evaluationFactory.CreateWithState(data.CurrentState)
                                          .RunExtension(e => e.And(data.Check));

        Assert.Equal(data.ResolvesTo, evaluation.State);
    }

    [Theory]
    [ClassData(typeof(OnRefTypeAndOperation))]
    internal void And_OnRefTypeData_UpdatesStateCorrectly(
        (EvaluationState CurrentState, Check<DataStub> Check, DataStub CheckData, EvaluationState ResolvesTo) data)
    {
        var evaluation = evaluationFactory.CreateWithState(data.CurrentState)
                                          .RunExtension(e => e.And(data.Check, data.CheckData));

        Assert.Equal(data.ResolvesTo, evaluation.State);
    }

    [Theory]
    [ClassData(typeof(OnValueTypeAndOperation))]
    internal void And_OnValueTypeData_UpdatesStateCorrectly(
        (EvaluationState CurrentState, CheckOnStruct<int> Check, int CheckData, EvaluationState ResolvesTo) data)
    {
        var evaluation = evaluationFactory.CreateWithState(data.CurrentState)
                                          .RunExtension(e => e.And(data.Check, data.CheckData));

        Assert.Equal(data.ResolvesTo, evaluation.State);
    }
}