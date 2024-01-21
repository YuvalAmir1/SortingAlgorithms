using SortingAlgorithms;

int[] lengths = { 5, 10, 100, 500, 1000, 10_000, 100_000 };
int[] counts = { 10_000, 10_000, 1000, 1000, 1000, 50, 10};
Utility.BenchmarkSort(Sorts.QuickSort, lengths, counts);