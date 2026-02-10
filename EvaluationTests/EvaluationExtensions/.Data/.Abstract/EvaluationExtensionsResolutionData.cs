namespace Evaluation.Tests.EvaluationExtensions.Data.Abstract;

public abstract class EvaluationExtensionsResolutionData<TCheck>
    : TheoryData<(EvaluationState CurrentState, TCheck Check, EvaluationState ResolvesTo)>,
      IResolutionDataMapper<(EvaluationState CurrentState, TCheck Check, EvaluationState ResolvesTo)>
    where TCheck : Delegate
{
    public abstract Func<bool, TCheck> CheckSwitch { get; }

    public (EvaluationState CurrentState, TCheck Check, EvaluationState ResolvesTo) MapFrom(
        (EvaluationState CurrentState, Operation Operation, bool CheckResult, EvaluationState ResolvesTo) baseData)
    {
        return (baseData.CurrentState, CheckSwitch(baseData.CheckResult), baseData.ResolvesTo);
    }
}

public abstract class EvaluationExtensionsResolutionData<TCheck, TData>
    : TheoryData<(EvaluationState CurrentState, TCheck Check, TData Data, EvaluationState ResolvesTo)>,
      IResolutionDataMapper<(EvaluationState CurrentState, TCheck Check, TData Data, EvaluationState ResolvesTo)>
    where TCheck : Delegate
{
    public abstract Func<TData> DataProvider { get; }
    public abstract Func<bool, TCheck> CheckSwitch { get; }

    public (EvaluationState CurrentState, TCheck Check, TData Data, EvaluationState ResolvesTo) MapFrom(
        (EvaluationState CurrentState, Operation Operation, bool CheckResult, EvaluationState ResolvesTo) baseData)
    {
        return (baseData.CurrentState, CheckSwitch(baseData.CheckResult), DataProvider(), baseData.ResolvesTo);
    }
}