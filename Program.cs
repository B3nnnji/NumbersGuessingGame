using System;
using System.IO;

namespace NumbersGuessingGame;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("!!!WYBIERZ POZIOM TRUDNOŚCI!!!");
        Console.WriteLine();
        Console.WriteLine("1. Łatwy (1 - 100)");
        Console.WriteLine();
        Console.WriteLine("2. Normalny (1 - 10,000)");
        Console.WriteLine();
        Console.WriteLine("3. Trudny (1 - 1,000,000)");
        Console.WriteLine();

        int difficulty = Convert.ToInt32(Console.ReadLine());
        int minRange = 1;
        int maxRange = 100;

        switch (difficulty)
        {
            case 1:
                maxRange = 100;
                Console.WriteLine();
                Console.WriteLine("WYBRANY POZIOM TRUDNOŚCI: ŁATWY");
                Console.WriteLine();
                break;
            case 2:
                maxRange = 10000;
                Console.WriteLine();
                Console.WriteLine("WYBRANY POZIOM TRUDNOŚCI: NORMALNY");
                Console.WriteLine();
                break;
            case 3:
                maxRange = 1000000;
                Console.WriteLine();
                Console.WriteLine("WYBRANY POZIOM TRUDNOŚCI: TRUDNY");
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Niepoprawny wybór poziomu trudności. Ustawiam poziom łatwy.");
                maxRange = 100;
                break;
        }

        Console.WriteLine("!!!WYBIERZ TRYB GRY!!!");
        Console.WriteLine();
        Console.WriteLine("1. Ty zgadujesz.");
        Console.WriteLine();
        Console.WriteLine("2. Program zgaduje. Pamiętaj aby jako nazwę gracza wpisać słowo \"program\",");
        Console.WriteLine("w przeciwnym razie zapis danych będzie nieprawidłowy!!!");
        Console.WriteLine();
        Console.WriteLine("3. Zgadywanie odbywa się na zmianę.");
        Console.WriteLine();

        int input = Convert.ToInt32(Console.ReadLine());
        switch (input)
        {
            case 1:
                Console.WriteLine();
                Console.WriteLine("WYBRANY TRYB GRY: 1");
                Console.WriteLine();
                Player player1 = new Player();
                player1.CreatePlayer();
                Game game = new Game(player1, minRange, maxRange);
                game.StartGame();
                break;
            case 2:
                Console.WriteLine();
                Console.WriteLine("WYBRANY TRYB GRY: 2");
                Console.WriteLine();
                Player player2 = new Player();
                player2.CreatePlayer();
                GameVsBot bot = new GameVsBot(player2);
                bot.StartGameVsBot();
                break;
            case 3:
                Console.WriteLine();
                Console.WriteLine("WYBRANY TRYB GRY: 3");
                Console.WriteLine();
                Player player3 = new Player();
                player3.CreatePlayer();
                MixedGame mixedGame = new MixedGame(player3, minRange, maxRange);
                mixedGame.StartMixedGame();
                break;
            default:
                Console.WriteLine("Niepoprawny wybór trybu gry. Ustawiam tryb numer jeden!");
                break;
        }
    }
}

