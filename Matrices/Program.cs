using System;
using System.Collections.Generic;
using System.Linq;

namespace Others
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"C из 7 по 5 = {Combinations(7, 5)}");

            //Combinations2(9, 7, out int C_9_7);
            //Console.WriteLine($"C из 9 по 7 = {C_9_7}");

            //Console.WriteLine($"ПараЛимпоМенон -> {ReverseCase("ПараЛимпоМенон")}");

            //Fourth();
            Fifth();
        }
        /*
        static int FactorialLinear(int n)
        {
            int r = 1;
            while (n > 1)
            {
                r *= n--;
            }
            return r;
        }
        */
        static int Factorial(int n)
        {
            if (n == 1)
                return 1;

            return n * Factorial(n - 1);
        }
        // First
        static int Combinations(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }
        // Second
        static void Combinations2(int n, int k, out int result)
        {
            result = Factorial(n) / (Factorial(k) * Factorial(n - k));
        }
        static string ReverseCase(string str)
        // Third
        {
            char[] letters = str.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = Char.IsLower(letters[i]) ? Char.ToUpper(letters[i]) : Char.ToLower(letters[i]);
            }
            return new string(letters);
        }
        // Fourth
        static void Fourth()
        {
            const int N = 10;
            int[] array = new int[N];

            Console.WriteLine($"Массив из {N} случайных чисел от 0 до 100:");
            Random rand = new Random();
            for (int i = 0; i < N; i++)
            {
                array[i] = rand.Next(0, 100);
                Console.WriteLine(array[i]);
            }

            CalculateArrayAverage(array, out int average);
            CountNumbersHigherThan(array, average, out int numbersHigehrThanAverage);

            Console.WriteLine($"Среднее значение среди элементов массива: {average}\n" +
                $"Количество элементов, больших среднего значения: {numbersHigehrThanAverage}");
        }
        static void CountNumbersHigherThan(int[] array, int x, out int numbersHigehrThanAverage)
        {
            numbersHigehrThanAverage = 0;
            foreach (int n in array)
                if (n > x)
                    numbersHigehrThanAverage++;
        }
        static void CalculateArrayAverage(int[] array, out int average)
        {
            int sum = 0;
            foreach (int n in array)
            {
                sum += n;
            }
            average = sum / array.Length;
        }
        // Fifth
        static void Fifth() {
            int height = 5,
                width = 5;

            int[,] m = new int[height, width];

            Random rnd = new Random();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    m[i, j] = rnd.Next(10, 99);
                }
            }

            Console.WriteLine("Исходная матрица:");
            PrintMatrix(m);

            SortMatrixColumns(m);

            Console.WriteLine("Матрица после сортировки столбцов:");
            PrintMatrix(m);
        }
        static void PrintMatrix(int[,] m)
        {
            for (int col = 0; col < m.GetLength(1); col++)
            {
                Console.Write($" {col} ");
            }
            Console.Write(" - номера столбцов\n");
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }
            for (int col = 0; col < m.GetLength(1); col++)
            {
                Console.Write($" {(col % 2 == 0 ? 'ч' : 'н')} ");
            }
            Console.Write(" - четность столбцов\n");
        }
        static void SortMatrixColumns(int[,] m)
        {
            int width = m.GetLength(1);
            for (int col = 0; col < width; col++)
            {
                // Если столбец нечетный
                if (col % 2 != 0)
                {
                    SortMatrixColumn(m, col, true); // Упорядочить по возрастанию
                }
                // Если столбец четный
                else
                {
                    SortMatrixColumn(m, col, false); // Упорядочить по убыванию
                }
            }
        }
        static void SortMatrixColumn(int[,] m, int col, bool ascending)
        {
            int height = m.GetLength(0);

            int temp;
            for (int i = 0; i < height - 1; i++)
            {
                int smallest = i;
                for (int j = i + 1; j < height; j++)
                {
                    // По возрастанию
                    if (ascending)
                    {
                        if (m[j, col] < m[smallest, col])
                            smallest = j;
                    }
                    // По убыванию
                    else
                    {
                        if (m[j, col] > m[smallest, col])
                            smallest = j;
                    }
                    
                }
                temp = m[smallest, col];
                m[smallest, col] = m[i, col];
                m[i, col] = temp;
            }
        }
    }
}
