using View;
using Evaluation.Internal;


namespace Evaluation;

public readonly struct Report<T> : IAssessment<T>
{
    private readonly View<Assessment<T>> _assessmentView;

    public Delegate Rule => _assessmentView.Peek().Rule;
    public ref readonly T Data => ref _assessmentView.Peek().Data;

    public int CallerLineNumber => _assessmentView.Peek().CallerLineNumber;
    public string CallerFilePath => _assessmentView.Peek().CallerFilePath;

    public (DateTime Start, DateTime Finish) Timespan => _assessmentView.Peek().Timespan;

    public T DetachData() => _assessmentView.Peek().DetachData();

    
    internal Report(ref Assessment<T> assessment) => _assessmentView = View<Assessment<T>>.Of(ref assessment);
}