using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human
    {
      private string lastName = "Smyth";
      private string firstName = "Pat";

      public Human(){}
      public Human(string fname, string lname)
      { 
        lastName = lname;
        firstName = fname;
      }

      public string AboutMe()
      {
        return $"My name is {firstName} {lastName}.";
      }
    }//end of class
}//end of namespace