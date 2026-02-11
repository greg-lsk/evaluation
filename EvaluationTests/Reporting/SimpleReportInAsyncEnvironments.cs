using Evaluation.Tests.Reporting.Fixtures;
using Evaluation.Tests.Reporting.Internals;


namespace Evaluation.Tests.Reporting;

public class SimpleReportInAsyncEnvironments(AssessementFixture assessmentFixture) : IClassFixture<AssessementFixture>
{
    private readonly Func<Report, Task> _handleReportAsync = async r => await Task.Delay(1000);


    [Fact]
    internal async Task Report_MustPreserveState_AcrossAsyncCalls()
    {
        var assessment = assessmentFixture.CreateStub();
        var report = new Report(ref assessment);

        await _handleReportAsync(report);

        Assert.True(IAssessementComparer.AreEqual(report, assessment));
    }
}