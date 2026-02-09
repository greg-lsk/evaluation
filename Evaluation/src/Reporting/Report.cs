using View;
using Evaluation.Reporting.Internals;


namespace Evaluation;

public readonly struct Report : IAssessment, IEquatable<Report>
{
    private readonly View<Assessment> _assessmentView;

    public Operation Operation => _assessmentView.Peek().Operation;
    public Delegate Check => _assessmentView.Peek().Check;
    public bool CheckOutcome => _assessmentView.Peek().CheckOutcome;

    public EvaluationState ResolvedState => _assessmentView.Peek().ResolvedState;

    public int CallerLineNumber => _assessmentView.Peek().CallerLineNumber;
    public string CallerFilePath => _assessmentView.Peek().CallerFilePath;

    public (DateTime Start, DateTime Finish) Timespan => _assessmentView.Peek().Timespan;


    internal Report(ref Assessment assessment)
    {
        _assessmentView = View<Assessment>.Of(ref assessment);
    }


    public bool Equals(Report other) => _assessmentView.Equals(other._assessmentView);
    public override bool Equals(object? obj) => obj is Report report && Equals(report);
    public override int GetHashCode() => _assessmentView.GetHashCode();

    public static bool operator ==(Report left, Report right) => left.Equals(right);
    public static bool operator !=(Report left, Report right) => !(left == right);
}


public readonly struct Report<T> : IAssessment, IEvaluatedDataViewer<T>, IEquatable<Report<T>>
{
    private readonly View<T> _evaluatedDataView;
    private readonly View<Assessment> _assessmentView;

    public Operation Operation => _assessmentView.Peek().Operation;
    public Delegate Check => _assessmentView.Peek().Check;
    public bool CheckOutcome => _assessmentView.Peek().CheckOutcome;

    public EvaluationState ResolvedState => _assessmentView.Peek().ResolvedState;

    public int CallerLineNumber => _assessmentView.Peek().CallerLineNumber;
    public string CallerFilePath => _assessmentView.Peek().CallerFilePath;

    public (DateTime Start, DateTime Finish) Timespan => _assessmentView.Peek().Timespan;

    public readonly ref readonly T Data => ref _evaluatedDataView.Peek();
    public T DetachData() => _evaluatedDataView.Read();


    internal Report(ref T data, ref Assessment assessment)
    {
        _evaluatedDataView = View<T>.Of(ref data);
        _assessmentView = View<Assessment>.Of(ref assessment);
    }


    public bool Equals(Report<T> other) => 
        _evaluatedDataView.Equals(other._evaluatedDataView) 
        && _assessmentView.Equals(other._assessmentView);
    
    public override bool Equals(object? obj) => obj is Report<T> report && Equals(report);
    public override int GetHashCode() => HashCode.Combine(_evaluatedDataView, _assessmentView);

    public static bool operator ==(Report<T> left, Report<T> right) => left.Equals(right);
    public static bool operator !=(Report<T> left, Report<T> right) => !(left == right);
}