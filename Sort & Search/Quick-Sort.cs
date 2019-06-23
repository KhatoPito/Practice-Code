    private static void Quick_Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            Quick_Sort(arr, left, pivot - 1);
            Quick_Sort(arr, pivot + 1, right);
        }

    }

    // {10(pivot),16(i),8,12,15,6,3,9,5(j)}
    // i > pivot and j < pivot -- swap(i,j) 
    // at the end of while loop swap (pivot, j)
    private static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[left];
        while (true)
        {
            while (arr[left] < pivot)
                left++;

            while (arr[right] > pivot)
                right--;

            if (left < right)
            {
                if (arr[left] == arr[right]) return right;
                swap(arr, left, right);
            }
            else
                return right; // new pivot 
        }
    }

    private static void swap(int[] arr, int left, int right)
    {
        int temp = arr[left];
        arr[left] = arr[right];
        arr[right] = temp;
    }
    
    public static void Main()
    {
        int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
        Quick_Sort(arr, 0, arr.Length-1);
        
        Console.ReadLine();
    }
