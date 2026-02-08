using Evaluation.Internal;
using Evaluation.Internal.Resolution;


namespace Evaluation;

public readonly struct Evaluator : IEvaluationStateHandler<Evaluator>
{
    private readonly EvaluationState _state;
    private bool Result => _state.Is(EvaluationState.True);

    bool IEvaluationStateHandler<Evaluator>.Result => Result;
    bool IEvaluationStateHandler<Evaluator>.IsDetermined => _state.Is(EvaluationState.Determined);
    EvaluationState IEvaluationStateHandler<Evaluator>.State => _state;


    public Evaluator() { _state = EvaluationState.Uninitialized; }
    private Evaluator(EvaluationState state) { _state = state; }

    Evaluator IEvaluationStateHandler<Evaluator>.WithState(EvaluationState state) => new(state);
    Evaluator IEvaluationStateHandler<Evaluator>.Terminate() => Result switch
    {
        true =>  new(EvaluationState.True | EvaluationState.Determined),
        false => new(EvaluationState.False | EvaluationState.Determined)
    };


    EvaluationState IEvaluationStateHandler<Evaluator>.DetermineNextState(Operation operation, bool evaluatedCheckResult)
    {
        if (IResolver.EvaluationBecomesDetermined(evaluatedCheckResult, operation)) return EvaluationState.False | EvaluationState.Determined;

        var state = _state.IsInitialized() switch
        {
            true =>  IResolver.BooleanResolution(evaluatedCheckResult, operation, Result) ? EvaluationState.True : EvaluationState.False,
            false => evaluatedCheckResult ? EvaluationState.True : EvaluationState.False
        };

        return state | EvaluationState.Pending;
    }
}