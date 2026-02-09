namespace Evaluation.Reporting.Internals;

internal readonly struct Assessment : IAssessment, IEquatable<Assessment>
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


    public bool Equals(Assessment other) =>
        Operation == other.Operation
        && Check == other.Check
        && CheckOutcome == other.CheckOutcome
        && ResolvedState == other.ResolvedState
        && CallerLineNumber == other.CallerLineNumber
        && CallerFilePath == other.CallerFilePath
        && Timespan.Start == other.Timespan.Start
        && Timespan.Finish == other.Timespan.Finish;

    public override bool Equals(object? obj) => obj is Assessment assessment && Equals(assessment);
    public override int GetHashCode() => HashCode.Combine(Operation, Check, CheckOutcome, ResolvedState, CallerLineNumber, CallerFilePath, Timespan);
    
    public static bool operator ==(Assessment left, Assessment right) => left.Equals(right);
    public static bool operator !=(Assessment left, Assessment right) => !(left==right);
}