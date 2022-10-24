using System;


namespace Unit03.Game_Jumper;

    /// <summary>
    /// <para>The secret word generator.</para>
    /// <para>
    /// The responsibility of the Word Maker is to hold a list of strings to be used in random order.
    /// </para>
    /// </summary>

    public class WordMaker
    {
        
         public string PuzzleWord()
        {
            Random rnd = new Random();
            //Dictionary of strings
            string[] words = { "TALENT", "SWIMMING", "VACATION", "AUTUMN", "OVER", "SLUMBER" };
            
            
            //Create combination of word
            string randomString = $"{words[rnd.Next(0, words.Length)]}";

            return randomString;

        }

        



    }