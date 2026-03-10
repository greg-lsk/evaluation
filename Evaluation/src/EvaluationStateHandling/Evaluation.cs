using Evaluation.Enums.Internals;
using Evaluation.Internal.Factories;
using Evaluation.Internal.Resolution;


namespace Evaluation;

public readonly partial struct Evaluation : IEvaluationStateHandler<Evaluation>
{
    bool IEvaluationStateHandler<Evaluation>.Result => Result;
    bool IEvaluationStateHandler<Evaluation>.IsDetermined => _state.Is(EvaluationState.Determined);
    EvaluationState IEvaluationStateHandler<Evaluation>.State => _state;


    Evaluation IEvaluationStateHandler<Evaluation>.WithState(EvaluationState state) => new(state);
    Evaluation IEvaluationStateHandler<Evaluation>.Terminate() => Result switch
    {
        true =>  new(EvaluationState.True | EvaluationState.Determined),
        false => new(EvaluationState.False | EvaluationState.Determined)
    };


    EvaluationState IEvaluationStateHandler<Evaluation>.DetermineNextState(Operation operation, bool checkResult)
    {
        var resolver = Create.StatelessStruct<Resolver>();

        if (resolver.EvaluationBecomesDetermined(checkResult, operation)) return EvaluationState.False | EvaluationState.Determined;

        var state = _state.IsInitialized() switch
        {
            true => resolver.Resolve(checkResult, operation, Result) ? EvaluationState.True : EvaluationState.False,
            false => checkResult ? EvaluationState.True : EvaluationState.False
        };

        return state | EvaluationState.Pending;
    }
}