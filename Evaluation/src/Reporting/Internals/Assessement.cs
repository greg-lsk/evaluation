using View;


namespace Evaluation.Reporting.Internals;

internal readonly struct Assessment : IAssessment
{
    public Operation Operation { get; }
    public Delegate Check { get; }
    public bool CheckOutcome { get; }

    public EvaluationState ResolvedState { get; }

    public int CallerLineNumber { get; }
    public string CallerFilePath { get; }

    public (DateTime Start, DateTime Finish) Timespan { get; }

    
    internal Assessment(Operation operation, Delegate check, bool checkOutcome, DateTime start, DateTime finish, int line, string filePath)
    {
        Operation = operation;
        Check = check;
        CheckOutcome = checkOutcome;
        Timespan = (start, finish);
        CallerLineNumber = line;
        CallerFilePath = filePath;
    }
}