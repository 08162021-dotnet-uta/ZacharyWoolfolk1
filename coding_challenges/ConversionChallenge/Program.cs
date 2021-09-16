using System;

namespace CastConvertParse
{
    class Program
    {
        static void Main(string[] args)
        {


            //Cast Expression: used for explicit conversions
            //Implicit casting is available due to the concept of upcasting from a child object to a parent object,
            //however down casting has to be explicitly done
                       
            //Realistic Use case
            //Explicit casting could be useful when you do not care about data loss
            //In this example we just get the whole number not the decimals

            float myFloat = 30.56f;
            int myInt = (int)myFloat;

            //Pros 
            //Convience 

            //Cons
            //Data loss
            //Some cast that are not possible (i.e string to integer)
            //Conversion must exist and be unambiguous to the compiler


            //Convert
            //Returns 0 instead of throwing a null exception
           

            //Realistic Use Case
            //Could be useful when you are sure what type the data is, and what kind of information it would hold
            string data = "20000";
            int converted = Convert.ToInt32(data);
            Console.WriteLine(converted);

            //Pros
            //Can be used with objects
            //Can be used for conversions that the compiler would otherwise find ambiguous
            //Supports custom types

            //Cons
            //If the data comes from a database and you are not 100% sure the type of data you are getting, the conversion 
            //could fail or produce unexpected results



            //Parse 
            

            //Realistic Use case
            //If you are reading input from the console. Since the console only returns a string data type this input would
            //have to be parsed for numbers.

            var userInput = Console.ReadLine();
            int userInt = int.Parse(userInput);

            //Pros
            //Changes a string to a numerical type

            //Cons
            //Can only handle strings
            //throws a null exception when input is invalid
            //does not support custom types












        }
    }
}