namespace Evaluation;

internal interface ITriggerActivator
{
    internal void ActivateFor<R>(R rule) where R : Delegate;
    internal void ActivateFor<R, T>(R rule, T data) where R : Delegate;
}