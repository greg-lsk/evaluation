using Evaluation.Enums.Internals;
using Evaluation.Tests.Common.Fixtures;
using Evaluation.Tests.IEvaluationStateHandler.Internals;


namespace Evaluation.Tests.IEvaluationStateHandler;

public class LifecycleTests(EvaluationFactoryFixture<Evaluation> _evaluationFactory) 
    : ResolutionDataHolder, IClassFixture<EvaluationFactoryFixture<Evaluation>>
{
    [Fact]
    internal void Create_Returns_AnInstance_WithUninitializedState()
    {
        var evaluator = IEvaluationStateHandler<Evaluation>.Create() as IEvaluationStateHandler<Evaluation>;

        Assert.False(evaluator.State.IsInitialized());
    }


    [Theory]
    [MemberData(nameof(ValidInitializedStates))]
    internal void WithState_MakesState_Initialized(EvaluationState state)
    {
        var evaluator = _evaluationFactory.CreateUninitialized()
                                          .WithState(state) as IEvaluationStateHandler<Evaluation>;

        Assert.True(evaluator.State.IsInitialized());
    }

    [Theory]
    [MemberData(nameof(ValidInitializedStates))]
    internal void WithState_UpdatesStateCorrectly(EvaluationState state)
    {
        var evaluator = _evaluationFactory.CreateUninitialized()
                                          .WithState(state) as IEvaluationStateHandler<Evaluation>;

        Assert.Equal(state, evaluator.State);
    }


    [Theory]
    [MemberData(nameof(ValidTerminationTransitions))]
    internal void Terminate_TransitionsState_ToAppropriateDetermined(EvaluationState currectState, EvaluationState expectedState)
    {
        var evaluator = _evaluationFactory.CreateWithState(currectState)
                                          .Terminate() as IEvaluationStateHandler<Evaluation>;

        Assert.Equal(expectedState, evaluator.State);
    }


    [Theory]
    [MemberData(nameof(StateResolutionForUninitializedEvaluators))]
    internal void DetermineNextState_ReturnsCorrectly_ForUninitializedEvaluators((bool CheckResult, Operation Operation, EvaluationState ExpectedState) data)
    {
        var state = _evaluationFactory.CreateUninitialized()
                                      .DetermineNextState(data.Operation, data.CheckResult);

        Assert.Equal(data.ExpectedState, state);
    }

    [Theory]
    [MemberData(nameof(PendingEvaluationAllStateResolutions))]
    internal void DetermineNextState_ReturnsCorrectly_ForInitializedEvaluators(
        (EvaluationState CurrectState, Operation Operation, bool CheckResult, EvaluationState ResolvesTo) data)
    {
        var state = _evaluationFactory.CreateWithState(data.CurrectState)
                                      .DetermineNextState(data.Operation, data.CheckResult);

        Assert.Equal(data.ResolvesTo, state);
    }
}