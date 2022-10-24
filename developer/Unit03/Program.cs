using System;
using Unit03.Game_Jumper;

namespace Unit03
{
    // The programs entry point. //
    class Program
    {
        // Starts the program. // 
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Jumper Game!");
            Director director = new Director();
            director.StartGame();
        }
    }
}






