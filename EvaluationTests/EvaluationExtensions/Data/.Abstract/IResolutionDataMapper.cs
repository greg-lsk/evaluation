namespace Evaluation.Tests.EvaluationExtensions.Data.Abstract;

internal interface IResolutionDataMapper<T>
{
    internal T MapFrom((EvaluationState CurrentState, Operation Operation, bool CheckResult, EvaluationState ResolvesTo) baseData);
}