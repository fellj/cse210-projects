using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{

    public class Player : Cycle
    {
        private int _playerXOffset;
        private int _playerYOffset;
        


        public Player(int playerXOffset, int playerYOffset)
        {
            Random random = new Random();
            int _red = random.Next(0, 255);
            int _green = random.Next(0, 255);
            int _blue = random.Next(0, 255);

            Color playerColor = new Color(_red, _green, _blue);
            this.SetColor(playerColor);

            _playerXOffset = playerXOffset;
            _playerYOffset = playerYOffset;

        }

    }

}