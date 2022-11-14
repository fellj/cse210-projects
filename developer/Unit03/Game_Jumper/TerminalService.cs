using System;
using System.Collections.Generic;


namespace Unit03.Game_Jumper
{
    /// <summary>
    /// <para>A service that handles terminal operations.</para>
    /// <para>
    /// The responsibility of a TerminalService is to provide input and output operations for the 
    /// terminal.
    /// </para>
    /// </summary>
    public class TerminalService
    {
        public List<string> _parachute = new List<string>(){"___","/___\\", "\\   /", "\\ /", "0"};
        public int _lenWord;
        public string _privateWord;
        public List<string> _rightGuesses;
        


        /// <summary>
        /// Constructs a new instance of TerminalService.
        /// </summary>
        public TerminalService(string myWord)
        {
            _lenWord = myWord.Length;
            _privateWord = myWord;
        }

        /// <summary>
        /// Gets string input from the terminal. Directs the user with the given prompt.
        /// </summary>
        /// <param name="prompt">The given prompt.</param>
        /// <returns>Inputted string character.</returns>
        public string ReadLetter(string prompt)
        {
            string rawValue = ReadText(prompt);
            return rawValue;
        }

        /// <summary>
        /// Gets text input from the terminal. Directs the user with the given prompt.
        /// </summary>
        /// <param name="prompt">The given prompt.</param>
        /// <returns>Inputted text.</returns>
        public string ReadText(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        /// <summary>
        /// Displays the given text on the terminal. 
        /// </summary>
        /// <param name="text">The given text.</param>
        public void WriteText(string text)
        {
            Console.WriteLine(text);
        }

        public void DisplayBoard(List<string> _rightGuesses)
        {
            DisplaySecretWord(_rightGuesses);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"  {_parachute[0]}");
            Console.WriteLine($" {_parachute[1]}");
            Console.WriteLine($" {_parachute[2]}");
            Console.WriteLine($"  {_parachute[3]}");
            Console.WriteLine($"   {_parachute[4]}");
            Console.WriteLine("  /|\\");
            Console.WriteLine("  / \\");
            Console.WriteLine("");
            Console.WriteLine($"^^^^^^^");
            
        }

        public void DisplaySecretWord(List<string> _secretWordItems)
        {
            string secretWordString = String.Join(" ", _secretWordItems.ToArray());
            Console.WriteLine(secretWordString);
        }


        public void DisplaySecretWord(List<string> _secretWordItems){

        string secretWordString = String.Join(" ", _secretWordItems.ToArray());
        Console.WriteLine(secretWordString);

        }
        public void RemovePart(int incorrectGuessNumber)
        {
            if (incorrectGuessNumber < 5)
            {
                _parachute[incorrectGuessNumber - 1] = String.Empty;

            }
            else if (incorrectGuessNumber == 5)
            {
                _parachute[incorrectGuessNumber - 1] = "x";
                
            }
        }
        
    }
}