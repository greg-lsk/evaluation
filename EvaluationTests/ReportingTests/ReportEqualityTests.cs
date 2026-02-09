using Evaluation.Tests.ReportingTests.Fixtures;


namespace Evaluation.Tests.ReportingTests;

public class ReportEqualityTests(AssessementFixture assessementFixture) : IClassFixture<AssessementFixture>
{
    [Fact]
    internal void GenericReports_AreEqualWhen_TheyHave_SameDataAndAssessment_Locations()
    {
        var data = 5;
        var assessment = assessementFixture.CreateStub();
        var report01 = new Report<int>(ref data, ref assessment);
        var report02 = new Report<int>(ref data, ref assessment);

        var resultIEquitable = report01.Equals(report02);
        var resultClassicEquals = report01.Equals(report02 as object);
        var resultEqualityComparer = report01 == report02;
        var resultInequalityComparer = report01 != report02;

        Assert.True(resultIEquitable);
        Assert.True(resultClassicEquals);
        Assert.True(resultEqualityComparer);
        Assert.False(resultInequalityComparer);
    }

    [Fact]
    internal void GenericReports_AreNotEqualWhen_TheyHave_SameData_ButDifferentAssessment_Locations()
    {
        var data = 5;
        var assessment01 = assessementFixture.CreateStub();
        var report01 = new Report<int>(ref data, ref assessment01);
        var assessment02 = assessementFixture.CreateStub();
        var report02 = new Report<int>(ref data, ref assessment02);

        var resultIEquitable = report01.Equals(report02);
        var resultClassicEquals = report01.Equals(report02 as object);
        var resultEqualityComparer = report01 == report02;
        var resultInequalityComparer = report01 != report02;

        Assert.False(resultIEquitable);
        Assert.False(resultClassicEquals);
        Assert.False(resultEqualityComparer);
        Assert.True(resultInequalityComparer);
    }

    [Fact]
    internal void GenericReports_AreNotEqualWhen_TheyHave_DifferentData_ButSameAssessment_Locations()
    {
        var assessment = assessementFixture.CreateStub();
        var data01 = 5;
        var report01 = new Report<int>(ref data01, ref assessment);
        var data02 = 5;
        var report02 = new Report<int>(ref data02, ref assessment);

        var resultIEquitable = report01.Equals(report02);
        var resultClassicEquals = report01.Equals(report02 as object);
        var resultEqualityComparer = report01 == report02;
        var resultInequalityComparer = report01 != report02;

        Assert.False(resultIEquitable);
        Assert.False(resultClassicEquals);
        Assert.False(resultEqualityComparer);
        Assert.True(resultInequalityComparer);
    }

    [Fact]
    internal void SimpleReports_AreEqualWhen_TheyHave_SameAssessment_Locations()
    {
        var assessment = assessementFixture.CreateStub();
        var report01 = new Report(ref assessment);
        var report02 = new Report(ref assessment);

        var resultIEquitable = report01.Equals(report02);
        var resultClassicEquals = report01.Equals(report02 as object);
        var resultEqualityComparer = report01 == report02;
        var resultInequalityComparer = report01 != report02;

        Assert.True(resultIEquitable);
        Assert.True(resultClassicEquals);
        Assert.True(resultEqualityComparer);
        Assert.False(resultInequalityComparer);
    }

    [Fact]
    internal void SimpleReports_AreNotEqualWhen_TheyHave_DifferentAssessment_Locations()
    {
        var assessment01 = assessementFixture.CreateStub();
        var report01 = new Report(ref assessment01);
        var assessment02 = assessementFixture.CreateStub();
        var report02 = new Report(ref assessment02);

        var resultIEquitable = report01.Equals(report02);
        var resultClassicEquals = report01.Equals(report02 as object);
        var resultEqualityComparer = report01 == report02;
        var resultInequalityComparer = report01 != report02;

        Assert.False(resultIEquitable);
        Assert.False(resultClassicEquals);
        Assert.False(resultEqualityComparer);
        Assert.True(resultInequalityComparer);
    }
}