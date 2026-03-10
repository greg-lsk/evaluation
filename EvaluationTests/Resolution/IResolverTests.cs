using Evaluation.Internal.Factories;
using Evaluation.Internal.Resolution;
using Evaluation.Tests.Resolution.Data;


namespace Evaluation.Tests.Resolution;

public class IResolverTests
{
    public static IEnumerable<object[]> BooleanResolutions => ResolutionData.BooleanResolutions;


    [Theory]
    [MemberData(nameof(BooleanResolutions))]
    internal void BooleanResolution_ResolvesCorrectly((bool CheckResult, Operation Operation, bool CurrentResult, bool ExpectedResolution) data)
    {
        var resolver = Create.StatelessStruct<Resolver>();
        var result = resolver.Resolve(data.CheckResult, data.Operation, data.CurrentResult);

        Assert.Equal(data.ExpectedResolution, result);
    }
}