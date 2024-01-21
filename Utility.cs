using System;
using System.Collections.Generic;
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

        public static (bool valid, int[] failedArray, int[] attemptedSort) ValidateSort(Sorts.SortDelegate sort, int numberOfTests, int minArrayLength, int maxArrayLength, int minValue, int maxValue)
        {
            Random rng = new Random(); 
            for (int i = 0; i < numberOfTests; i++)
            {
                int[] arr = GenerateRandomArray(rng.Next(minArrayLength, maxArrayLength), minValue, maxValue);
                int[] sortedArr = sort(arr);

                if (!Validate(sortedArr))
                    return (false, arr, sortedArr);
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
    }
}
