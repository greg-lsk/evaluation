using Evaluation.Tests.Common.Data;
using Evaluation.Tests.Common.Stubs;
using Evaluation.Tests.Common.Utills;
using Evaluation.Tests.EvaluationExtensions.Data.Abstract;


namespace Evaluation.Tests.EvaluationExtensions.Data;

public class OnNoDataAndOperation : OnNoDataResolution
{
    public OnNoDataAndOperation() => PendingEvaluationStateResolutions.AndOperations.Select(MapFrom, Add);   
}

public class OnRefTypeAndOperation : OnRefTypeResolution<DataStub>
{
    public OnRefTypeAndOperation() => PendingEvaluationStateResolutions.AndOperations.Select(MapFrom, Add);
}

public class OnValueTypeAndOperation : OnValueTypeResolution<int>
{
    public OnValueTypeAndOperation() => PendingEvaluationStateResolutions.AndOperations.Select(MapFrom, Add);
}