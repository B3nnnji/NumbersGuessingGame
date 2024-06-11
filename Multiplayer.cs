namespace NumbersGuessingGame
{
    internal class Multiplayer
    {
        private Player[] players;
        private int minRange;
        private int maxRange;
        private int numberToGuess;
        private Dictionary<Player, int> playerGuesses;
        private bool isCustomRange;

        public Multiplayer(Player[] players, int minRange, int maxRange, bool isCustomRange = false)
        {
            this.players = players;
            this.minRange = minRange;
            this.maxRange = maxRange;
            this.isCustomRange = isCustomRange;
            playerGuesses = new Dictionary<Player, int>();

            foreach (var player in players)
            {
                playerGuesses[player] = 0;
            }
        }

        public void RandomNumberGenerator()
        {
            Random random = new Random();
            numberToGuess = random.Next(minRange, maxRange + 1);
        }

        public void StartMultiplayerGame()
        {
            RandomNumberGenerator();
            Console.WriteLine($"Zgadnij liczbę z zakresu od {minRange} do {maxRange}.");
            bool numberGuessed = false;
            int currentPlayerIndex = 0;

            while (!numberGuessed)
            {
                try
                {
                    Player currentPlayer = players[currentPlayerIndex];
                    Console.WriteLine($"Tura gracza {currentPlayer.Nickname}. Podaj swoją zgadywaną liczbę:");
                    int guess = Convert.ToInt32(Console.ReadLine());
                    playerGuesses[currentPlayer]++;

                    if (guess == numberToGuess)
                    {
                        Console.WriteLine($"Gratulacje {currentPlayer.Nickname}, zgadłeś liczbę {numberToGuess} w {playerGuesses[currentPlayer]} próbach!");
                        numberGuessed = true;
                        SaveBestResultToFile saveResult = new SaveBestResultToFile(currentPlayer.Nickname, true);
                        saveResult.CheckAndUpdateBestResult(playerGuesses[currentPlayer]);

                        if (isCustomRange)
                        {
                            Console.WriteLine($"{currentPlayer.Nickname}, masz możliwość wybrać nowy zakres liczb.");
                            Console.WriteLine("PODAJ NAJMNIEJSZĄ LICZBĘ Z TWOJEGO ZAKRESU:");
                            minRange = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("PODAJ NAJWIĘKSZĄ LICZBĘ Z TWOJEGO ZAKRESU:");
                            maxRange = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    else if (guess < numberToGuess)
                    {
                        Console.WriteLine("Błędna odpowiedź. Wylosowana liczba jest WIĘKSZA!");
                    }
                    else
                    {
                        Console.WriteLine("Błędna odpowiedź. Wylosowana liczba jest MNIEJSZA!");
                    }

                    currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wprowadzono zły format odpowiedzi spróbuj ponownie!");
                }
            }
            PlayAgain();
        }

        public void PlayAgain()
        {
            while (true)
            {
                Console.WriteLine("Czy chcesz zagrać ponownie w trybie multiplayer? (Y/N)");
                string choice = Console.ReadLine() ?? string.Empty;
                choice = choice.ToUpper();

                if (choice == "Y")
                {
                    StartMultiplayerGame();
                }
                else if (choice == "N")
                {
                    Console.WriteLine("!!!DZIĘKUJĘ ZA GRĘ!!!");
                    break;
                }
                else
                {
                    Console.WriteLine("Podaj poprawną odpowiedź!");
                }
            }
        }
    }
}