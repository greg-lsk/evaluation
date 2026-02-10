namespace Evaluation.Tests.Common.Utills;

public static class TheoryDataExtensions
{
    public static void Select<TFrom, TTo>(this TheoryData<TFrom> dataSet, Func<TFrom, TTo> selector, Action<TTo> action)
    {
        foreach (var row in dataSet) action(selector(row));
    }
}