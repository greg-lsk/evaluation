using Evaluation.Tests.EvaluationExtensions.Stubs;


namespace Evaluation.Tests.EvaluationExtensions.Data.Abstract;

public abstract class OnNoDataResolution : EvaluationExtensionsResolutionData<Check>
{
    public override Func<bool, Check> CheckSwitch => b => b switch
    {
        true => CheckStubs.CheckTrue,
        false => CheckStubs.CheckFalse
    };
}