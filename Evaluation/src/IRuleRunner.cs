using Evaluation.Internal;


namespace Evaluation;

public interface IRuleRunner<TEvaluation> where TEvaluation : struct, IEvaluator
{
    internal TEvaluation Run(Func<bool> rule, Operation operation);
    internal TEvaluation Run<T>(Func<T, bool> rule, T data, Operation operation);

    internal ValueTask<TEvaluation> RunAsync(Func<Task<bool>> rule, Operation operation);
    internal ValueTask<TEvaluation> RunAsync<T>(Func<T, Task<bool>> rule, T data, Operation operation);

    internal TEvaluation Terminate();
}