namespace Evaluation.Internal;

internal interface IAssessment<T>
{
    internal Delegate Rule { get; }
    internal ref readonly T Data { get; }

    internal int CallerLineNumber { get; }
    internal string CallerFilePath { get; }

    internal (DateTime Start, DateTime Finish) Timespan { get; }

    internal T DetachData();
}