using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            List<string> targetValues = new List<string>
            {
                //    "3a7bd3e2360a3d29eea436fcfb7e44c735d117c42d1c1835420b6b9942dd4f1b",
                //    "1115dd800feaacefdf481f1f9070374a2a81e27880f187396db67958b207cbad",
                //    "74e1bb62f8dabb8125a58852b63bdf6eaef667cb56ac7f7cdba6d7305c50a22f",
            };

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Введите хэш-значение №{i + 1}");
                targetValues.Add(Console.ReadLine());
            }
            Console.WriteLine("Введите количество потоков");
            int treadsNumber = Convert.ToInt32(Console.ReadLine());

            stopwatch.Start();
            BruteForce.bruteForce(treadsNumber, targetValues);
            stopwatch.Stop();

            TimeSpan elapsedTime = stopwatch.Elapsed;

            Console.WriteLine("Прошло времени: " + elapsedTime);
        }
    }
}
