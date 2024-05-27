using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGuessingGame;

internal class MixedGame
{
    int coinflipNumber;
    int randomNumber;
    int playerGuesses = 1;
    int botGuesses = 1;
    private Player player;
    private int maxRange;
    private int minRange;

    public MixedGame(Player player, int minRange, int maxRange)
    { 
        this.player = player;
        this.maxRange = maxRange;
        this.minRange = minRange;
    }

    private void Coinflip()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Wybierz orła lub reszkę do rzutu monetą! O/R");
                string playerInput = Console.ReadLine() ?? string.Empty;
                playerInput = playerInput.ToUpper();

                if (playerInput == "R")
                {
                    Console.WriteLine("Po naciśnięciu enter odbędzie się \"rzut monetą\", komputer ma orła a ty reszkę.");
                    Console.ReadLine();
                }
                else if (playerInput == "O")
                {
                    Console.WriteLine("Po naciśnięciu enter odbędzie się \"rzut monetą\", komputer ma reszkę a ty orła.");
                    Console.ReadLine();
                }

                Random coinflip = new Random();
                coinflipNumber = coinflip.Next(1, 3);

                if (coinflipNumber == 1)
                {
                    Console.WriteLine("Zaczyna komputer");
                    break;
                }
                else
                {
                    Console.WriteLine("Ty zaczynasz!");
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Błędny format odpowiedzi! Sprubój ponownie.");
            }
        }
    }

    private void RandomNumberGenerator()
    {
        Random random = new Random();
        randomNumber = random.Next(minRange, maxRange);
        Console.WriteLine(randomNumber);
    }

    private void PlayerGuess()
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
                    Console.WriteLine($"Poprawna odpowiedź!");
                    Console.WriteLine();
                    Console.WriteLine("!!!TY WYGRYWASZ!!!");
                    Console.WriteLine();
                    Console.WriteLine("Próby:");
                    Console.WriteLine("Ty: " + playerGuesses);
                    Console.WriteLine("Komputer: " + botGuesses);
                    break;
                }
                else if (guess > randomNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine("Błędna odpowiedź. Wylosowana liczba jest MNIEJSZA!");
                    Console.WriteLine();
                    playerGuesses++;
                    BotsGuess();
                }
                else if (guess < randomNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine("Błędna odpowiedź. Wylosowana liczba jest WIĘKSZA!");
                    Console.WriteLine();
                    playerGuesses++;
                    BotsGuess();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Błędny format odpowiedzi!");
            }
            PlayMixedGameAgain();
        }
    }

    private void BotsGuess()
    {
        while (true)
        {
            try
            {
                Console.Write("Podaj pierwszą liczbę z zakresu w jakim program ma zgadywać: ");
                int firstRangeNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Podaj drugą liczbę z zakresu w jakim program ma zgadywać: ");
                int secondRangeNum = Convert.ToInt32(Console.ReadLine());
                int guess;

                Random randomRange = new Random();
                guess = randomRange.Next(firstRangeNum, secondRangeNum);

                Console.WriteLine("Mój strzał to: " + guess);

                Console.WriteLine("Y/N?");
                string playerChoice = Console.ReadLine() ?? string.Empty;
                playerChoice = playerChoice.ToUpper();

                if (playerChoice == "Y")
                {
                    Console.WriteLine($"Zgadłem!");
                    Console.WriteLine();
                    Console.WriteLine("!!!WYGRYWA KOMPUTER!!!");
                    Console.WriteLine();
                    Console.WriteLine("PRÓBY:");
                    Console.WriteLine("Ty: " + playerGuesses);
                    Console.WriteLine("Komputer: " + botGuesses);
                    break;
                }
                else if (playerChoice == "N")
                {
                    Console.WriteLine("Niech to! Może po zmniejszeniu zakresu liczb uda mi sie trafić.");
                    botGuesses++;
                    PlayerGuess();
                }
                else
                {
                    Console.WriteLine("Podaj poprawną odpowiedź!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Błędny format!");
            }
            PlayMixedGameAgain();
        }
    }

    private void PlayMixedGameAgain()
    {
        while (true)
        {
            Console.WriteLine("Czy chcesz zagrać ponownie? (Y/N)");
            Console.WriteLine();
            string choice = Console.ReadLine() ?? string.Empty;
            choice = choice.ToUpper();

            if (choice == "Y")
            {
                playerGuesses = 1;
                botGuesses = 1;
                StartMixedGame();
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

    public void StartMixedGame()
    {
        RandomNumberGenerator();
        Coinflip();

        if (coinflipNumber == 1)
        {
            BotsGuess();
        }
        else
        {
            PlayerGuess();
        }
    }
}
