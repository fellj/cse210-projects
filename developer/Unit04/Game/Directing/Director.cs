using System;
using System.Collections.Generic;
using Unit04.Game.Casting;
using Unit04.Game.Services;


namespace Unit04.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService _keyboardService = null;
        private VideoService _videoService = null;
        private int _score = 0; 
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        
        
        private static int DEFAULT_ARTIFACTS = 20;
        private static int TOTAL_GEMS = (DEFAULT_ARTIFACTS * 1/2);
        private static int TOTAL_STONES = (DEFAULT_ARTIFACTS * 1/2);

        private static string GEM = "gem";
        private static string STONE = "stone";




        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this._keyboardService = keyboardService;
            this._videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            _videoService.OpenWindow();
            while (_videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            _videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the player.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor player = cast.GetFirstActor("player");
            Point velocity = _keyboardService.GetDirection();
            player.SetVelocity(velocity);     

        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Actor sBoard = cast.GetFirstActor("sBoard");
            Actor player = cast.GetFirstActor("player");
            List<Actor> artifacts = cast.GetActors("artifacts");


            if (artifacts.Count < 18)
            {
                AddMoreArtifacts(GEM, TOTAL_GEMS, cast);
                AddMoreArtifacts(STONE, TOTAL_STONES, cast);

            }

            
            int maxX = _videoService.GetWidth();
            int maxY = _videoService.GetHeight();

            // Help player to move
            player.MoveNext(maxX, maxY);

            // Help actors move
            foreach (Actor actor in artifacts)
            {
                actor.MoveNextNoWrap();

                if (actor.GetPosition().GetX() > maxX || actor.GetPosition().GetY() > maxY)
                {

                    
                    cast.RemoveActor("artifacts", actor);
                }
            }
            

            foreach (Actor actor in artifacts)
            {
                
                if (player.GetPosition().Equals(actor.GetPosition()))
                {

                    Artifact artifact = (Artifact) actor;
                    if (artifact.GetArtifactType() == "gem")
                        {
                            _score += 1;
                        }
                    else
                    {
                            _score -= 1;
                    }
                    actor.SetText("");
                    
                    //_videoService.ClearBuffer();
                    //_videoService.FlushBuffer();
                    
               
                    
                    sBoard.SetText("Score: " + _score.ToString());
                }
            } 
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            _videoService.ClearBuffer();
            _videoService.DrawActors(actors);
            _videoService.FlushBuffer();
        }

 public static void AddMoreArtifacts(string artifactType, int totalArtifacts, Cast cast)
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
                
                int d = random.Next(0, 0);
                int m = random.Next(1, sm); // speed modifier
                int s = random.Next(1, 2 * m);

                Point _velocity = new Point(d, s);
                artifact.SetVelocity(_velocity);

                //artifact.SetMessage(message);
                cast.AddActor("artifacts", artifact);
            }


        }

    }
}