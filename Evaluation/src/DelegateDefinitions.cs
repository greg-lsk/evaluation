using View;


namespace Evaluation;

public class DelegateDefinitions
{
    public delegate bool Rule();
    public delegate Task<bool> RuleAsync();
    public delegate ValueTask<bool> RulePerfAsync();

    public delegate bool Rule<T>(T data) where T : class;
    public delegate Task<bool> RuleAsync<T>(T data) where T : class;
    public delegate ValueTask<bool> RulePerfAsync<T>(T data) where T : class;

    public delegate bool ValueRule<T>(in T data) where T : struct;
    public delegate Task<bool> ValueRuleAsync<T>(T data) where T : struct;
    public delegate ValueTask<bool> ValueRulePerfAsync<T>(T data) where T : struct;

    public delegate bool ViewRule<T>(View<T> data) where T : struct;
    public delegate Task<bool> ViewRuleAsync<T>(View<T> data) where T : struct;
    public delegate ValueTask<bool> ViewRulePerfAsync<T>(View<T> data) where T : struct;
}