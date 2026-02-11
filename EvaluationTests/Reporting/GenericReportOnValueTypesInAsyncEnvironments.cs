using Evaluation.Tests.Reporting.Fixtures;
using Evaluation.Tests.Reporting.Internals;


namespace Evaluation.Tests.Reporting;

public class GenericReportOnValueTypesInAsyncEnvironments
(
    AssessementFixture assessmentFixture,
    AsyncEnvironmentFixture<int> asyncEnvironmentFixture
) 
    : IClassFixture<AssessementFixture>, IClassFixture<AsyncEnvironmentFixture<int>>
{
    [Fact]
    internal async Task Report_MustPreserveState_AcrossAsyncCalls()
    {
        var data = 5;
        var assessment = assessmentFixture.CreateStub();
        var report = new Report<int>(ref data, ref assessment);

        await asyncEnvironmentFixture.GenericReportHandlingAsync(report);

        Assert.Equal(data, report.Data);
        Assert.True(IAssessementComparer.AreEqual(report, assessment));
    }

    [Fact]
    internal async Task Report_MustPreserveState_WhenHandledIn_AwaitedAsyncCalls()
    {
        var data = 5;
        var assessment = assessmentFixture.CreateStub();
        var report = new Report<int>(ref data, ref assessment);

        var echoedData = await asyncEnvironmentFixture.GenericReportDataEchoAsync(report);

        Assert.Equal(data, echoedData);
        Assert.Equal(report.Data, echoedData);
    }
}