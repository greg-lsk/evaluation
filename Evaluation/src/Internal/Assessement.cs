using View;


namespace Evaluation.Internal;

internal readonly struct Assessment<T> : IAssessment<T>
{
    private readonly View<T> _dataView;

    public Delegate Rule { get; }
    public ref readonly T Data => ref _dataView.Peek();

    public int CallerLineNumber { get; }
    public string CallerFilePath { get; }

    public (DateTime Start, DateTime Finish) Timespan { get; }

    public T DetachData() => _dataView.Read();

    public Assessment(Delegate rule, ref T data, DateTime start, DateTime finish, int line, string filePath)
    {
        Rule = rule;
        _dataView = View<T>.Of(ref data);
        Timespan = (start, finish);
        CallerLineNumber = line;
        CallerFilePath = filePath;
    }
}