using System;
using System.Linq;

class MainClass
{
    public static void Main(string[] args)
    {

        Console.WriteLine("HängaGubbe");

        Console.WriteLine("Skriv in ditt ord: ");
        string secretWord = Console.ReadLine();
        secretWord = secretWord.ToUpper();
        Console.Clear();

        //Variabler som kommer användas inom koden.
        //Skriver bl.a. ut liv, hur mycket liv man kan tappa, hur många bokstäver som kan vara med.
       
        int lives = 7;
        int livesLost = -1;
        int wordLength = secretWord.Length;
        char[] nolookArray = secretWord.ToCharArray();
        char[] misterArray = new char[wordLength];
        char[] guessedLetters = new char[29];
        int holdNum = 0;
        bool victory = false;

        //Liv systemet samt skyddar orden
        foreach (char letter in misterArray)
        {
            livesLost++;
            misterArray[livesLost] = '+';
        }
        while (lives > 0) //System för koden så man kan se hur många liv man har kvar. Uppdaterar den mer påvägen
        {
            livesLost = -1;
            string printProgress = String.Concat(misterArray);
            bool letterFound = false;
            int multiples = 0;

            if (printProgress == secretWord)
            {
                victory = true;
                break;
            }

            if (lives > 1)
            {
                Console.WriteLine("Du har " + lives +" liv!");
            }
            Console.WriteLine(printProgress); //Här kan spelaren börja med ny bokstav ifall man gissat rätt/fel.
            
            Console.Write("Skriv en bokstav... ");
            string playerGuess = Console.ReadLine();

            playerGuess = playerGuess.ToUpper();
            char playerChar = Convert.ToChar(playerGuess);

            if (guessedLetters.Contains(playerChar) == false)
            {

                guessedLetters[holdNum] = playerChar;
                holdNum++;

                foreach (char letter in nolookArray)
                {
                    livesLost++;
                    if (letter == playerChar)
                    {
                        misterArray[livesLost] = playerChar;
                        letterFound = true;
                        multiples++;
                    }
                }
                if (letterFound)
                {
                    Console.WriteLine(multiples + playerChar);
                }
                else
                {
                    Console.WriteLine(playerChar);
                    lives--;
                }
                Console.WriteLine(lives);
            }
            else
            {
                Console.WriteLine("Du har redan gissat " + playerChar);
            }


        }
        if (victory)
        {
            Console.WriteLine("Ordet var:" + secretWord);
            Console.WriteLine("Du vann! Gr8 success!");
        }
        else
        {
            Console.WriteLine("Ordet var:" + secretWord);
            Console.WriteLine("Du förlorade. Dåligt försök");
        }

    }

}