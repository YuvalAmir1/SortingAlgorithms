using SortingAlgorithms;

(bool valid, int[] failedArr, int[] attemptedSort) validation = Utility.ValidateSort(Sorts.selectionSortDelegate, 1000, 0, 20, -1000, 1000);

Console.WriteLine(validation.valid);
Utility.PrintArray(validation.failedArr);
Utility.PrintArray(validation.attemptedSort);