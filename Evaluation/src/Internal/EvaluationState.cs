namespace Evaluation.Internal;

internal enum EvaluationState
{
    Uninitialized = 0,
    Pending    = 1 << 1,
    Determined = 1 << 2,
    True       = 1 << 3,
    False      = 1 << 4 
}