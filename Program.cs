using SortingAlgorithms;

int[] longLengths = { 5, 10, 100, 500, 1000, 10_000, 100_000, };
int[] longCounts = { 10_000, 10_000, 10_000, 1000, 1000, 1000, 100};
int[] shortLengths = { 5, 10, 100, 500, 1000, 10_000, 100_000 };
int[] shortCounts = { 10_000, 10_000, 1000, 100, 20, 5, 1};

Utility.BenchmarkSorts(longLengths, longCounts, shortLengths, shortCounts);