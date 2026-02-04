namespace Evaluation;

public interface ITriggerHub
{
    public ITriggerHub Register(Delegate rule, Action trigger);
    public ITriggerHub Register(Func<bool> rule, Action trigger);
    public ITriggerHub Register<T>(Func<T, bool> rule, Action trigger);
    public ITriggerHub Register<T>(Func<T, bool> rule, Action<T> trigger);
}