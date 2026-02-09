using Evaluation.Tests.IEvaluationStateHandler.Data;


namespace Evaluation.Tests.IEvaluationStateHandler;

public class PropertyTests
{
    public static IEnumerable<object[]> TrueYieldingStates => EvaluationStates.StatesThatYieldTrueResult;
    public static IEnumerable<object[]> FalseYieldingStates => EvaluationStates.StatesThatYieldFalseResult;
    public static IEnumerable<object[]> DeterminedYieldingStates => EvaluationStates.StatesThatMakeEvaluationDetermined; 


    [Theory]
    [MemberData(nameof(TrueYieldingStates))]
    internal void Result_YieldsTrue_Correctly(EvaluationState state)
    {
        var evaluator = IEvaluationStateHandler<Evaluation>.Create() as IEvaluationStateHandler<Evaluation>;
        var updatedEvaluator = evaluator.WithState(state) as IEvaluationStateHandler<Evaluation>;

        Assert.True(updatedEvaluator.Result);
    }

    [Theory]
    [MemberData(nameof(FalseYieldingStates))]
    internal void Result_YieldsFalse_Correctly(EvaluationState state)
    {
        var evaluator = IEvaluationStateHandler<Evaluation>.Create() as IEvaluationStateHandler<Evaluation>;
        var updatedEvaluator = evaluator.WithState(state) as IEvaluationStateHandler<Evaluation>;

        Assert.False(updatedEvaluator.Result);
    }

    [Theory]
    [MemberData(nameof(DeterminedYieldingStates))]
    internal void Determined_IsYielded_Correctly(EvaluationState state)
    {
        var evaluator = IEvaluationStateHandler<Evaluation>.Create() as IEvaluationStateHandler<Evaluation>;
        var updatedEvaluator = evaluator.WithState(state) as IEvaluationStateHandler<Evaluation>;

        Assert.True(updatedEvaluator.IsDetermined);
    }
}