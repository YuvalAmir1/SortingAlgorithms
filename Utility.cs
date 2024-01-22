using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Random rng = new Random();

            for (int i = 0; i < length; i++)
                output[i] = rng.Next(minValue, maxValue);

            return output;
        }

        public static (bool valid, int[] failedArray, int[] attemptedSort) ValidateSort(Sorts.SortDelegate sort, int[][] dataSet)
        {
            Random rng = new Random();
            for (int i = 0; i < dataSet.Length; i++)
            {
                int[] sortedArr = sort(dataSet[i]);

                if (!Validate(sortedArr))
                    return (false, dataSet[i], sortedArr);
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
                sort(dataSet[i]);
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
                Console.WriteLine($"Average time for array of size {lengths[i]}: {result}ms");
            }    

        }
    }
}
