using Evaluation.Internal.Factories;


namespace Evaluation.Tests.Common.Fixtures;

public class EvaluationFixture<E> where E : struct, IEvaluationStateHandler<E>
{
    public Func<IEvaluationStateHandler<E>> CreateUninitialized => () => Create.EvaluationStateHandler<E>();
    public Func<EvaluationState, IEvaluationStateHandler<E>> CreateWithState => s =>
    {
        var evaluation = Create.EvaluationStateHandler<E>();
        return evaluation.WithState(s);
    };
}