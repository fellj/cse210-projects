using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int _points = 0;
        private int _playerOffset = 0;
        private string _prefix = "";


        /// <summary>
        /// Constructs a new instance of a Score.
        /// </summary>
        public Score(int playerOffset, string prefix)
        {
            _prefix = prefix;
            AddPoints(0);
            _playerOffset = playerOffset;
            SetLocation();
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this._points += points;
            SetText($"{this._prefix} Score: {this._points}");
        }

        /// <summary>
        /// Sets the location of the score text.
        /// </summary>
        /// <param name="offset">An integer value representing the x offset of the current location.
        public void SetLocation()
        {

            this.GetPosition().AddXOffset(_playerOffset);


        }
    }
}