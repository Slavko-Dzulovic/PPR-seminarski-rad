using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Merge Sort
        /// </summary>
        /// <param name="inputItems"> Niz za sortiranje </param>
        /// <param name="lowerBound"> Donja granica za sortiranje </param>
        /// <param name="upperBound"> Gornja granica za sortiranje </param>
        /// <returns> Sortiran niz </returns>
        private static int[] MergeSort(int[] inputItems, int lowerBound, int upperBound)
        {
            if (lowerBound < upperBound)
            {
                var middle = (lowerBound + upperBound) / 2;
         
                MergeSort(inputItems, lowerBound, middle);
                MergeSort(inputItems, middle + 1, upperBound);
         
                //Merge
                var leftArray = new int[middle - lowerBound + 1];
                var rightArray = new int[upperBound - middle];
         
                Array.Copy(inputItems, lowerBound, leftArray, 0, middle - lowerBound + 1);
                Array.Copy(inputItems, middle + 1, rightArray, 0, upperBound - middle);
         
                var i = 0;
                var j = 0;
                for (var count = lowerBound; count < upperBound + 1; count++)
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
    
        /// <summary>
        /// Bubble sort
        /// </summary>
        /// <param name="scrambledArray"> Niz za sortiranje </param>
        /// <returns> Sortiran niz </returns>
        private static int[] BubbleSort(int[] scrambledArray)
        {
            for (var count = scrambledArray.Length - 1; count >= 0; count--)
            {
                for (var innerCount = 1; innerCount <= count; innerCount++)
                {
                    if (scrambledArray[innerCount - 1] > scrambledArray[innerCount])
                    {
                        var temp = scrambledArray[innerCount - 1];
                        scrambledArray[innerCount - 1] = scrambledArray[innerCount];
                        scrambledArray[innerCount] = temp;
                    }
                }
            }
            
            return scrambledArray;
        }
        
        /// <summary>
        /// Generisanje novog niza nasumičnih brojeva
        /// </summary>
        /// <returns> Niz nasumičnih elemenata</returns>
        private static int[] GenerateArray()
        {
            const int Min = 0;
            const int Max = 5000000;

            var array = new int[10000000]; 

            var randNum = new Random();
            
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = randNum.Next(Min, Max);
            }   
            
            return array;
        }

        private static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            
            var array = GenerateArray();

            stopWatch.Start();

            // Poziv funkcije čije se vreme izvršavanja meri
            
            stopWatch.Stop();
            
            var time = stopWatch.Elapsed;

            var elapsedTime = $"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}.{time.Milliseconds / 10:00}";
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}