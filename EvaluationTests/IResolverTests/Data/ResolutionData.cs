using Evaluation.Internal;


namespace Evaluation.Tests.IResolverTests.Data;

internal class ResolutionData
{
    internal static IEnumerable<object[]> BooleanResolutions =
    [
        [(CheckResult: true, Operation.Or,   CurrentResult: true,  ResolvesTo: true || true)],
        [(CheckResult: true, Operation.Or,   CurrentResult: false, ResolvesTo: true || false)],
        [(CheckResult: true, Operation.And,  CurrentResult: true,  ResolvesTo: true && true)],
        [(CheckResult: true, Operation.And,  CurrentResult: false, ResolvesTo: true && false)],
        [(CheckResult: true, Operation.Must, CurrentResult: true,  ResolvesTo: true && true)],
        [(CheckResult: true, Operation.Must, CurrentResult: false, ResolvesTo: true && false)],

        [(CheckResult: false, Operation.Or,   CurrentResult: true,  ResolvesTo: false || true)],
        [(CheckResult: false, Operation.Or,   CurrentResult: false, ResolvesTo: false || false)],
        [(CheckResult: false, Operation.And,  CurrentResult: true,  ResolvesTo: false && true)],
        [(CheckResult: false, Operation.And,  CurrentResult: false, ResolvesTo: false && false)],
        [(CheckResult: false, Operation.Must, CurrentResult: true,  ResolvesTo: false && true)],
        [(CheckResult: false, Operation.Must, CurrentResult: false, ResolvesTo: false && false)]
    ];

    internal static IEnumerable<object[]> StateResolutions =
    [
        [(Operation.Or,   BooleanResolutionResult:true, Yields:EvaluationState.True | EvaluationState.Pending)],
        [(Operation.And,  BooleanResolutionResult:true, Yields:EvaluationState.True | EvaluationState.Pending)],
        [(Operation.Must, BooleanResolutionResult:true, Yields:EvaluationState.True | EvaluationState.Pending)],

        [(Operation.Or,   BooleanResolutionResult:false, Yields:EvaluationState.False | EvaluationState.Pending)],
        [(Operation.And,  BooleanResolutionResult:false, Yields:EvaluationState.False | EvaluationState.Pending)],
        [(Operation.Must, BooleanResolutionResult:false, Yields:EvaluationState.False | EvaluationState.Determined)]
    ];
}