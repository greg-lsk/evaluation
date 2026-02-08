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
}