namespace Unit03.Game_Jumper
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private WordMaker _wordObj = new WordMaker();
        private string _word;
        private bool _isPlaying = true;
        private Guess _guess;
        private TerminalService _terminalService;
        private int _turns = 4;
        private bool _isCorrect;
        



        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            _word = _wordObj.PuzzleWord();
            _terminalService = new TerminalService(_word);
            _guess = new Guess(_word);
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            CurrentTerminalService.DisplayBoard(_guess._correctGuesses);
            while (_isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Gathers input from user to guess letters to form a word.
        /// </summary>
         private void GetInputs()
        {
            _guess.letterGuess = _terminalService.ReadLetter("\nGuess a letter [a-z]: ");
            _isCorrect = _guess.EvaluateLetters(_guess.letterGuess);
        }
 
        /// <summary>
        /// keeps track of number of incorrect guesses. removes parachute parts.
        /// </summary>
        private void DoUpdates()
        {
            if (_isCorrect == false)
            {
                
                CurrentTerminalService.RemovePart(_guess.totalIncorrectGuesses);

            }
                
                
        }

        /// <summary>
        /// Displays board with correct guesses.
        /// </summary>
        private void DoOutputs()
        {
            
            CurrentTerminalService.DisplayBoard(_guess._correctGuesses); 

            if (_guess.totalIncorrectGuesses == 5 || _guess.totalCorrectGuesses == CurrentTerminalService._lenWord)
            {
                _isPlaying = false;
            }
           
        }

        public TerminalService CurrentTerminalService 
        {
            get { return _terminalService;}
            set {_terminalService = value; }

        }
    }
}