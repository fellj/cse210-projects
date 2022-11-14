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
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleCycleCollisions(Cast cast)
        {
            Cycle player1 = (Cycle)cast.GetFirstActor("player1");
            Cycle player2 = (Cycle)cast.GetFirstActor("player2");
            Score score = (Score)cast.GetFirstActor("score");
            //Food food = (Food)cast.GetFirstActor("food");
            
            if (player1.GetCycle().GetPosition().Equals(player2.GetCycle().GetPosition()))
            {
                int points = food.GetPoints();
                snake.GrowTail(points);
                score.AddPoints(points);
                food.Reset();
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Cycle player1 = (Cycle)cast.GetFirstActor("player1");
            Cycle player2 = (Cycle)cast.GetFirstActor("player2");
            Actor cycle1 = player1.GetCycle();
            Actor cycle2 = player2.GetCycle();
            List<Actor> cycle1Tail = cycle1.GetTail();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    _isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (_isGameOver == true)
            {
                Cycle player1 = (Cycle)cast.GetFirstActor("player1");
                Cycle player2 = (Cycle)cast.GetFirstActor("player2");
                List<Actor> player1Tail = player1.GetTail();
                List<Actor> player2Tail = player2.GetTail();
                //Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in player1Tail)
                {
                    segment.SetColor(Constants.WHITE);
                }
                //food.SetColor(Constants.WHITE);
            }
        }

    }
}