using Evaluation.Internal;


namespace Evaluation.Tests.IResolverTests.Data;

internal class ResolutionData
{
    internal static IEnumerable<object[]> BooleanResolutions =
    [
        [(EvaluationState.Uninitialized, CheckResult:true, Operation.Or,   currentResult:true,  ResolvesTo:true)],
        [(EvaluationState.Uninitialized, CheckResult:true, Operation.Or,   currentResult:false, ResolvesTo:true)],
        [(EvaluationState.Uninitialized, CheckResult:true, Operation.And,  currentResult:true,  ResolvesTo:true)],
        [(EvaluationState.Uninitialized, CheckResult:true, Operation.And,  currentResult:false, ResolvesTo:true)],
        [(EvaluationState.Uninitialized, CheckResult:true, Operation.Must, currentResult:true,  ResolvesTo:true)],
        [(EvaluationState.Uninitialized, CheckResult:true, Operation.Must, currentResult:false, ResolvesTo:true)],

        [(EvaluationState.Uninitialized, CheckResult:false, Operation.Or,   currentResult:true,  ResolvesTo:false)],
        [(EvaluationState.Uninitialized, CheckResult:false, Operation.Or,   currentResult:false, ResolvesTo:false)],
        [(EvaluationState.Uninitialized, CheckResult:false, Operation.And,  currentResult:true,  ResolvesTo:false)],
        [(EvaluationState.Uninitialized, CheckResult:false, Operation.And,  currentResult:false, ResolvesTo:false)],
        [(EvaluationState.Uninitialized, CheckResult:false, Operation.Must, currentResult:true,  ResolvesTo:false)],
        [(EvaluationState.Uninitialized, CheckResult:false, Operation.Must, currentResult:false, ResolvesTo:false)],

        [(EvaluationState.Pending | EvaluationState.True, CheckResult:true, Operation.Or,   currentResult:true,  ResolvesTo:true || true)],
        [(EvaluationState.Pending | EvaluationState.True, CheckResult:true, Operation.Or,   currentResult:false, ResolvesTo:true || false)],
        [(EvaluationState.Pending | EvaluationState.True, CheckResult:true, Operation.And,  currentResult:true,  ResolvesTo:true && true)],
        [(EvaluationState.Pending | EvaluationState.True, CheckResult:true, Operation.And,  currentResult:false, ResolvesTo:true && false)],
        [(EvaluationState.Pending | EvaluationState.True, CheckResult:true, Operation.Must, currentResult:true,  ResolvesTo:true && true)],
        [(EvaluationState.Pending | EvaluationState.True, CheckResult:true, Operation.Must, currentResult:false, ResolvesTo:true && false)],

        [(EvaluationState.Pending | EvaluationState.False, CheckResult:false, Operation.Or,   currentResult:true,  ResolvesTo:false || true)],
        [(EvaluationState.Pending | EvaluationState.False, CheckResult:false, Operation.Or,   currentResult:false, ResolvesTo:false || false)],
        [(EvaluationState.Pending | EvaluationState.False, CheckResult:false, Operation.And,  currentResult:true,  ResolvesTo:false && true)],
        [(EvaluationState.Pending | EvaluationState.False, CheckResult:false, Operation.And,  currentResult:false, ResolvesTo:false && false)],
        [(EvaluationState.Pending | EvaluationState.False, CheckResult:false, Operation.Must, currentResult:true,  ResolvesTo:false && true)],
        [(EvaluationState.Pending | EvaluationState.False, CheckResult:false, Operation.Must, currentResult:false, ResolvesTo:false && false)],
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