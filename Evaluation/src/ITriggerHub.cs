namespace Evaluation;

public interface ITriggerHub
{
    //public ITriggerHub Register(Delegate rule, Action trigger);

    public ITriggerHub Register(Rule rule, Action trigger);

    public ITriggerHub Register<T>(Rule<T> rule, Action trigger) where T : class;
    public ITriggerHub Register<T>(Rule<T> rule, Action<T> trigger) where T : class;
}