using Evaluation.Tests.Common.Fixtures;
using Evaluation.Tests.EvaluationStateHandling.Data;


namespace Evaluation.Tests.EvaluationStateHandling;

public class PropertyTests(EvaluationFixture<Evaluation> evaluationFactory) 
    : IClassFixture<EvaluationFixture<Evaluation>>
{
    [Theory]
    [ClassData(typeof(StateToResultMapping))]
    internal void Result_YieldsCorrectly((EvaluationState State, bool YieldsResult) data)
    {
        var evaluator = evaluationFactory.CreateWithState(data.State);

        Assert.Equal(data.YieldsResult, evaluator.Result);
    }

    [Theory]
    [ClassData(typeof(StatesOfDeterminedEvaluation))]
    internal void Determined_IsYielded_Correctly(EvaluationState state)
    {
        var evaluator = evaluationFactory.CreateWithState(state);

        Assert.True(evaluator.IsDetermined);
    }
}