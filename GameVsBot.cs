using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGuessingGame;

internal class GameVsBot
{
    int guess;
    int guesses = 1;

    private Player player;
    private SaveBestResultToFile bestResult;

    public GameVsBot(Player player)
    {
        this.player = player;
        bestResult = new SaveBestResultToFile(player.Nickname);
    }

    public void StartGameVsBot()
    {
        BotsGuess();
        PlayAgainVsBot();
    }
    
    public void BotsGuess()
    {
        while (true)
        {
            try
            {
                Console.Write("Podaj pierwszą liczbę z zakresu w jakim program ma zgadywać: ");
                int firstRangeNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Podaj drugą liczbę z zakresu w jakim program ma zgadywać: ");
                int secondRangeNum = Convert.ToInt32(Console.ReadLine());

                Random randomRange = new Random();
                guess = randomRange.Next(firstRangeNum, secondRangeNum);

                Console.WriteLine("Mój strzał to: " + guess);

                Console.WriteLine("Y/N?");
                string playerChoice = Console.ReadLine() ?? string.Empty;
                playerChoice = playerChoice.ToUpper();

                if (playerChoice == "Y")
                {
                    Console.WriteLine("A więc zgadłem!");
                    bestResult.CheckAndUpdateBestResult(guesses);
                    break;
                }
                else if (playerChoice == "N")
                {
                    Console.WriteLine("Niech to! Może po zmniejszeniu zakresu liczb uda mi sie trafić.");
                    guesses++;
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
        }
    }

    public void PlayAgainVsBot()
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
                BotsGuess();
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
