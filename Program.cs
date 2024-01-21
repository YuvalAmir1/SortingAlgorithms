using SortingAlgorithms;

(bool valid, int[] failedArr, int[] attemptedSort) validation = Utility.ValidateSort(Sorts.quickSortDelegate, 10_000, 1, 40, -1000, 1000);

Console.WriteLine(validation.valid);
Utility.PrintArray(validation.failedArr);
Utility.PrintArray(validation.attemptedSort);