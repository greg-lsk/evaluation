using View;


namespace Evaluation;

public class DelegateDefinitions
{
    public delegate bool Rule();
    public delegate Task<bool> RuleAsync();
    public delegate ValueTask<bool> RuleMaybeAsync();

    public delegate bool Rule<T>(T data) where T : class;
    public delegate Task<bool> RuleAsync<T>(T data) where T : class;
    public delegate ValueTask<bool> RuleMaybeAsync<T>(T data) where T : class;

    public delegate bool RuleOnStruct<T>(in T data) where T : struct;
    public delegate Task<bool> RuleOnStructAsync<T>(T data) where T : struct;
    public delegate ValueTask<bool> RuleOnStructMaybeAsync<T>(T data) where T : struct;

    public delegate bool RuleOnView<T>(View<T> data) where T : struct;
    public delegate Task<bool> RuleOnViewAsync<T>(View<T> data) where T : struct;
    public delegate ValueTask<bool> RuleOnViewMaybeAsync<T>(View<T> data) where T : struct;
}