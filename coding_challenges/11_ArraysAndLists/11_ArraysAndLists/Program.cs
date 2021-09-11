using System;
using System.Collections;
using System.Collections.Generic;

namespace _11_ArraysAndListsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }//EoM

        /// <summary>
        /// This method takes an array of integers and returns a double, the average 
        /// value of all the integers in the array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double AverageOfValues(int[] array)
        {
          double sum = 0;
            foreach(int x in array)
            {
              sum = sum + x;
            }
            return sum / array.Length;
        }

        /// <summary>
        /// This method increases each array element by 2 and 
        /// returns an array with the altered values.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int[] SunIsShining(int[] x)
        {
          int[] copy = new int[x.Length];
          int i = 0;
            foreach(int n in x)
            {
              copy[i] = n + 2;
              i++;
            }
            return copy;
        }

        /// <summary>
        /// This method takes an ArrayList containing types of double, int, and string 
        /// and returns the average of the ints and doubles only, as a decimal.
        /// It ignores the string values and rounds the result to 3 decimal places toward the nearest even number.
        /// </summary>
        /// <param name="myArrayList"></param>
        /// <returns></returns>
        public static decimal ArrayListAvg(ArrayList myArrayList)
        {
            double sum = 0;
            double count = 0;
            foreach(object i in myArrayList)
            {
              if(i.GetType() == typeof(int) || i.GetType() == typeof(double))
              {
                sum = sum + Convert.ToDouble(i);
                count ++;
              }
            }
            return (decimal)Math.Round(sum / count, 3);
        }

        /// <summary>
        /// This method returns the rank (starting with 1st place) of a new 
        /// score entered into a list of randomly ordered scores.
        /// </summary>
        /// <param name="myArray1"></param>
        public static int ListAscendingOrder(List<int> scores, int yourScore)
        {
            scores.Add(yourScore);
            scores.Sort();
            //scores.Reverse();
  
            return scores.IndexOf(yourScore) + 1;
        }

        /// <summary>
        /// This method has with two parameters takes a List<string> and a string.
        /// The method returns true if the string parameter is found in the List, otherwise false.
        /// </summary>
        /// <param name="myArray2"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool FindStringInList(List<string> myArray2, string word)
        {
            foreach(string i in myArray2)
            {
              if(i.Contains(word))
              {
                return true;
              }
            }
            return false;
        }
    }//EoP
}// EoN