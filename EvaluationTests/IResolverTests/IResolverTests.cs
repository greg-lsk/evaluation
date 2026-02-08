using Evaluation.Internal.Resolution;
using Evaluation.Tests.IResolverTests.Data;


namespace Evaluation.Tests.IResolverTests;

public class IResolverTests
{
    public static IEnumerable<object[]> BooleanResolutions => ResolutionData.BooleanResolutions;


    [Theory]
    [MemberData(nameof(BooleanResolutions))]
    internal void BooleanResolution_ResolvesCorrectly((bool CheckResult, Operation Operation, bool CurrentResult, bool ExpectedResolution) data)
    {
        var result = IResolver.Resolve(data.CheckResult, data.Operation, data.CurrentResult);

        Assert.Equal(data.ExpectedResolution, result);
    }
}