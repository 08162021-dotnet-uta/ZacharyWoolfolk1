using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human2
    {
      private string lastName = "Smyth";
      private string firstName = "Pat";
      private string eyeColor;
      private int age;
      
      private int weight;
      public int Weight 
      { 
        get
        {
          return weight;
        } 
        set
        {
          if(value < 0 || value > 400)
          {
            weight = 0;
          }
          else weight = value;
        } 
      }

      public Human2(){}
      public Human2(string fname, string lname)
      { 
        lastName = lname;
        firstName = fname;
      }
      public Human2(string fname, string lname, int years)
      { 
        lastName = lname;
        firstName = fname;
        age = years;
      }
      public Human2(string fname, string lname, string color)
      { 
        lastName = lname;
        firstName = fname;
        eyeColor = color;
      }

      public Human2(string fname, string lname, string color, int years)
      { 
        lastName = lname;
        firstName = fname;
        eyeColor = color;
        age = years;
      }

      public string AboutMe()
      {
        return $"My name is {firstName} {lastName}.";
      }

      public string AboutMe2()
      {
        if(eyeColor == null && age == 0)
        {
          return $"My name is {firstName} {lastName}.";
        }
        else if(eyeColor != null && age == 0)
        {
          return $"My name is {firstName} {lastName}. My eye color is {eyeColor}.";
        }
        else if(eyeColor == null && age != 0)
        {
          return $"My name is {firstName} {lastName}. My age is {age}.";
        }
        else
        {
          return $"My name is {firstName} {lastName}. My age is {age}. My eye color is {eyeColor}.";
        }
      }
    }
}