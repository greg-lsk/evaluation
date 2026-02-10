using Evaluation.Tests.EvaluationExtensions.Stubs;


namespace Evaluation.Tests.EvaluationExtensions.Data.Abstract;

public abstract class OnRefTypeResolution<D> : EvaluationExtensionsResolutionData<Check<D>, D>
    where D : class, new()
{
    public override Func<D> DataProvider => () => new();
    public override Func<bool, Check<D>> CheckSwitch => b => b switch
    {
        true => CheckStubs.CheckTrue,
        false => CheckStubs.CheckFalse
    };
}