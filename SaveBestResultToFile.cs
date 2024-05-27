using System;
using System.IO;

namespace NumbersGuessingGame
{
    internal class SaveBestResultToFile
    {
        private int bestResult;
        private string nickname;
        private string filePath;

        public SaveBestResultToFile(string nickname, bool isMultiplayer)
        {
            this.nickname = nickname;
            filePath = isMultiplayer ? $"{nickname}_MultiplayerBestResult.txt" : $"{nickname}_BestResult.txt";
        }

        public void SaveResult()
        {
            string result = $"Najlepszy Wynik: {bestResult}";

            try
            {
                File.WriteAllText(filePath, result);
                Console.WriteLine("Wynik zapisany pomyślnie do pliku.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd z zapisem wyniku: {ex.Message}");
            }
        }

        public void CheckAndUpdateBestResult(int currentResult)
        {
            if (File.Exists(filePath))
            {
                string existingResultContent = File.ReadAllText(filePath);
                if (int.TryParse(existingResultContent.Replace("Najlepszy Wynik: ", "").Trim(), out int existingBestResult))
                {
                    if (currentResult < existingBestResult || existingBestResult == 0)
                    {
                        bestResult = currentResult;
                        Console.WriteLine("Udało Ci się poprawić najlepszy wynik!");
                        SaveResult();
                    }
                    else
                    {
                        Console.WriteLine("Nie udało się poprawić najlepszego wyniku.");
                    }
                }
            }
            else
            {
                bestResult = currentResult;
                SaveResult();
            }
        }
    }
}
