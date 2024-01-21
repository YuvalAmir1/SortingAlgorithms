using SortingAlgorithms;

Sorts.SortDelegate sort = Sorts.MergeSort;
int numberOfTests = 10_000;
int minArrayLength = 0;
int maxArrayLength = 1000;
int minValue = -1000;
int maxValue = 1000;

(bool valid, int[] failedArr, int[] attemptedSort) validation = Utility.ValidateSort(sort, numberOfTests, minArrayLength, maxArrayLength, minValue, maxValue);
Console.WriteLine(validation.valid);
Utility.PrintArray(validation.failedArr);
Utility.PrintArray(validation.attemptedSort);