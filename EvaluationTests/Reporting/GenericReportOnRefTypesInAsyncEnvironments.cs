using Evaluation.Tests.Common.Stubs;
using Evaluation.Tests.Reporting.Fixtures;
using Evaluation.Tests.Reporting.Internals;


namespace Evaluation.Tests.Reporting;

public class GenericReportOnRefTypesInAsyncEnvironments
(
    AssessementFixture assessmentFixture,
    AsyncEnvironmentFixture<DataStub> asyncEnvironmentFixture
)
    : IClassFixture<AssessementFixture>, IClassFixture<AsyncEnvironmentFixture<DataStub>>
{
    [Fact]
    internal async Task Report_MustPreserveState_AcrossAsyncCalls()
    {
        var data = new DataStub();
        var assessment = assessmentFixture.CreateStub();
        var report = new Report<DataStub>(ref data, ref assessment);

        await asyncEnvironmentFixture.GenericReportHandlingAsync(report);

        Assert.Equal(data, report.Data);
        Assert.True(IAssessementComparer.AreEqual(report, assessment));
    }

    [Fact]
    internal async Task Report_MustPreserveState_WhenHandledIn_AwaitedAsyncCalls()
    {
        var data = new DataStub();
        var assessment = assessmentFixture.CreateStub();
        var report = new Report<DataStub>(ref data, ref assessment);

        var echoedData = await asyncEnvironmentFixture.GenericReportDataEchoAsync(report);

        Assert.Equal(data, echoedData);
        Assert.Equal(report.Data, echoedData);
    }
}