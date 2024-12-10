using System;

class Arrays
{
     public static void ArrayEx()
    {
        // Accept size from the user
        Console.Write("Enter the size of the array: ");
        int size = int.Parse(Console.ReadLine());

        // Create the array with the specified size
        int[] dynamicArray = new int[size];

        // Populate the array
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            dynamicArray[i] = int.Parse(Console.ReadLine());
        }

        // Display the array
        Console.WriteLine("You entered:");
        foreach (var item in dynamicArray)
        {
            Console.WriteLine(item);
        }
    }

    public static void MulArray()
    {
        int[,] matrix = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

        for(int i=0;i<2;i++)
        {
            for(int j=0;j<3;j++)
            {
                Console.WriteLine(matrix[i,j]);
            }
        }
    }

    //jagged arrays are array of arrays
    public static void JaggedArr()
    {
        int[][] jaggedArray = new int[2][];
        jaggedArray[0] = new int[] { 1, 2 };
        jaggedArray[1] = new int[] { 3, 4, 5 };
    
        for(int i=0;i<2; i++)
        {
            for (int j=0;j<3; j++)
            {
                Console.WriteLine(jaggedArray[i]);
            }
        }


    }
}
