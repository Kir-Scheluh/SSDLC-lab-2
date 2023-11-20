using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BruteForce
    {
        static char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        static public string calculateSHA256(string input)
        {
            // Создать объект класса SHA256
            using (var sha256 = SHA256.Create())
            {
                // Преобразовать входную строку в байтовый массив
                var inputBytes = Encoding.UTF8.GetBytes(input);

                // Вычислить хэш SHA-256
                var hashBytes = sha256.ComputeHash(inputBytes);

                // Преобразовать байтовый массив в строку шестнадцатеричных чисел
                var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                // Вернуть строку хэша
                return hashString;
            }
        }
        static IEnumerable<string> GetPermutations(char[] alphabet, int length)
        {
            if (length == 1)
            {
                return alphabet.Select(c => c.ToString());
            }

            return GetPermutations(alphabet, length - 1)
                .SelectMany(s => alphabet, (s, c) => s + c);
        }

        static public void bruteForce(int numberOfThreads, List<string> targetValues)
        {
            ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = numberOfThreads };
            Parallel.ForEach(GetPermutations(alphabet, 5), options, (password) =>
            {
                string sha256 = calculateSHA256(password);
                foreach (string targetValue in targetValues)
                {
                    if (targetValue == sha256)
                    {
                        Console.WriteLine($"Найден пароль: {password} соответствующий хеш: {sha256}");
                        //count++;
                        //if (count == 3) return;
                    }
                }
            });

            Console.WriteLine("Поиск завершен");
        }
    }
}
