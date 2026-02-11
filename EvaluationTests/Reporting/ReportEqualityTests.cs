using Evaluation.Tests.Reporting.Fixtures;


namespace Evaluation.Tests.Reporting;

public class ReportEqualityTests(AssessementFixture assessementFixture) : IClassFixture<AssessementFixture>
{

    [Fact]
    internal void GenericReports_AreEqualWhen_TheyHave_SameDataAndAssessment_Locations()
    {
        var data = 5;
        var assessment = assessementFixture.CreateStub();

        var report01 = new Report<int>(ref data, ref assessment);
        var report02 = new Report<int>(ref data, ref assessment);

        Assert.True(report01.Equals(report02)
                    && report01.Equals(report02 as object)
                    && report01 == report02
                    && !(report01 != report02));
    }

    [Fact]
    internal void GenericReports_AreNotEqualWhen_TheyHave_SameData_ButDifferentAssessment_Locations()
    {
        var data = 5;

        var assessment01 = assessementFixture.CreateStub();
        var report01 = new Report<int>(ref data, ref assessment01);

        var assessment02 = assessementFixture.CreateStub();
        var report02 = new Report<int>(ref data, ref assessment02);

        Assert.True(!report01.Equals(report02)
                    && !report01.Equals(report02 as object)
                    && !(report01 == report02)
                    && report01 != report02);
    }

    [Fact]
    internal void GenericReports_AreNotEqualWhen_TheyHave_DifferentData_ButSameAssessment_Locations()
    {
        var assessment = assessementFixture.CreateStub();

        var data01 = 5;
        var report01 = new Report<int>(ref data01, ref assessment);
        
        var data02 = 5;
        var report02 = new Report<int>(ref data02, ref assessment);

        Assert.True(!report01.Equals(report02)
                    && !report01.Equals(report02 as object)
                    && !(report01 == report02)
                    && report01 != report02);
    }

    [Fact]
    internal void SimpleReports_AreEqualWhen_TheyHave_SameAssessment_Locations()
    {
        var assessment = assessementFixture.CreateStub();
        var report01 = new Report(ref assessment);
        var report02 = new Report(ref assessment);

        Assert.True(report01.Equals(report02)
                    && report01.Equals(report02 as object)
                    && report01 == report02
                    && !(report01 != report02));
    }

    [Fact]
    internal void SimpleReports_AreNotEqualWhen_TheyHave_DifferentAssessment_Locations()
    {
        var assessment01 = assessementFixture.CreateStub();
        var report01 = new Report(ref assessment01);

        var assessment02 = assessementFixture.CreateStub();
        var report02 = new Report(ref assessment02);

        Assert.True(!report01.Equals(report02)
                    && !report01.Equals(report02 as object)
                    && !(report01 == report02)
                    && report01 != report02);
    }
}