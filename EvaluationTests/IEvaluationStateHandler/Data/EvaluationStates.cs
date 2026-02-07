using Evaluation.Internal;


namespace Evaluation.Tests.IEvaluationStateHandler.Data;

internal class EvaluationStates
{
    internal static IEnumerable<object[]> StatesThatYieldTrueResult =>
    [
        [EvaluationState.True | EvaluationState.Pending],
        [EvaluationState.True | EvaluationState.Determined]
    ];

    internal static IEnumerable<object[]> StatesThatYieldFalseResult =>
    [
        [EvaluationState.Uninitialized],
        [EvaluationState.False | EvaluationState.Pending],
        [EvaluationState.False | EvaluationState.Determined]
    ];

    internal static IEnumerable<object[]> StatesThatMakeEvaluationDetermined =>
    [
        [EvaluationState.True | EvaluationState.Determined],
        [EvaluationState.False | EvaluationState.Determined]
    ];

    internal static IEnumerable<object[]> ValidInitializedStates =>
    [
        [EvaluationState.True | EvaluationState.Pending],
        [EvaluationState.True | EvaluationState.Determined],

        [EvaluationState.False | EvaluationState.Pending],
        [EvaluationState.False | EvaluationState.Determined],
    ];

    internal static IEnumerable<object[]> ValidTerminationTransitions =>
    [
        [EvaluationState.True | EvaluationState.Pending, EvaluationState.True | EvaluationState.Determined],
        [EvaluationState.False | EvaluationState.Pending, EvaluationState.False | EvaluationState.Determined]
    ];
}