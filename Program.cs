using SortingAlgorithms;
(bool valid, int[] failedArray, int[] attemptedSort) = Utility.ValidateSort(Sorts.QuickSort);
Console.WriteLine(valid);
Utility.PrintArray(failedArray);
Utility.PrintArray(attemptedSort);

Utility.GenerateCSV("Data", [Sorts.QuickSort, Sorts.MergeSort], ["Quick Sort", "Merge Sort"]);