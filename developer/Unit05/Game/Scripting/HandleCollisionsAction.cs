using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool _isGameOver = false;
        private string _winner;


        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (_isGameOver == false)
            {
                HandleCycleCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Ends the game if the cycles collide.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleCycleCollisions(Cast cast)
        {
            Player player1    = (Player)cast.GetFirstActor("player1");
            Player player2    = (Player)cast.GetFirstActor("player2");
            Actor cycle1      = player1.GetCycle();
            Actor cycle2      = player2.GetCycle();
            List<Actor> tail1 = player1.GetTail();
            List<Actor> tail2 = player2.GetTail();

            _winner = IdentifyTailCollision("player 2", cycle2, tail1);
            _winner = IdentifyTailCollision("player 1", cycle1, tail2);

        }

        /// <summary>
        /// Identifies if the cycle has collided with the opponents tail.
        /// If so, the game is over
        /// <param name="player"> String representing the player. </param>
        /// <param name="cycle"> Cycle object representing the cycle. </param>
        /// <param name="tail"> List<Actor> object representing the opponent's tail. </param>
        /// </summary>
        private string IdentifyTailCollision(string player, Actor cycle, List<Actor> tail)
        {
            foreach (Actor segment in tail)
            {
                if (segment.GetPosition().Equals(cycle.GetPosition()))
                {
                    _isGameOver = true;
                    _winner = player.Contains("1") == true ? "Player 2" : "Player 1"; 
                }
            }

            return _winner;
        }


        /// <summary>
        /// If the game is over, it communicates
        /// with messages to the players and 
        /// makes everything white
        /// <param name="cast"> The cast object. </param>
        /// </summary>
        private void HandleGameOver(Cast cast)
        {
            if (_isGameOver == true)
            {

                // create a "game over" message
                int x = Constants.MAX_X / 2 - 50;
                int y = Constants.MAX_Y / 2 - 50;
                Point messagePosition = new Point(x, y);
                Point winnerPosition = new Point(x, y + 25);

                Actor message = new Actor();
                Actor winner = new Actor ();
                message.SetText("Game Over!");
                message.SetPosition(messagePosition);
                winner.SetText("The winner is: " + GetWinner());
                winner.SetPosition(winnerPosition);
                cast.AddActor("messages", message);
                cast.AddActor("messages", winner);

                // Make everything white
                MakeEverythingWhite(cast);

            }
        }

        /// <summary>
        /// Sets the color of the actors white
        /// </summary>
        /// <param name="cast"> The cast of actors. </param>
        private void MakeEverythingWhite(Cast cast)
        {
            Player player1 = (Player)cast.GetFirstActor("player1");
            Player player2 = (Player)cast.GetFirstActor("player2");
            
            player1.PlayerGameOver();
            player2.PlayerGameOver();

            player1.SetPlayerColorWhite();
            player2.SetPlayerColorWhite();

        }

        private string GetWinner()
        {
            return _winner;
        }        



    }

   
}