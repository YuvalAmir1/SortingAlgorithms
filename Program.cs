using SortingAlgorithms;

int[] longLengths = { 5, 10, 100, 500, 1000, 10_000, 100_000, 1_000_000 };
int[] longCounts = { 10_000, 10_000, 10_000, 1000, 1000, 1000, 1000, 100};
int[] shortLengths = { 5, 10, 100, 500, 1000, 10_000 };
int[] shortCounts = { 10_000, 10_000, 1000, 100, 20, 5};

Console.WriteLine("Improved Quick Sort:");
Utility.BenchmarkSort(Sorts.ImprovedQuickSort, longLengths, longCounts);
Console.WriteLine();
Console.WriteLine("Quick Sort:");
Utility.BenchmarkSort(Sorts.QuickSort, longLengths, longCounts);
Console.WriteLine();
Console.WriteLine("Merge Sort:");
Utility.BenchmarkSort(Sorts.MergeSort, longLengths, longCounts);
Console.WriteLine();
Console.WriteLine("Selection Sort:");
Utility.BenchmarkSort(Sorts.SelectionSort, shortLengths, shortCounts);
Console.WriteLine();
Console.WriteLine("Bubble Sort:");
Utility.BenchmarkSort(Sorts.BubbleSort, shortLengths, shortCounts);
