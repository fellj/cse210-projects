using System;
using System.Collections.Generic;


namespace Unit03.Game_Jumper
{
    /// <summary>
    /// <para>Handles letters guessed.</para>
    /// <para>
    /// The responsibility of Guess is to evaluate inputted letters, hold guesses, and 
    /// replace underscores with correct guesses.
    /// </para>
    /// </summary>
    public class Guess
    {
        public List<string> _correctGuesses; 
        private string _secretWord;
        private string _underscore = "_";
        public string letterGuess;
        public int totalGuesses = 0;
        public int totalIncorrectGuesses = 0;
        public int totalCorrectGuesses = 0;

        public Guess(string theWord)
        {
            _correctGuesses = new List<string>(new string[theWord.Length]);
            _secretWord = theWord;
            AddUnderscores();
        }

        public bool EvaluateLetters(string theLetter)
        {
            bool result = false;
            

                foreach (char letter in _secretWord)
                {
                    if (Char.Parse(theLetter) == letter)
                    {
                        // Assigns the letter to the correct spot
                        _correctGuesses[_secretWord.IndexOf(theLetter)] = theLetter; 
                        totalCorrectGuesses += 1;
                        result = true;
                    }
                    else
                    {
                        //_correctGuesses[totalGuesses] = _underscore; 
                        totalIncorrectGuesses += 1;
                    }
                    totalGuesses += 1;
                }
                return result;

        }
        public void AddUnderscores()
        {
            for (int i = 0; i < _correctGuesses.Count; i++)
            {
                _correctGuesses[i] = _underscore;
            }
        }

    }





}