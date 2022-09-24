using System;
using System.Collections.Generic;

namespace Prep5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 5");
            DisplayWelcome();
            string name = PromptUserName();
            int number = PromptUserNumber();
            int numSquare = SquareNumber(number);
            DisplayResult(name, numSquare);

        }

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            return userName;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int favNumber = int.Parse(Console.ReadLine());
            return favNumber;
        }

        static int SquareNumber (int favNumber)
        {
            int square = favNumber * favNumber;
            return square; 
        }

        static void DisplayResult(string userName, int square)
        {
            Console.WriteLine($"{userName}, the square of your number is {square}");
        }
    }
}
