using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit04.Game.Casting;
using Unit04.Game.Directing;
using Unit04.Game.Services;




namespace Unit04
{
    //This is the program's entry point.
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Greed";
        private static Color BLACK = new Color(0, 0, 0);
        private static int DEFAULT_ARTIFACTS = 20;
        private static int TOTAL_GEMS = (DEFAULT_ARTIFACTS * 1/2);
        private static int TOTAL_STONES = (DEFAULT_ARTIFACTS * 1/2);

        private static string GEM = "gem";
        private static string STONE = "stone";
        



        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the scoreboard
            Actor sBoard  = new Actor();
            sBoard.SetText("Score: 0");
            sBoard.SetFontSize(FONT_SIZE);
            sBoard.SetColor(new Color(255, 255, 255));
            sBoard.SetPosition(new Point(MAX_X / COLS, MAX_Y * (3/4)));
            cast.AddActor("sBoard", sBoard);

            // create the player
            Actor player = new Actor();
            player.SetText("#");
            player.SetFontSize(FONT_SIZE);
            player.SetColor(new Color(255,255,255));
            player.SetPosition(new Point(MAX_X / 2, MAX_Y - 50));
            cast.AddActor("player", player);

            

            AddArtifacts(GEM, TOTAL_GEMS, cast);
            AddArtifacts(STONE, TOTAL_STONES, cast);


             // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);


                
            
        }

         public static void AddArtifacts(string artifactType, int totalArtifacts, Cast cast)
        {
           // create the artifacts
            Random random = new Random();
            
            char stone = 'O';
            char gem   = '*';
            string inputArtifact = "";
            int sm     = 0; // speed modifier


            if (artifactType == "gem")
            {

                sm = 7;
                inputArtifact = gem.ToString();
            }

            else
            {
                sm = 5;
                inputArtifact = stone.ToString();
            }

            for (int i = 0; i < totalArtifacts; i++)
            {

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText(inputArtifact);
                artifact.SetFontSize(FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                artifact.SetArtifactType(artifactType);
                
                int d = random.Next(0, 1);
                int m = random.Next(1, sm); // speed modifier
                int s = random.Next(1, 5 * m);

                Point _velocity = new Point(d, s);
                artifact.SetVelocity(_velocity);

                //artifact.SetMessage(message);
                cast.AddActor("artifacts", artifact);
            }


        }
 

    }
}
