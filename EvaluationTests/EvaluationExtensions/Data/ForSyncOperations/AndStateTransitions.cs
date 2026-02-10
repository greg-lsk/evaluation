using Evaluation.Tests.Common.Data;
using Evaluation.Tests.Common.Stubs;
using Evaluation.Tests.Common.Utills;
using Evaluation.Tests.EvaluationExtensions.Data.Abstract;


namespace Evaluation.Tests.EvaluationExtensions.Data.ForSyncOperations;

public class AndOperationNoDataSync : OnNoDataResolution
{
    public AndOperationNoDataSync() => PendingEvaluationStateResolutions.AndOperations.Select(MapFrom, Add);   
}

public class AndOperationRefTypeDataSync : OnRefTypeResolution<DataStub>
{
    public AndOperationRefTypeDataSync() => PendingEvaluationStateResolutions.AndOperations.Select(MapFrom, Add);
}

public class AndOperationValueTypeDataSync : OnValueTypeResolution<int>
{
    public AndOperationValueTypeDataSync() => PendingEvaluationStateResolutions.AndOperations.Select(MapFrom, Add);
}