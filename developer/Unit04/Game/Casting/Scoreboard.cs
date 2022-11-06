namespace Unit04.Game.Casting
{
    /// <summary>
    /// <para>A place to keep track of a player's score.</para>
    /// <para>
    /// The responsibility of a Scoreboard is to provide the player's score during a game.
    /// </para>
    /// </summary>
    public class Scoreboard : Actor
    {   
        private Point _scoreLocation = new Point(1, 585);
        private string _scorePrefix = "Score: ";
        private int _score = 0;



        /// <summary>
        /// Constructs a new instance of a Scoreboard.
        /// </summary>
        public Scoreboard()
        {
            SetPosition(_scoreLocation);
            DisplayScoreBoard();

        }



        public void UpdateScore(int _playerPoints)
        {
            _score += _playerPoints;
        }

        public int GetScore()
        {
            return _score;
        }

        public void DisplayScoreBoard()
        {
            SetText(_scorePrefix + _score.ToString());
        }

      





        /// <summary>
        /// Gets the artifact's message.
        /// </summary>
        /// <returns>The message.</returns>
        /* public string GetMessage()
        {
            return _message;
        } 

        /// <summary>
        /// Sets the artifact's message to the given value.
        /// </summary>
        /// <param name="message">The given message.</param>
        public void SetMessage(string message)
        {
            this._message = message;
        }*/
    }
}