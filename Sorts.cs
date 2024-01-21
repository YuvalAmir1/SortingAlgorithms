using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public static class Sorts
    {
        public delegate int[] SortDelegate(int[] arr);

        public static int[] QuickSort(int[] input)
        {
            int[] arr = new int[input.Length];
            input.CopyTo(arr, 0);
            Recurion(0, arr.Length - 1);
            return arr;

            void Recurion(int startIndex, int endIndex)
            {
                int pivot = PositionPivot();
                int startDistance = pivot - startIndex;
                int endDistance = endIndex - pivot;

                if (startDistance >= 2)
                    Recurion(startIndex, pivot - 1);
                if (endDistance >= 2)
                    Recurion(pivot + 1, endIndex);

                int PositionPivot()
                {
                    int pivotValue = arr[endIndex];
                    int movingPivot = -1;
                    int searcher = 0;

                    while (searcher <= endIndex)
                    {
                        if (arr[searcher] > pivotValue)
                            searcher++;
                        else
                        {
                            movingPivot++;
                            if (movingPivot < searcher)
                                Swap(arr, movingPivot, searcher);
                            else searcher++;
                        }
                    }

                    return movingPivot;
                }
            }
        }
        public static SortDelegate quickSortDelegate = QuickSort;

        public static int[] BubbleSort(int[] input)
        {
            int[] arr = new int[input.Length];
            input.CopyTo(arr, 0);
            bool sorted = false;
            int sortedCount = 0;
            while (!sorted && sortedCount < arr.Length - 1)
            {
                sorted = true;
                for (int i = 1; i < arr.Length - sortedCount; i++)
                {
                    if (!CompareAndSwap(i - 1, i))
                        sorted = false;
                }
                sortedCount++;
            }

            return arr;

            bool CompareAndSwap(int index1, int index2)
            {
                if (arr[index1] <= arr[index2])
                    return true;

                Swap(arr, index1, index2);
                return false;
            }
        }
        public static SortDelegate bubbleSortDelegate = BubbleSort;

        private static void Swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
    }
}
