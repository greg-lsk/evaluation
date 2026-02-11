using Evaluation.Reporting.Internals;


namespace Evaluation.Tests.Reporting.Internals;

internal interface IAssessementComparer
{
    internal static bool AreEqual<L, R>(L left, R right)
        where L : struct, IAssessment
        where R : struct, IAssessment
    {
        return left.Operation == right.Operation
            && left.Check == right.Check
            && left.CheckOutcome == right.CheckOutcome
            && left.ResolvedState == right.ResolvedState
            && left.CallerLineNumber == right.CallerLineNumber
            && left.CallerFilePath == right.CallerFilePath
            && left.Timespan == right.Timespan;
    }
}