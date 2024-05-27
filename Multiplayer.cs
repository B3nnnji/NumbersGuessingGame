using System;
using System.Collections.Generic;
using System.Linq;

namespace NumbersGuessingGame
{
    internal class Multiplayer
    {
        private Player[] players;
        private int minRange;
        private int maxRange;
        private int numberToGuess;
        private Dictionary<Player, int> playerGuesses;

        public Multiplayer(Player[] players, int minRange, int maxRange)
        {
            this.players = players;
            this.minRange = minRange;
            this.maxRange = maxRange;
            playerGuesses = new Dictionary<Player, int>();

            foreach (var player in players)
            {
                playerGuesses[player] = 0;
            }
        }

        public void RandomNumberGenerator()
        {
            Random random = new Random();
            numberToGuess = random.Next(minRange, maxRange);
        }

        public void StartMultiplayerGame()
        {
            RandomNumberGenerator();
            Console.WriteLine(numberToGuess);
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
                    Console.WriteLine("Wprowadzono zły format odpowiedzi sprubój ponownie!");
                }
            }
            PlayAgain();
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
                    StartMultiplayerGame();
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
