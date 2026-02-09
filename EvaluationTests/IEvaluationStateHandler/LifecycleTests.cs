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
        var evaluation = IEvaluationStateHandler<Evaluation>.Create() as IEvaluationStateHandler<Evaluation>;

        Assert.False(evaluation.State.IsInitialized());
    }


    [Theory]
    [MemberData(nameof(ValidInitializedStates))]
    internal void WithState_MakesState_Initialized(EvaluationState state)
    {
        var evaluation = _evaluationFactory.CreateUninitialized()
                                           .WithState(state) as IEvaluationStateHandler<Evaluation>;

        Assert.True(evaluation.State.IsInitialized());
    }

    [Theory]
    [MemberData(nameof(ValidInitializedStates))]
    internal void WithState_UpdatesStateCorrectly(EvaluationState state)
    {
        var evaluation = _evaluationFactory.CreateUninitialized()
                                           .WithState(state) as IEvaluationStateHandler<Evaluation>;

        Assert.Equal(state, evaluation.State);
    }


    [Theory]
    [MemberData(nameof(ValidTerminationTransitions))]
    internal void Terminate_TransitionsState_ToAppropriateDetermined(EvaluationState currectState, EvaluationState expectedState)
    {
        var evaluation = _evaluationFactory.CreateWithState(currectState)
                                           .Terminate() as IEvaluationStateHandler<Evaluation>;

        Assert.Equal(expectedState, evaluation.State);
    }


    [Theory]
    [MemberData(nameof(StateResolutionForUninitializedEvaluations))]
    internal void DetermineNextState_ReturnsCorrectly_ForUninitializedevaluations((bool CheckResult, Operation Operation, EvaluationState ExpectedState) data)
    {
        var state = _evaluationFactory.CreateUninitialized()
                                      .DetermineNextState(data.Operation, data.CheckResult);

        Assert.Equal(data.ExpectedState, state);
    }

    [Theory]
    [MemberData(nameof(PendingEvaluationAllStateResolutions))]
    internal void DetermineNextState_ReturnsCorrectly_ForInitializedevaluations(
        (EvaluationState CurrectState, Operation Operation, bool CheckResult, EvaluationState ResolvesTo) data)
    {
        var state = _evaluationFactory.CreateWithState(data.CurrectState)
                                      .DetermineNextState(data.Operation, data.CheckResult);

        Assert.Equal(data.ResolvesTo, state);
    }
}