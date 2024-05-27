using System;

namespace NumbersGuessingGame
{
    internal class Game
    {
        int randomNumber;
        int guesses = 1;
        private int maxRange;
        private int minRange;

        private Player player;
        private SaveBestResultToFile bestResult;

        public Game(Player player, int minRange, int maxRange)
        {
            this.player = player;
            bestResult = new SaveBestResultToFile(player.Nickname, false); // false for single-player
            this.minRange = minRange;
            this.maxRange = maxRange;
        }

        public void StartGame()
        {
            RandomNumberGenerator();
            PlayerGuess();
            PlayAgain();
        }

        public void RandomNumberGenerator()
        {
            Random random = new Random();
            randomNumber = random.Next(minRange, maxRange);
        }

        public void PlayerGuess()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"Wylosowano liczbę od {minRange} do {maxRange}. Jaka to liczba?");
                    Console.WriteLine();
                    int guess = Convert.ToInt32(Console.ReadLine());

                    if (guess == randomNumber)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Poprawna odpowiedź! Liczba prób: " + guesses);
                        Console.WriteLine();
                        bestResult.CheckAndUpdateBestResult(guesses);
                        break;
                    }
                    else if (guess > randomNumber)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Błędna odpowiedź. Wylosowana liczba jest MNIEJSZA!");
                        Console.WriteLine();
                        guesses++;
                    }
                    else if (guess < randomNumber)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Błędna odpowiedź. Wylosowana liczba jest WIĘKSZA!");
                        Console.WriteLine();
                        guesses++;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Błędny format odpowiedzi!");
                }
            }
        }

        public void PlayAgain()
        {
            while (true)
            {
                Console.WriteLine("Czy chcesz zagrać ponownie? (Y/N)");
                Console.WriteLine();
                string choice = Console.ReadLine() ?? string.Empty;
                choice = choice.ToUpper();

                if (choice == "Y")
                {
                    guesses = 1;
                    RandomNumberGenerator();
                    PlayerGuess();
                }
                else if (choice == "N")
                {
                    Console.WriteLine();
                    Console.WriteLine("!!!DZIĘKUJĘ ZA GRĘ!!!");
                    break;
                }
                else
                {
                    Console.WriteLine("Podaj poprawną odpowiedź!");
                    Console.WriteLine();
                }
            }
        }
    }
}
