using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Читаємо вхідне число N з файлу
        string input = File.ReadAllText("Input.txt").Trim();
        
        // Ініціалізуємо змінну для зберігання кількості "щасливих" чисел
        int count = 0;
        
        // Знайдемо всі можливі "щасливі" числа, що складаються з 4 і 7 і не перевищують N
        GenerateLuckyNumbers("", input, ref count);
        
        // Записуємо результат у файл
        File.WriteAllText("Output.txt", count.ToString());
    }

    // Рекурсивна функція для генерації всіх комбінацій цифр 4 і 7
    static void GenerateLuckyNumbers(string current, string limit, ref int count)
    {
        // Якщо поточне число більше за N, припиняємо генерацію
        if (current.Length > 0 && (current.Length < limit.Length || 
                                   (current.Length == limit.Length && string.Compare(current, limit) <= 0)))
        {
            count++;
        }

        // Додаємо нову цифру 4 або 7, якщо довжина не перевищує довжини ліміту
        if (current.Length < limit.Length)
        {
            GenerateLuckyNumbers(current + "4", limit, ref count);
            GenerateLuckyNumbers(current + "7", limit, ref count);
        }
    }
}