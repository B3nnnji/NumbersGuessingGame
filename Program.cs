using System;

namespace NumbersGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepPlaying = true;

            while (keepPlaying)
            {
                int minRange, maxRange;
                SelectDifficulty(out minRange, out maxRange);
                SelectGameMode(minRange, maxRange);

                Console.WriteLine("Naciśnij 1 jeśli chcesz wrócić do menu głownego");
                Console.WriteLine();
                Console.WriteLine("Naciśnij 2 jeśli chcesz wyjść z gry");
                Console.WriteLine();
                string choice = Console.ReadLine() ?? string.Empty;
                choice = choice.ToUpper();

                if (choice == "2")
                {
                    keepPlaying = false;
                }
            }

            Console.WriteLine("!!!DZIĘKUJĘ ZA GRĘ!!!");
        }

        static void SelectDifficulty(out int minRange, out int maxRange)
        {
            Console.WriteLine("!!!WYBIERZ POZIOM TRUDNOŚCI!!!");
            Console.WriteLine();
            Console.WriteLine("1. Łatwy (1 - 100)");
            Console.WriteLine();
            Console.WriteLine("2. Normalny (1 - 10,000)");
            Console.WriteLine();
            Console.WriteLine("3. Trudny (1 - 1,000,000)");
            Console.WriteLine();
            Console.WriteLine("4. Niestandardowy (Twój zakres liczb)");

            int difficulty = Convert.ToInt32(Console.ReadLine());
            minRange = 1;

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
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("WYBRANY POZIOM TRUDNOŚCI: NIESTANDARDOWY, PODAJ ZAKRES LICZB");
                    Console.WriteLine();
                    Console.Write("PODAJ NAJMNIEJSZĄ LICZBĘ Z TWOJEGO ZAKRESU: ");
                    minRange = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("PODAJ NAJWIĘKSZĄ LICZBĘ Z TWOJEGO ZAKRESU: ");
                    maxRange = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór poziomu trudności. Ustawiam poziom łatwy.");
                    maxRange = 100;
                    break;
            }
        }

        static void SelectGameMode(int minRange, int maxRange)
        {
            Console.WriteLine("!!!WYBIERZ TRYB GRY!!!");
            Console.WriteLine();
            Console.WriteLine("1. Ty zgadujesz.");
            Console.WriteLine();
            Console.WriteLine("2. Program zgaduje. Pamiętaj aby jako nazwę gracza wpisać słowo \"program\",");
            Console.WriteLine("w przeciwnym razie zapis danych będzie nieprawidłowy!!!");
            Console.WriteLine();
            Console.WriteLine("3. Zgadywanie odbywa się na zmianę.");
            Console.WriteLine();
            Console.WriteLine("4. Multiplayer.");
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
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Wybrany tryb gry: Multiplayer");
                    Console.WriteLine();
                    Console.WriteLine("Podaj ilość graczy (2-4).");
                    int playersNumber = Convert.ToInt32(Console.ReadLine());
                    if (playersNumber < 2 || playersNumber > 4)
                    {
                        Console.WriteLine("Niepoprawna liczba graczy. Ustawiam 2 graczy.");
                        playersNumber = 2;
                    }

                    Player[] players = new Player[playersNumber];
                    for (int i = 0; i < playersNumber; i++)
                    {
                        players[i] = new Player();
                        Console.WriteLine($"Podaj nazwę gracza {i + 1}:");
                        players[i].Nickname = Console.ReadLine();
                    }

                    Multiplayer multiplayerGame = new Multiplayer(players, minRange, maxRange, true);
                    multiplayerGame.StartMultiplayerGame();
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór trybu gry. Ustawiam tryb numer jeden!");
                    Player player4 = new Player();
                    player4.CreatePlayer();
                    Game game1 = new Game(player4, minRange, maxRange);
                    game1.StartGame();
                    break;
            }
        }
    }
}