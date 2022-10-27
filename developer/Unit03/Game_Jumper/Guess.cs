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
            char inputLetter = Char.Parse(theLetter);
            int letterIndex = 0;
            

                foreach (char letter in _secretWord)
                {

                    if (inputLetter == Char.ToLower(letter) || inputLetter == Char.ToUpper(letter))
                    {
                        // Assigns the letter to the correct spot
                        
                        if (_correctGuesses[letterIndex] == _underscore)
                        {
                            _correctGuesses[letterIndex] = letter.ToString();
                            totalCorrectGuesses += 1;
                            result = true;
                        }

                    }

                    // Increment the letter index
                    letterIndex++;

                }

                // If result is false, then increment totalIncorrectGuesses
                if (!result) totalIncorrectGuesses++;

                totalGuesses += 1;
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