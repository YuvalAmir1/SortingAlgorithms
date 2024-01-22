using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public static class Sorts
    {
        public delegate int[] SortDelegate(int[] arr, bool sortInPlace);
        public static int[] QuickSort(int[] input, bool sortInPlace)
        {
            if (input.Length <= 1)
                return input;

            int[] arr;
            if (sortInPlace)
                arr = input;
            else
            {
                arr = new int[input.Length];
                input.CopyTo(arr, 0);
            }
            Recursion(0, arr.Length - 1);
            return arr;

            void Recursion(int startIndex, int endIndex)
            {
                int pivotValue = arr[endIndex];
                int pivot = startIndex - 1;
                int searcher = startIndex;

                while (searcher <= endIndex)
                {
                    if (arr[searcher] > pivotValue)
                        searcher++;
                    else
                    {
                        pivot++;
                        if (pivot < searcher)
                            Swap(arr, pivot, searcher);
                        else searcher++;
                    }
                }

                int startDistance = pivot - startIndex;
                int endDistance = endIndex - pivot;

                if (startDistance >= 2)
                    Recursion(startIndex, pivot - 1);
                if (endDistance >= 2)
                    Recursion(pivot + 1, endIndex);

            }
        }

        public static int[] MergeSort(int[] input, bool sortInPlace)
        {
            if (input.Length <= 1)
                return input;

            int[] arr;
            if (sortInPlace)
                arr = input;
            else
            {
                arr = new int[input.Length];
                input.CopyTo(arr, 0);
            }

            return Sort(arr);

            int[] Sort(int[] arr)
            {
                if (arr.Length <= 1)
                    return arr;

                int[] arr1 = arr.Take(arr.Length / 2).ToArray();
                int[] arr2 = arr.Skip(arr.Length / 2).ToArray();

                arr1 = Sort(arr1);
                arr2 = Sort(arr2);
                return Merge(arr1, arr2);
            }

            int[] Merge(int[] arr1, int[] arr2)
            {
                int index1, index2, index3;
                index1 = index2 = index3 = 0;
                int[] arr3 = new int[arr1.Length + arr2.Length];
                while (index1 < arr1.Length && index2 < arr2.Length)
                {
                    if (arr1[index1] < arr2[index2])
                    {
                        arr3[index3] = arr1[index1];
                        index1++;
                    }
                    else
                    {
                        arr3[index3] = arr2[index2];
                        index2++;
                    }
                    index3++;
                }

                for (; index1 < arr1.Length; index1++)
                {
                    arr3[index3] = arr1[index1];
                    index3++;
                }
                for (; index2 < arr2.Length; index2++)
                {
                    arr3[index3] = arr2[index2];
                    index3++;
                }

                return arr3;
            }
        }

        public static int[] BubbleSort(int[] input, bool sortInPlace)
        {
            if (input.Length <= 1)
                return input;

            int[] arr;
            if (sortInPlace)
                arr = input;
            else
            {
                arr = new int[input.Length];
                input.CopyTo(arr, 0);
            }

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

        public static int[] SelectionSort(int[] input, bool sortInPlace)
        {
            if (input.Length <= 1)
                return input;

            int[] arr;
            if (sortInPlace)
                arr = input;
            else
            {
                arr = new int[input.Length];
                input.CopyTo(arr, 0);
            }

            int smallestElementIndex;
            for (int edge = 0; edge < arr.Length - 1; edge++)
            {
                smallestElementIndex = edge;
                for (int i = edge + 1; i < arr.Length; i++)
                {
                    if (arr[i] <= arr[smallestElementIndex])
                        smallestElementIndex = i;
                }
                Swap(arr, edge, smallestElementIndex);
            }

            return arr;
        }

        public static int[] ImprovedQuickSort(int[] input, bool sortInPlace)
        {
            if (input.Length <= 1)
                return input;

            int[] arr;
            if (sortInPlace)
                arr = input;
            else
            {
                arr = new int[input.Length];
                input.CopyTo(arr, 0);
            }

            Recursion(0, arr.Length - 1);
            return arr;

            void Recursion(int startIndex, int endIndex)
            {
                if (endIndex - startIndex <= 10)
                {
                    // Selection Sort
                    int smallestElementIndex;
                    for (int edge = startIndex; edge < endIndex; edge++)
                    {
                        smallestElementIndex = edge;
                        for (int i = edge + 1; i <= endIndex; i++)
                        {
                            if (arr[i] <= arr[smallestElementIndex])
                                smallestElementIndex = i;
                        }
                        Swap(arr, edge, smallestElementIndex);
                    }
                    return;
                }

                // Sort first, middle, and last elements.
                int middleIndex = (endIndex - startIndex) / 2 + startIndex;
                if (arr[middleIndex] < arr[startIndex])
                {
                    if (arr[endIndex] < arr[middleIndex])
                        Swap(arr, startIndex, endIndex);
                    else
                    {
                        Swap(arr, startIndex, middleIndex);
                        if (arr[middleIndex] > arr[endIndex])
                            Swap(arr, middleIndex, endIndex);
                    }
                }
                else if (arr[middleIndex] > arr[endIndex])
                {
                    Swap(arr, middleIndex, endIndex);
                    if (arr[middleIndex] < arr[startIndex])
                        Swap(arr, startIndex, middleIndex);
                }

                int pivotValue = arr[middleIndex];
                Swap(arr, middleIndex, endIndex - 1);

                int pivot = startIndex;
                int searcher = startIndex + 1;

                while (searcher < endIndex)
                {
                    if (arr[searcher] > pivotValue)
                        searcher++;
                    else
                    {
                        pivot++;
                        if (pivot < searcher)
                            Swap(arr, pivot, searcher);
                        else searcher++;
                    }
                }

                int startDistance = pivot - startIndex;
                int endDistance = endIndex - pivot;

                if (startDistance >= 2)
                    Recursion(startIndex, pivot - 1);
                if (endDistance >= 2)
                    Recursion(pivot + 1, endIndex);

            }
        }

        private static void Swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
    }
}
