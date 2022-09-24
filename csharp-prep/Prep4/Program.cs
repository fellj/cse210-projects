using System;
using System.Collections.Generic;
using System.Linq;

namespace Prep4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Prep 4");

            List<int> numbers = new List<int>();
            int number = -1;

            //Ask user for a series of numbers, and add each one to a list.  Stop whent they enter 0.
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            while (number != 0)
            {
                Console.Write("Enter number: "); 
                string userInput = Console.ReadLine();
                number = int.Parse(userInput);
                

                if (number != 0)
                {
                    numbers.Add(number);
                }

            }
            

        
            //find sum of numbers in list
            int total = numbers.Sum();
            Console.WriteLine($"The sum is: {total}");

            //find average of numbers in list
            double average = numbers.Average();
            Console.WriteLine($"The average is: {average}");

            //find the largest number
            int largest = numbers.Max();
            Console.WriteLine($"The largest number is: {largest}");


            
            
        }
    }
}
