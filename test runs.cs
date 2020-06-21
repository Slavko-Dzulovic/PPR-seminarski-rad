using System;
using System.Diagnostics;
using System.Threading;
class Program
{
    /// <summary>
/// Merge Sort
/// </summary>
/// <param name="inputItems">Array to be Sorted</param>
/// <param name="lowerBound">Lower Bound</param>
/// <param name="upperBound">Upper Bound</param>
/// <returns>Sorted Array</returns>
public static int[] MergeSort(int[] inputItems, int lowerBound, int upperBound)
{
    if (lowerBound < upperBound)
    {
        int middle = (lowerBound + upperBound) / 2;
 
        MergeSort(inputItems, lowerBound, middle);
        MergeSort(inputItems, middle + 1, upperBound);
 
        //Merge
        int[] leftArray = new int[middle - lowerBound + 1];
        int[] rightArray = new int[upperBound - middle];
 
        Array.Copy(inputItems, lowerBound, leftArray, 0, middle - lowerBound + 1);
        Array.Copy(inputItems, middle + 1, rightArray, 0, upperBound - middle);
 
        int i = 0;
        int j = 0;
        for (int count = lowerBound; count < upperBound + 1; count++)
        {
            if (i == leftArray.Length)
            {
                inputItems[count] = rightArray[j];
                j++;
            }
            else if (j == rightArray.Length)
            {
                inputItems[count] = leftArray[i];
                i++;
            }
            else if (leftArray[i] <= rightArray[j])
            {
                inputItems[count] = leftArray[i];
                i++;
            }
            else
            {
                inputItems[count] = rightArray[j];
                j++;
            }
        }
    }
    return inputItems;
}
    
    private static int[] BubbleSort(int[] scrambledArray)
    {
        for (int count = scrambledArray.Length - 1; count >= 0; count--)
        {
            for (int innercount = 1; innercount <= count; innercount++)
            {
                if (scrambledArray[innercount - 1] > scrambledArray[innercount])
                {
                    int temp = scrambledArray[innercount - 1];
                    scrambledArray[innercount - 1] = scrambledArray[innercount];
                    scrambledArray[innercount] = temp;
                }
            }
        }
        
        return scrambledArray;
    }
    
    private static int[] GenerateArray()
    {
        int Min = 0;
        int Max = 5000000;

        int[] test2 = new int[5000000]; 

        Random randNum = new Random();
        
        for (int i = 0; i < test2.Length; i++)
        {
            test2[i] = randNum.Next(Min, Max);
        }   
        
        return test2;
    }

    static void Main(string[] args)
    {
        Stopwatch stopWatch = new Stopwatch();
        
        int[] a = GenerateArray();
        
        stopWatch.Start();
        
        MergeSort(a, 0, 4999999);
        
        stopWatch.Stop();
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value.
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);
    }
}