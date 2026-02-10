using Evaluation.Tests.EvaluationExtensions.Stubs;


namespace Evaluation.Tests.EvaluationExtensions.Data.Abstract;

public abstract class OnValueTypeResolution<D> : EvaluationExtensionsResolutionData<CheckOnStruct<D>, D>
    where D : struct
{
    public override Func<D> DataProvider => () => default;
    public override Func<bool, CheckOnStruct<D>> CheckSwitch => b => b switch
    {
        true => CheckStubs.CheckTrue,
        false => CheckStubs.CheckFalse
    };
}