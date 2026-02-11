namespace Evaluation.Tests.Reporting.Fixtures;

public class AsyncEnvironmentFixture<T>
{
    internal Func<Report<T>, Task> GenericReportHandlingAsync;
    internal Func<Report<T>, Task<T>> GenericReportDataEchoAsync;

    public AsyncEnvironmentFixture()
    {
        GenericReportHandlingAsync = async r => await Task.Delay(1000);
        GenericReportDataEchoAsync = async r => { await Task.Delay(1000); return r.Data; };
    }
}