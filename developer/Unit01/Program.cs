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
            List<string> board = GetNewBoard();
            string currentPlayer = "x";
            

            while (!IsGameOver(board))
            {
                DisplayBoard(board);
                int squareChoice = GetUserChoice(currentPlayer);
                MakeMove(board, currentPlayer, squareChoice);

                

                currentPlayer = GetNextPlayer(currentPlayer);
                //squareChoice = GetUserChoice(currentPlayer);
                //MakeMove(board, currentPlayer, squareChoice);
            }
                DisplayBoard(board);
                Console.WriteLine("Great game!  See you next time!");
        }

        static int GetUserChoice(string currentPlayer)
        {
            Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");

            int squareChoice = int.Parse(Console.ReadLine());
            return squareChoice;
        }

        static void MakeMove(List<string>board, string currentPlayer, int squareChoice)
        {
            int boardIndex = squareChoice - 1;

            board[boardIndex] = currentPlayer;
        }
        static List<string> GetNewBoard()
        {
            //This is the tic tac toe board with starting numbers.
            List<string> board = new List<string>(){"1","2", "3", "4", "5", "6", "7", "8", "9"};

            return board;
        }
        static void DisplayBoard(List<string> board)
        {
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine($"---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            
        }
        static string GetNextPlayer(string currPlayer)
        {
            string nextPlayer = "x";

            if (currPlayer == "x")
            {
                nextPlayer = "o";
            }
            return nextPlayer;
        }

        static void DisplayGreeting()
        {
            Console.WriteLine("Welcome to the Tic Tac Toe Game!");
        }

        static bool IsGameOver(List<string>board)
        {
            bool IsGameOver = false;

            if (IsWinner(board, "x") || IsWinner(board, "o") || Draw(board))
            {
                IsGameOver = true;
            }
            return IsGameOver;
        }
        
        static bool IsWinner(List<string>board, string player)
        {
            bool IsWinner = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[7] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                IsWinner = true;
            }
            return IsWinner;
        } 

        static bool Draw(List<string>board)
        {
            bool foundDigit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return !foundDigit;
        }
                
    }




        
}
