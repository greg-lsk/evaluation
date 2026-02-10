namespace Evaluation;

public interface ITriggerActivator
{
    internal void ActivateTriggersOn(Report report);
    internal void ActivateTriggersOn<TData>(Report<TData> report);
}