namespace Evaluation.Internal.Resolution;

internal interface IResolver
{
    public static bool EvaluationBecomesDetermined(bool checkResult, Operation operation)
    {
        return checkResult is false && operation is Operation.Must;
    }

    public static bool BooleanResolution(bool checkResult, Operation operation, bool currentResult)
    {
        return operation switch
        {
            Operation.Or =>   checkResult || currentResult,
            Operation.And =>  checkResult && currentResult,
            Operation.Must => checkResult && currentResult,
            _ => throw new ArgumentException("PlaceholderMessage::[unexpected operation type]")
        };
    }
}