using System;


namespace Unit02.Game_HiLo
{
    /// <summary>
    /// 
    /// The responsibility of Card is to keep track of its currently drawn value and the points it's
    /// worth.
    /// </summary> 
    public class Card
    {
        public int _value = 0;
        public int _points = 0;

        /// <summary>
        /// Constructs a new instance of Card. Generates a new random value and calculates the points.
        /// </summary>
        public Card()
        {
            Random random = new Random();
            _value = random.Next(1, 13);
        }


        public int Draw(string guessValue, int first_cardValue, int next_cardValue)
        {            
            if (guessValue == "h" && first_cardValue < next_cardValue)
            {
                _points += 100;
            }
            else if (guessValue == "l" && first_cardValue > next_cardValue) 
            {
                _points += 100;
            }
            else
            {
                _points -= 75;
            }

        return _points;    
        }


    }
}