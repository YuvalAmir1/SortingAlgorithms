int[] QuickSort(int[] input)
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

void Swap(int[] arr, int index1, int index2)
{
    int temp = arr[index1];
    arr[index1] = arr[index2];
    arr[index2] = temp;
}

void PrintArray(int[] input)
{
    Console.Write(input[0]);
    for (int i = 1; i < input.Length; i++)
        Console.Write(", " + input[i]);
    Console.WriteLine();
}