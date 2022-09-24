using System;

namespace Prep2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 2");

            Console.Write("What is your grade? ");


            string userGrade = Console.ReadLine();

            //change user input to int variable named "average"
            int average = int.Parse(userGrade);
            string letter;

            if (average >= 90)
            {
                //Console.WriteLine("You've earned an A!");
                letter = "A";
            }

            else if (average < 90 && average > 79)
            {
                 //Console.WriteLine("You've earned a B!");
                letter = "B";
            }

            else if (average < 80 && average > 69)
            {
                //Console.WriteLine("You earned a C.");
                letter = "C";
            }

            else if (average < 70 && average > 59)
            {
                //Console.WriteLine("You earned a D.");
                letter = "D";
            }

            else
            {
                //Console.WriteLine("You earned an F.");
                letter = "F";
            }
            //Add single print statement that prints the letter grade once.
            Console.WriteLine($"You earned a/n {letter}.");
                //Add pass/fail statement
            if (average >= 70)
            {
                Console.WriteLine("Congratuations! You passed the class!");
            }
                
            else
            {
              Console.WriteLine("Sorry, you did not pass this class.  Please try again!");
            }



        }
    }
}
