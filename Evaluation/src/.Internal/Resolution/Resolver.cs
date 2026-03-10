namespace Evaluation.Internal.Resolution;

internal readonly struct Resolver : IResolver
{
    public bool EvaluationBecomesDetermined(bool checkResult, Operation operation)
    {
        return checkResult is false && operation is Operation.Must;
    }

    public bool Resolve(bool checkResult, Operation operation, bool currentResult) => operation switch
    {
        Operation.Or   => checkResult || currentResult,
        Operation.And  => checkResult && currentResult,
        Operation.Must => checkResult && currentResult,
        _ => throw new ArgumentException("PlaceholderMessage::[unexpected operation type]")
    };   
}