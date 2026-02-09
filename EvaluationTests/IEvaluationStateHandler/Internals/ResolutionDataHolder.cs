using Evaluation.Tests.Common.Data;
using Evaluation.Tests.IEvaluationStateHandler.Data;


namespace Evaluation.Tests.IEvaluationStateHandler.Internals;

public abstract class ResolutionDataHolder
{
    public static IEnumerable<object[]> ValidInitializedStates => EvaluationStates.ValidInitializedStates;
    public static IEnumerable<object[]> ValidTerminationTransitions => EvaluationStates.ValidTerminationTransitions;
    public static IEnumerable<object[]> StateResolutionForUninitializedEvaluators => EvaluationStates.ResolvedStatesForUninitializedEvaluators;

    public static TheoryData<(EvaluationState CurrentState, Operation, bool CheckResult, EvaluationState ExpectedState)> 
        StateResolutionsOnPendingEvaluator => StateResolutions.AllOperationResolutions;
}