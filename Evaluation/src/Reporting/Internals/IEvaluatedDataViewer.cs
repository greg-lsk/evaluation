namespace Evaluation.Reporting.Internals;

internal interface IEvaluatedDataViewer<T>
{
    internal ref readonly T Data { get; }

    internal T DetachData();
}