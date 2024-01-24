using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Xml.XPath;
using System.Data;

namespace SortingAlgorithms
{
    public static class Utility
    {
        public static void PrintArray(int[] input)
        {
            if (input.Length == 0)
            {
                Console.WriteLine("Empty array.");
                return;
            }

            Console.Write(input[0]);
            for (int i = 1; i < input.Length; i++)
                Console.Write(", " + input[i]);
            Console.WriteLine();
        }

        public static int[] GenerateRandomArray(int length, int minValue, int maxValue)
        {
            int[] output = new int[length];
            Random rng = new();

            for (int i = 0; i < length; i++)
                output[i] = rng.Next(minValue, maxValue);

            return output;
        }

        public static (bool valid, int[] failedArray, int[] attemptedSort) ValidateSort(Sorts.SortDelegate sort)
        {
            int[][] dataSet;

            for (int i = 0; i <= 100; i++)
            {
                dataSet = GenerateDataSet(i, 10_000, -100, 100);
                for (int r = 0; r < dataSet.Length; r++)
                {
                    int[] sortedArr = sort(dataSet[r], false);

                    if (!Validate(sortedArr))
                        return (false, dataSet[r], sortedArr);
                }
            }
            return (true, Array.Empty<int>(), Array.Empty<int>());

            bool Validate(int[] arr)
            {
                if (arr.Length <= 1)
                    return true;
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i - 1] > arr[i])
                        return false;
                }
                return true;
            }
        }

        public static int[][] GenerateDataSet(int arrayLength, int arrayCount, int minValue, int maxValue)
        {
            int[][] arr = new int[arrayCount][];
            for (int i = 0; i < arrayCount; i++)
                arr[i] = GenerateRandomArray(arrayLength, minValue, maxValue);
            return arr;
        }

        public static double AverageSortTimeMs(Sorts.SortDelegate sort, int[][] dataSet)
        {
            long startTime = Stopwatch.GetTimestamp();
            for (int i = 0; i < dataSet.Length; i++)
                sort(dataSet[i], true);
            TimeSpan elapsedTime = Stopwatch.GetElapsedTime(startTime);
            return elapsedTime.TotalMilliseconds / dataSet.Length;
        }

        public static void BenchmarkSort(Sorts.SortDelegate sort, int[] lengths, int[] arrayCounts)
        {
            int minValue = -1000;
            int maxValue = 1000;

            for (int i = 0; i < lengths.Length; i++)
            {
                int[][] dataSet = GenerateDataSet(lengths[i], arrayCounts[i], minValue, maxValue);
                double result = AverageSortTimeMs(sort, dataSet);
                result = Math.Round(result, 5);
                Console.WriteLine($"Average time for array of size {lengths[i]:n0}: {result}ms");
            }

        }

        public static void BenchmarkSorts(int[] longLengths, int[] longCounts, int[] shortLengths, int[] shortCounts)
        {
            Console.WriteLine("Quick Sort:");
            BenchmarkSort(Sorts.QuickSort, longLengths, longCounts);
            Console.WriteLine();
            Console.WriteLine("Merge Sort:");
            BenchmarkSort(Sorts.MergeSort, longLengths, longCounts);
            Console.WriteLine();
            Console.WriteLine("Selection Sort:");
            BenchmarkSort(Sorts.SelectionSort, shortLengths, shortCounts);
            Console.WriteLine();
            Console.WriteLine("Bubble Sort:");
            BenchmarkSort(Sorts.BubbleSort, shortLengths, shortCounts);
        }

        public static void GenerateCSV(string fileName, Sorts.SortDelegate[] sorts, string[] sortNames)
        {
            StreamWriter SW = new(fileName + ".csv");
            double[][] results = new double[sorts.Length][];

            int elementsCount = 73;
            int[] lengths = new int[elementsCount];
            int[] counts = new int[elementsCount];

            int index = 0;
            for (int interval = 0; interval <= 7; interval++)
            {
                for (int r = 1; r <= 9; r++)
                {
                    lengths[index] = (int)(r * Math.Pow(10, interval));
                    counts[index] = GetCount(lengths[index]);
                    index++;
                }
            }
            lengths[elementsCount - 1] = 100_000_000;
            counts[elementsCount - 1] = GetCount(100_000_000);


            for (int i = 0; i < sorts.Length; i++)
            {
                results[i] = new double[lengths.Length];
                Console.WriteLine(sortNames[i] + ":");
                for (int r = 0; r < lengths.Length; r++)
                {
                    int[][] dataSet = GenerateDataSet(lengths[r], counts[r], -1000, 1000);
                    double result = AverageSortTimeMs(sorts[i], dataSet);
                    Console.WriteLine($"{lengths[r]:n0}: {result}ms");
                    results[i][r] = result;
                }
                Console.WriteLine();
            }

            using (SW)
            {
                SW.Write("");
                foreach (int length in lengths)
                    SW.Write($", {length:n0}");
                SW.WriteLine();

                for (int i = 0; i < sorts.Length; i++)
                {
                    SW.Write(sortNames[i]);
                    foreach (double result in results[i])
                        SW.Write($", {result}");
                    SW.WriteLine();
                }
            }

            int GetCount(int length)
            {
                if (length <= 1000)
                    return 10_000;
                if (length <= 10_000)
                    return 1000;
                if (length <= 100_000)
                    return 500;
                if (length <= 1_000_000)
                    return 20;
                if (length <= 10_000_000)
                    return 10;
                return 5;
            }
        }
    }
}
