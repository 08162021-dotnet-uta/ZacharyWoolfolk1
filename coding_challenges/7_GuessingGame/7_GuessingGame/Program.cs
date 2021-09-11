using System;
using System.Collections.Generic;

namespace _7_GuessingGameChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
          bool playing;
          do{
            playing = true;
            Console.WriteLine("Welcome to the Guessing game.\nYou must guess a randomly generated number in the range of 0 to 100.\nYou have 10 attempts to guess the correct number.");
            List<int> guesses = new List<int>();
            int target = GetRandomNumber();
            int guess = GetUsersGuess();

            while((CompareNums(target, guess) != 0) && (guesses.Count < 10))
            {
              if(CompareNums(target, guess) == -1)
              {
                Console.WriteLine("Your guess was too high.");
                guesses.Add(guess);
                Console.WriteLine("Guesses so far: {0}", string.Join(", ", guesses));
                if (guesses.Count < 10) guess = GetUsersGuess();
              }
              else
              {
                Console.WriteLine("Your guess was too low.");
                guesses.Add(guess);
                Console.WriteLine("Guesses so far: {0}", string.Join(", ", guesses));
                if (guesses.Count < 10) guess = GetUsersGuess();
              }
            }
              if(CompareNums(target, guess) == 0)
              {
                Console.WriteLine("You Win!  The answer was indeed {0}", target);
                if(PlayGameAgain())
                {
                  playing = true;
                }
                else
                {
                  playing = false;
                }
              }
              else
              {
                Console.WriteLine("You've Lost.  The answer was {0}", target);
                if(PlayGameAgain())
                {
                  playing = true;
                }
                else
                {
                  playing = false;
                }
              }            
          } while(playing);

          Console.WriteLine("Thanks for playing!");
        }

        /// <summary>
        /// This method returns a randomly chosen number between 1 and 100, inclusive.
        /// </summary>
        /// <returns></returns>
        public static int GetRandomNumber()
        {
            Random rand = new Random();
            return rand.Next(0, 101);
        }

        /// <summary>
        /// This method gets input from the user, 
        /// verifies that the input is valid and 
        /// returns an int.
        /// </summary>
        /// <returns></returns>
        public static int GetUsersGuess()
        {
            Console.WriteLine("Enter your guess: ");
            int input = int.Parse(Console.ReadLine());
            while(input < 0 || input > 100)
            {
              Console.WriteLine("Not a valid guess.  Enter a new guess: ");
              input = int.Parse(Console.ReadLine());
            }
            return input;
        }

        /// <summary>
        /// This method will has two int parameters.
        /// It will:
        /// 1) compare the first number to the second number
        /// 2) return -1 if the first number is less than the second number
        /// 3) return 0 if the numbers are equal
        /// 4) return 1 if the first number is greater than the second number
        /// </summary>
        /// <param name="randomNum"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static int CompareNums(int randomNum, int guess)
        {
            if(randomNum < guess)
            {
              return -1;
            }
            else if(randomNum == guess)
            {
              return 0;
            }
            else
            {
              return 1;
            }
        }

        public static bool PlayGameAgain()
        {
            Console.WriteLine("Would you like to play again? ");
            Console.WriteLine("\t[1] - Yes\n\t[2] - No");
            int input = int.Parse(Console.ReadLine());
            while(input < 1 || input > 2)
            {
              Console.WriteLine("Not a valid option.");
              Console.WriteLine("Would you like to play again? ");
              Console.WriteLine("\t[1] - Yes\n\t[2] - No");
              input = int.Parse(Console.ReadLine());
            }
            if(input == 1){
              return true;
            }
            else
            {
              return false;
            }
        }
    }
}
