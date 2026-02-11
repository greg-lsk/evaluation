namespace Evaluation;

public interface ITriggerHub
{
    //public ITriggerHub Register(Delegate rule, Action trigger);

    public ITriggerHub Register(Check check, Action trigger);

    public ITriggerHub Register<T>(Check<T> check, Action trigger) where T : class;
    public ITriggerHub Register<T>(Check<T> check, Action<T> trigger) where T : class;
}