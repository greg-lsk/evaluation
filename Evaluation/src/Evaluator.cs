using Evaluation.Internal;


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
        var resolutionResult = ResolutionCore(operation, evaluatedCheckResult);
        return StateUpdateCore(operation, resolutionResult);
    }


    private bool ResolutionCore(Operation operation, bool evaluatedCheckResult) => !_state.IsInitialized() ? evaluatedCheckResult : operation switch
    {
        Operation.Or =>   evaluatedCheckResult || Result,
        Operation.And =>  evaluatedCheckResult && Result,
        Operation.Must => evaluatedCheckResult && Result,
        _ => throw new ArgumentException("PlaceholderMessage::[unexpected operation type]")
    };

    private static EvaluationState StateUpdateCore(Operation operation, bool resolutionResult) => (operation, resolutionResult) switch
    {
        (_, true) => EvaluationState.True | EvaluationState.Pending,

        (Operation.Or, false) =>   EvaluationState.False | EvaluationState.Pending,
        (Operation.And, false) =>  EvaluationState.False | EvaluationState.Pending,
        (Operation.Must, false) => EvaluationState.False | EvaluationState.Determined,

        _ => throw new ArgumentException("unexpected operation type")
    };
}