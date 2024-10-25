using System;
using System.Collections.Generic;
using System.IO;

namespace hangman
{
    internal class utils
    {
        // Method to collect the whole words from at text file. notice that you have to change the filesti with your own ords for it to work that the fil is saved on my local computer
        //the method also chose a random ord from the text file 
        static public string ord()
        {
            string filSti = @"C:\Users\Sebastian Nielsen\Desktop\skole\texthangman.txt";
            string filIndhold = File.ReadAllText(filSti);
            string[] ord = filIndhold.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            Random random = new Random();
            int randomIndex = random.Next(ord.Length);
            string randomOrd = ord[randomIndex].ToLower();
            return randomOrd;
        }
        // method to show if the whole ord is guessed correct
        static public void fuldtordguess(string randomOrd)
        {
            Console.WriteLine("You guessed it! " + randomOrd);
        }
        // method to check for letters in the secret ord, and if the letter is correct it will replace the _ with the correct letter you guessed.
        static public bool lettercheck(string randomOrd, List<char> korrekteBogstaver)
        {
            bool fuldtOrdGættet = true;
            foreach (char c in randomOrd)
            {
                if (korrekteBogstaver.Contains(c))
                {
                    Console.Write(c + " ");
                }
                else
                {
                    Console.Write("_ ");
                    fuldtOrdGættet = false;
                }
            }
            Console.WriteLine();
            return fuldtOrdGættet;
        }
       //the main method for the game, i will normaly put this in the main, but to make more methods i chose to just make it a method you can call in yout main
        static public void text()
        {
            string randomOrd = ord(); //here it gets the rendom word from the method
            // here we uses the list so we have alle the lettters that the user should guess
            // here we uses list and hashset we use hash set to save unik inputs and to check if the letter is allready used so we dont get dublicates  
            int maxForsøg = 5; 
            int brugteForsøg = 0;
            List<char> korrekteBogstaver = new List<char>();
            HashSet<char> gættedeBogstaver = new HashSet<char>();
            Console.WriteLine("Lets play hangman guess a letter or the whole ord :):");
            // here we use a while loop so that we can play the game and guess wrong or right and wil just keep going until you guess the word ore until fail the attempts
            while (brugteForsøg < maxForsøg)
            {
                // checks if the whole ord is guessed 
                bool fuldtOrdGættet = lettercheck(randomOrd, korrekteBogstaver);
                if (fuldtOrdGættet)
                {
                    fuldtordguess(randomOrd);
                    return;
                }
                Console.Write("Guess a letter or the whole ord: ");
                string gæt = Console.ReadLine().ToLower();
                if (gæt.Length == 1)
                {
                    //here the user guess one letter at a time 
                    char gætBogstav = gæt[0];

                    if (gættedeBogstaver.Contains(gætBogstav))
                    {
                        Console.WriteLine("you already gussed that, try again.");
                    }
                    else
                    {
                        gættedeBogstaver.Add(gætBogstav);

                        if (randomOrd.Contains(gætBogstav))
                        {
                            Console.WriteLine("correct guess");
                            korrekteBogstaver.Add(gætBogstav);
                        }
                        else
                        {
                            brugteForsøg++;
                            Console.WriteLine("wrong guess. you now have " + (maxForsøg - brugteForsøg) + " try's left.");
                        }
                    }
                }
                else
                {
                    // here it checks if you guess the whole ord if you guess the whole word it breaks. but if you guess wrong but still have try's left it will show ho many try's left
                    if (gæt == randomOrd)
                    {
                        Console.WriteLine("you guessed the whole left. Nice!: " + randomOrd);
                        return;
                    }
                    else
                    {
                        brugteForsøg++;
                        Console.WriteLine("wrong guss on the word, you now have" + (maxForsøg - brugteForsøg) + " try's left.");
                    }
                }
                Console.WriteLine();
            }

            // you get this console.writeline if you uses all the try's and the while loop breaks
            Console.WriteLine("you used all your try's! the word was: " + randomOrd);
        }
    }
}