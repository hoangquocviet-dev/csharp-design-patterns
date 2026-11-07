using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Strategy;

public interface ISortStrategy { void Sort(List<int> list); }

public class QuickSortStrategy : ISortStrategy {
    public void Sort(List<int> list) => list.Sort();
}

public class BubbleSortStrategy : ISortStrategy {
    public void Sort(List<int> list) => list.Sort();
}

public class SortContext {
    private ISortStrategy _strategy;
    public SortContext(ISortStrategy strategy) => _strategy = strategy;
    public void SetStrategy(ISortStrategy strategy) => _strategy = strategy;
    public void ExecuteSort(List<int> list) => _strategy.Sort(list);
}
