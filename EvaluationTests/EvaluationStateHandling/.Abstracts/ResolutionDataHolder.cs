using Evaluation.Tests.Common.Data;
using Evaluation.Tests.EvaluationStateHandling.Data;


namespace Evaluation.Tests.EvaluationStateHandling.Abstracts;

public abstract class ResolutionDataHolder
{
    public static IEnumerable<object[]> StateResolutionForUninitializedEvaluations => EvaluationStates.ResolvedStatesForUninitializedEvaluations;

    public static TheoryData<(EvaluationState CurrentState, Operation, bool CheckResult, EvaluationState ResolvesTo)> 
        PendingEvaluationAllStateResolutions => PendingEvaluationStateResolutions.AllOperations;
}