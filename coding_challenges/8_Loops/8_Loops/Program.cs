using System;
using System.Collections.Generic;

namespace _8_LoopsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Your code here */

        }

        /// <summary>
        /// Return the number of elements in the List<int> that are odd.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseFor(List<int> x)
        {
          int count = 0;
            for(int i = 0; i < x.Count; i++)
            {
              if(x[i] % 2 != 0)
              {
                count++;
              }
            }
            return count;
        }

        /// <summary>
        /// This method counts the even entries from the provided List<object> 
        /// and returns the total number found.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseForEach(List<object> x)
        {
            int count = 0;
            foreach(object i in x)
            {
              if((long)i % 2 == 0)
              {
                count++;
              }
            }
            return count;
        }

        /// <summary>
        /// This method counts the multiples of 4 from the provided List<int>. 
        /// Exit the loop when the integer 1234 is found.
        /// Return the total number of multiples of 4.
        /// </summary>
        /// <param name="x"></param>
        public static int UseWhile(List<int> x)
        {
            int num = 0;
            int count = 0;
            while(x[num] != 1234)
            {
              if(x[num] % 4 == 0)
              {
                count++;
              }
              num++;
            }
            return count;
        }

        /// <summary>
        /// This method will evaluate the Int Array provided and return how many of its 
        /// values are multiples of 3 and 4.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseForThreeFour(int[] x)
        {
            int count = 0;
            for(int i = 0; i < x.Length; i++)
            {
              if((x[i] % 3 == 0) && (x[i] % 4 == 0))
              {
                count++;
              }
            }
            return count;
        }

        /// <summary>
        /// This method takes an array of List<string>'s. 
        /// It concatenates all the strings, with a space between each, in the Lists and returns the resulting string.
        /// </summary>
        /// <param name="stringListArray"></param>
        /// <returns></returns>
        public static string LoopdyLoop(List<string>[] stringListArray)
        {
            string result = "";
            foreach(List<string> sL in stringListArray)
            {
              string current = "";
              foreach(string s in sL)
              {
                current = current + s + " ";
              }
              result = result + current;
            }
            return result;
        }
    }
}