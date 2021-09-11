using System;

namespace _9_ClassesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
          Human Pat = new Human();
          Human Johnny = new Human("Johnny", "Bravo");

          Pat.AboutMe();
          Johnny.AboutMe();


          Human2 Patty = new Human2("Patty", "Greene", "green");
          Human2 Elda = new Human2("Elda", "Grinwald", 72);
          Human2 Gerald = new Human2("Gerald", "Geraldson", "brown", 35);

          Patty.AboutMe2();
          Elda.AboutMe2();
          Gerald.AboutMe2();

          Human2 Jones = new Human2();
          Jones.Weight = 150;
          Jones.Weight = 450;
        }
    }
}
