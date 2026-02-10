using Evaluation.Tests.Common.Stubs;
using Evaluation.Tests.ReportingTests.Fixtures;
using Evaluation.Tests.ReportingTests.Internals;


namespace Evaluation.Tests.ReportingTests;

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
        var data = new DataStub(5);
        var assessment = assessmentFixture.CreateStub();
        var report = new Report<DataStub>(ref data, ref assessment);

        await asyncEnvironmentFixture.GenericReportHandlingAsync(report);

        Assert.Equal(data, report.Data);
        Assert.True(IAssessementComparer.AreEqual(report, assessment));
    }

    [Fact]
    internal async Task Report_MustPreserveState_WhenHandledIn_AwaitedAsyncCalls()
    {
        var data = new DataStub(5);
        var assessment = assessmentFixture.CreateStub();
        var report = new Report<DataStub>(ref data, ref assessment);

        var echoedData = await asyncEnvironmentFixture.GenericReportDataEchoAsync(report);

        Assert.Equal(data, echoedData);
        Assert.Equal(report.Data, echoedData);
    }
}