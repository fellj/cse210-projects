using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{

    public class Player : Cycle
    {
        private int _playerXOffset;
        private Color _playerColor;

        private bool _gameOver = false;

        private Point _initialDirection = new Point(0, -Constants.CELL_SIZE);

        public Player(int playerXOffset)
        {
            // Set player color
            Random random = new Random();
            int _red = random.Next(50, 255);
            int _green = random.Next(50, 255);
            int _blue = random.Next(50, 255);

            Color playerColor = new Color(_red, _green, _blue);
            _playerColor = playerColor;

            // Set player location            
            _playerXOffset = playerXOffset;

            
            SetPlayerPosition();
            
            // Set player color
            SetPlayerColor();


        }

        /// <summary>
        ///
        /// </summary>
        public override Actor GetCycle()
        {
            return this.GetSegments()[0];
        }

        
        /// <summary>
        /// Set player position
        /// </summary>
        public void SetPlayerPosition()
        {
            List<Actor> segments = this.GetSegments();
            for (int i = 0; i < segments.Count; i++)
            {
                Actor segment = segments[i];
                Point segmentLocation = new Point(((Constants.MAX_X / 2 ) + _playerXOffset) - i, (Constants.MAX_Y / 2));

                segment.SetPosition(segmentLocation);
            
            }



        }

        public override void GrowTail(int numTailSegments)
        {
            List<Actor> segments = this.GetSegments();
            //Color tailColor = PlayerGameOver() == false ? _playerColor : Constants.WHITE;


            for (int i = 0; i < numTailSegments; i++)
            {
                Actor tail = segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                if (PlayerGameOver())
                {
                    segment.SetColor(Constants.WHITE);

                } else {

                    segment.SetColor(_playerColor);
                }
                
                segments.Add(segment);
            }

            

        }

        /// <summary>
        /// Sets the cycle and initial tail color
        /// </summary>
        public void SetPlayerColor()
        {
            List<Actor> segments = this.GetSegments();
            Actor cycle          = this.GetCycle();

            cycle.SetColor(_playerColor);

            for (int i = 0; i < segments.Count; i++)
            {

                Actor segment = segments[i];
                segment.SetColor(_playerColor);

            }

        }

        /// <summary>
        /// Sets the color of the cycle and tail to white
        /// </summary>
        public void SetPlayerColorWhite()
        {
            List<Actor> segments = this.GetTail();
            Actor cycle = this.GetCycle();

            cycle.SetColor(Constants.WHITE);

            for (int i = 0; i < segments.Count; i++)
            {

                Actor segment = segments[i];
                segment.SetColor(Constants.WHITE);

            }

        }

        public bool PlayerGameOver()
        {
            _gameOver = true;

            return _gameOver;
        }

        public override void MoveNext()
        {
            GrowTail(1);

            List<Actor> segments = this.GetSegments();

            foreach (Actor segment in segments)
            {
                segment.MoveNext();
            }

            

            for (int i = segments.Count - 1; i > 0; i--)
            {
                Actor trailing = segments[i];
                Actor previous = segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }

        }
                


    }

}