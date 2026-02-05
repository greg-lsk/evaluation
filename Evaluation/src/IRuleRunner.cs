using Evaluation.Internal;


namespace Evaluation;

public interface IRuleRunner<TEvaluation> where TEvaluation : struct, IEvaluator
{
    internal TEvaluation Run(Rule rule, Operation operation);
    internal ValueTask<TEvaluation> RunAsync(RuleAsync rule, Operation operation);
    
    internal TEvaluation Run<T>(Rule<T> rule, T data, Operation operation) where T : class;
    internal ValueTask<TEvaluation> RunAsync<T>(RuleAsync<T> rule, T data, Operation operation) where T : class;

    internal TEvaluation Terminate();
}