//Author: Lisa Fell
//Project: Tic Tac Toe - Unit 01

using System;
using System.Collections.Generic;

namespace Unit01
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayGreeting();
            //List<string> board = GetNewBoard();
            
            //This is the tic tac toe board with starting numbers.
            List<string> board = new List<string>(){"1","2", "3", "4", "5", "6", "7", "8", "9"};
           
            DisplayBoard(board);
        }

        //static void GetNewBoard();
        static void DisplayBoard(List<string> board)
        {
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            
        }




        static void DisplayGreeting()
        {
            Console.WriteLine("Welcome to the Tic Tac Toe Game!");
        }

        
    }
}
