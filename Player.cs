using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersGuessingGame;

internal class Player
{
    public string Nickname { get; set; } = string.Empty;

    public void CreatePlayer()
    {
        Console.WriteLine("!!!WITAJ W GRZE ZGADYWANCE!!!");
        Console.WriteLine();

        while (true)
        {
            Console.Write("Podaj swoją nazwę użytkownika (maksymalnie 10 znaków): ");
            string nickname = Console.ReadLine() ?? string.Empty;

            if (nickname.Length > 10)
            {
                Console.WriteLine("Nazwa może mieć maksymalnie 10 znaków!");
                Console.WriteLine();
            }
            else
            {
                Nickname = nickname;
                Console.WriteLine();
                Console.WriteLine("WITAJ " + nickname);
                Console.WriteLine();

                string filePath = $"{Nickname}_BestResult.txt";
                if (File.Exists(filePath))
                {
                    string existingResultContent = File.ReadAllText(filePath);
                    if (int.TryParse(existingResultContent.Replace("Najlepszy Wynik: ", "").Trim(), out int existingBestResult))
                    {
                        Console.WriteLine($"Twój aktualny najlepszy wynik to: {existingBestResult} prób(y).");
                        Console.WriteLine("Czy chcesz zresetować swój najlepszy wynik? (Y/N)");
                        string resetChoice = Console.ReadLine()?.ToUpper() ?? string.Empty;
                        if (resetChoice == "Y")
                        {
                            ResetBestResult(filePath);
                            Console.WriteLine("Twój najlepszy wynik został zresetowany.");
                        }
                        else
                        {
                        
                        }
                    }
                }
                break;
            }
        }
    }

    private void ResetBestResult(string filePath)
    {
        try
        {
            File.WriteAllText(filePath, "Najlepszy Wynik: 0");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas resetowania wyniku: {ex.Message}");
        }
    }
}
