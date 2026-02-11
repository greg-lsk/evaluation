namespace Evaluation.Reporting.Internals;

internal interface IAssessment
{
    internal Operation Operation { get; }
    internal Delegate Check { get; }
    internal bool CheckOutcome { get; }

    internal EvaluationState ResolvedState { get; }

    internal int CallerLineNumber { get; }
    internal string CallerFilePath { get; }

    internal (DateTime Start, DateTime Finish) Timespan { get; }
}