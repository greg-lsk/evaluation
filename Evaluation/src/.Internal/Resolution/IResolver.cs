namespace Evaluation.Internal.Resolution;

internal interface IResolver
{
    public bool EvaluationBecomesDetermined(bool checkResult, Operation operation);
    public bool Resolve(bool checkResult, Operation operation, bool currentResult);
}