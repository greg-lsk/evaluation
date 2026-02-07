using Evaluation.Internal;
using Evaluation.Internal.Resolution;
using Evaluation.Tests.IResolverTests.Data;


namespace Evaluation.Tests.IResolverTests;

public class IResolverTests
{
    public static IEnumerable<object[]> BooleanResolutions => ResolutionData.BooleanResolutions;
    public static IEnumerable<object[]> StateResolutions => ResolutionData.StateResolutions;


    [Theory]
    [MemberData(nameof(BooleanResolutions))]
    internal void BooleanResolution_ResolvesCorrectly
    (
        (EvaluationState CurrentState, bool CheckResult, Operation Operation, bool CurrentResult, bool ExpectedResolution) data
    )
    {
        var result = IResolver.BooleanResolution(data.CurrentState, data.CheckResult, data.Operation, data.CurrentResult);

        Assert.Equal(data.ExpectedResolution, result);
    }

    [Theory]
    [MemberData(nameof(StateResolutions))]
    internal void StateResolution_ResolvesCorrectly((Operation Operation, bool BooleanResolutionResult, EvaluationState ExpectedState) data)
    {
        var yieldedState = IResolver.StateResolution(data.BooleanResolutionResult, data.Operation);

        Assert.Equal(data.ExpectedState, yieldedState);
    }
}