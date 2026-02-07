using Evaluation.Internal;
using Evaluation.Tests.IEvaluationStateHandler.Data;


namespace Evaluation.Tests.IEvaluationStateHandler;

public class LifecycleTests
{
    public static IEnumerable<object[]> ValidInitializedStates => EvaluationStates.ValidInitializedStates;
    public static IEnumerable<object[]> ValidTerminationTransitions => EvaluationStates.ValidTerminationTransitions;

    public static IEnumerable<object[]> StateResolutionForUninitializedEvaluators => EvaluationStates.ResolvedStatesForUninitializedEvaluators;
    public static IEnumerable<object[]> ResolvedStatesForInitializedEvaluators => EvaluationStates.ResolvedStatesForInitializedEvaluators;


    [Fact]
    internal void Create_Returns_AnInstance_WithUninitializedState()
    {
        var evaluator = IEvaluationStateHandler<Evaluator>.Create() as IEvaluationStateHandler<Evaluator>;

        Assert.False(evaluator.State.IsInitialized());
    }


    [Theory]
    [MemberData(nameof(ValidInitializedStates))]
    internal void WithState_MakesState_Initialized(EvaluationState state)
    {
        var evaluator = IEvaluationStateHandler<Evaluator>.Create() as IEvaluationStateHandler<Evaluator>;

        var updatedEvaluator = evaluator.WithState(state) as IEvaluationStateHandler<Evaluator>;

        Assert.True(updatedEvaluator.State.IsInitialized());
    }

    [Theory]
    [MemberData(nameof(ValidInitializedStates))]
    internal void WithState_UpdatesStateCorrectly(EvaluationState state)
    {
        var evaluator = IEvaluationStateHandler<Evaluator>.Create() as IEvaluationStateHandler<Evaluator>;

        var updatedEvaluator = evaluator.WithState(state) as IEvaluationStateHandler<Evaluator>;

        Assert.Equal(state, updatedEvaluator.State);
    }


    [Theory]
    [MemberData(nameof(ValidTerminationTransitions))]
    internal void Terminate_TransitionsState_ToAppropriateDetermined(EvaluationState currectState, EvaluationState expectedState)
    {
        var evaluator = IEvaluationStateHandler<Evaluator>.Create() as IEvaluationStateHandler<Evaluator>;
        var updatedEvaluator = evaluator.WithState(currectState) as IEvaluationStateHandler<Evaluator>;

        var terminatedEvaluator = updatedEvaluator.Terminate() as IEvaluationStateHandler<Evaluator>;

        Assert.Equal(expectedState, terminatedEvaluator.State);
    }


    [Theory]
    [MemberData(nameof(StateResolutionForUninitializedEvaluators))]
    internal void DetermineNextState_ReturnsCorrectly_ForUninitializedEvaluators((bool CheckResult, Operation Operation, EvaluationState ExpectedState) data)
    {
        var evaluator = IEvaluationStateHandler<Evaluator>.Create() as IEvaluationStateHandler<Evaluator>;

        var state = evaluator.DetermineNextState(data.Operation, data.CheckResult);

        Assert.Equal(data.ExpectedState, state);
    }

    [Theory]
    [MemberData(nameof(ResolvedStatesForInitializedEvaluators))]
    internal void DetermineNextState_ReturnsCorrectly_ForInitializedEvaluators(
        (bool CheckResult, Operation Operation, EvaluationState CurrectState, EvaluationState ExpectedState) data)
    {
        var evaluator = IEvaluationStateHandler<Evaluator>.Create() as IEvaluationStateHandler<Evaluator>;
        var updatedEvaluator = evaluator.WithState(data.CurrectState) as IEvaluationStateHandler<Evaluator>;

        var state = updatedEvaluator.DetermineNextState(data.Operation, data.CheckResult);

        Assert.Equal(data.ExpectedState, state);
    }
}