using System;

using Unit02.Game_HiLo;

namespace Unit02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the HiLo Game!");

            Play myPlay = new Play();
            myPlay.StartGame();


        }
    }
}
