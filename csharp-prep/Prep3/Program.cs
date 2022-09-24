using System;

namespace Prep3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 3");
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1,100);
            


            //ask user for the magic number
            //Console.Write("What is the magic number? ");
            //string userNumber = Console.ReadLine();
            int magicNumber = number;
            int userTry;
            //add loop the keep looping as long as the guess does not match the magic number
    
            do
            {

                //ask the user to guess
                Console.Write("What is your guess? ");
                string userGuess = Console.ReadLine();
                userTry = int.Parse(userGuess);

                //If statement to deterine if the user needs to guess higher or lower
                if (magicNumber < userTry)
                {
                    Console.WriteLine("Lower");
                }
                else if (magicNumber > userTry)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            } while (magicNumber!= userTry);
                


        }
    }
}
