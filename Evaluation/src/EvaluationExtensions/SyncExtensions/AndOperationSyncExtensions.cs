namespace Evaluation;

public static partial class EvaluationExtensions
{
    public static E And<E>(this E evaluator, Check check) 
        where E : struct, IEvaluationStateHandler<E>
    {
        if (evaluator.IsDetermined) return evaluator;

        var checkResult = check();
        var state = evaluator.DetermineNextState(Operation.And, checkResult);

        return evaluator.WithState(state);
    }

    public static E And<E, D>(this E evaluator, Check<D> check, D data) 
        where E : struct, IEvaluationStateHandler<E>
        where D : class
    {
        if (evaluator.IsDetermined) return evaluator;

        var checkResult = check(data);
        var state = evaluator.DetermineNextState(Operation.And, checkResult);

        return evaluator.WithState(state);
    }

    public static E And<E, D>(this E evaluator, CheckOnStruct<D> check, in D data)
        where E : struct, IEvaluationStateHandler<E>
        where D : struct
    {
        if (evaluator.IsDetermined) return evaluator;

        var checkResult = check(in data);
        var state = evaluator.DetermineNextState(Operation.And, checkResult);

        return evaluator.WithState(state);
    }
}