using Evaluation.Enums.Internals;
using Evaluation.Internal.Resolution;


namespace Evaluation;

public readonly struct Evaluation : IEvaluationStateHandler<Evaluation>
{
    private readonly EvaluationState _state;
    private bool Result => _state.Is(EvaluationState.True);

    bool IEvaluationStateHandler<Evaluation>.Result => Result;
    bool IEvaluationStateHandler<Evaluation>.IsDetermined => _state.Is(EvaluationState.Determined);
    EvaluationState IEvaluationStateHandler<Evaluation>.State => _state;


    public Evaluation() { _state = EvaluationState.Uninitialized; }
    private Evaluation(EvaluationState state) { _state = state; }

    Evaluation IEvaluationStateHandler<Evaluation>.WithState(EvaluationState state) => new(state);
    Evaluation IEvaluationStateHandler<Evaluation>.Terminate() => Result switch
    {
        true =>  new(EvaluationState.True | EvaluationState.Determined),
        false => new(EvaluationState.False | EvaluationState.Determined)
    };


    EvaluationState IEvaluationStateHandler<Evaluation>.DetermineNextState(Operation operation, bool checkResult)
    {
        if (IResolver.EvaluationBecomesDetermined(checkResult, operation)) return EvaluationState.False | EvaluationState.Determined;

        var state = _state.IsInitialized() switch
        {
            true =>  IResolver.Resolve(checkResult, operation, Result) ? EvaluationState.True : EvaluationState.False,
            false => checkResult ? EvaluationState.True : EvaluationState.False
        };

        return state | EvaluationState.Pending;
    }
}