using Evaluation.Enums.Internals;


namespace Evaluation;

public readonly partial struct Evaluation
{
    private readonly EvaluationState _state;
    private bool Result => _state.Is(EvaluationState.True);

    public Evaluation() { _state = EvaluationState.Uninitialized; }
    private Evaluation(EvaluationState state) { _state = state; }
}