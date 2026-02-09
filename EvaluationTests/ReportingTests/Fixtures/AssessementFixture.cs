using Evaluation.Reporting.Internals;


namespace Evaluation.Tests.ReportingTests.Fixtures;

public class AssessementFixture
{
    internal Func<Assessment> CreateStub { get; private set; }

    public AssessementFixture() => CreateStub = () => new
    (
        Operation.Or,
        () => true,
        true,
        DateTime.Now,
        DateTime.Now,
        5,
        "mockPath"
    );
}