namespace Evaluation.Tests.Common.Fixtures;

public class EvaluationFixture<E> where E : struct, IEvaluationStateHandler<E>
{
    public Func<IEvaluationStateHandler<E>> CreateUninitialized => () => IEvaluationStateHandler<E>.Create();
    public Func<EvaluationState, IEvaluationStateHandler<E>> CreateWithState => s =>
    {
        var evaluation = IEvaluationStateHandler<E>.Create();
        return evaluation.WithState(s);
    };
}