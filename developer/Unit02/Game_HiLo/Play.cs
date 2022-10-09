using System;
using System.Collections.Generic;


namespace Unit02.Game_HiLo
{
    /// <summary> 
    ///
    /// The responsibility of Play is to control the sequence of the game.
    /// </summary>
    public class Play
    {
       
        bool _isPlaying = true;
        int _score = 300;
        int _totalScore = 0;

        Card first_card;
        Card next_card;

    
        public Play()
        {
            first_card = new Card();
            next_card = new Card();
        }


        public void DisplayFirstCard()
        {
            Console.WriteLine($"The card is:{first_card._value} ");
        }

        public void NextCard()
        {
            
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (_isPlaying)
            {
                DoUpdates();
                DoOutputs();
                GetInputs();
            }
        }
        /// <summary>
        /// Asks the user if they think the next card will be higher or lower.
        /// </summary>

        public void GetGuess()
        {
            Console.WriteLine("Higher or lower? [h/l]");
            string guess = Console.ReadLine();
            _score += next_card.Draw(guess, first_card._value, next_card._value);
        } 
        /// <summary>
        /// Asks the user if they want to play again.
        /// </summary>
        public void GetInputs()
        {
            Console.Write("Play again? [y/n] ");
            string playAgain = Console.ReadLine();
            _isPlaying = (playAgain == "y");
            
            if (_isPlaying == true)
            {
                first_card = new Card();
                next_card = new Card();
            }
            
        }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
        public void DoUpdates()
        {
            //get new card, compare to previous card,see if user's guess was correct, update score accordingly, set to be current card
            if (!_isPlaying)
            {
                return;
            }

            _score = 0;


            //Display the first card
            DisplayFirstCard();

            //get user's guess
            GetGuess();


      
            _totalScore += _score;
        }

        /// <summary>
        /// Shows value of next card and then gives score. 
        /// </summary>
        public void DoOutputs()
        {
            //display new card and how many points they got
            if (!_isPlaying)
            {
                return;
            }

            
    

            Console.WriteLine($"Next card was: {next_card._value}");
            Console.WriteLine($"Your score is: {_totalScore}\n");
            _isPlaying = (_score > 0); 
        }
    }
}