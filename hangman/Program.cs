namespace hangman
{
    internal class Program
    {

        //this is the main, here we just call utils, and utils run the game, you could put the whole code here. but now you can make a lot of small games and call them from the main and make a platform for small games in diffrent fils and call them here with switch ore something 
        static void Main(string[] args)

        {
            Console.WriteLine("press 1 for hangman");
            switch (Console.ReadKey().KeyChar)
            {
                
                case '1':
                    utils.text();
                    Console.ReadLine();
                    break;
            }

         }
    }
}
