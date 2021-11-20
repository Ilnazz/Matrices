using System;
using System.Collections;

namespace Matrices
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Первое задание: ");
            First();
            Console.WriteLine("Второе задание: ");
            Second();
            Console.WriteLine("Третье задание: ");
            Third();
            Console.WriteLine("Четвертое задание: ");
            Fourth();
        }

        public static void First()
        {
            const int height = 5, width = 7, // Количество строк и столбцов матрицы
                minValue = 0, maxValue = 5; // Диапазон случайных чисел

            Matrix m = new Matrix(height, width); // Создание матрицы
            m.RandomFill(minValue, maxValue + 1); // Заполнение случайными числами
            m.Print(); // Вывод на экран

            // Массив для хранения количества повторений чисел, входящих в диапазон [minValue; maxValue]
            int[] repeatings = new int[maxValue + 1]; 

            int rowsWithoutZeros = 0; // Количество строк без нулевых элементов
            bool foundZeroInRow; // Найдено ли в строке число ноль
            for (int i = 0; i < m.height; i++)
            {
                foundZeroInRow = false;
                for (int j = 0; j < m.width; j++)
                {
                    int number = m.Get(i, j); // Получаем очередное число в строке
                    if (number == 0) foundZeroInRow = true; // Если число 0, значит эта строка содержит ноль
                    repeatings[number]++; // Увеличиваем количество вхождений данного числа
                }
                if (!foundZeroInRow) rowsWithoutZeros++; // Если нулей найдено не было, тогда увеличиваем количество строк без нулевых элементов
            }

            // Поиск максимального числа, среди повторяющихся чисел
            int maxAmongRepeatingNumbers = minValue;
            for (int number = minValue; number <= maxValue; number++)
            {
                if (repeatings[number] > 1)
                {
                    if (number > maxAmongRepeatingNumbers)
                    {
                        maxAmongRepeatingNumbers = number;
                    }
                }
            }

            // Вывод результатов на консоль
            Console.WriteLine($"Количество строк, не содержащих ни одного нулевого элемента: {rowsWithoutZeros}");
            Console.WriteLine($"Максимальное число, среди чисел, повторяющихся более одного раза: {maxAmongRepeatingNumbers}");
        }

        public static void Second()
        {
            const int height = 5, width = 5, // Количество строк и столбцов матрицы
                minValue = 0, maxValue = 10; // Диапазон случайных чисел

            Matrix m = new Matrix(height, width); // Создание матрицы
            m.RandomFill(minValue, maxValue + 1); // Заполнение случайными числами
            m.Print();

            /*
             * 1 2 3
             * 4 5 6
             * 7 8 9
             * 
             * 1 + 4 + 7 + 5 + 8 + 9 = 34
             */

            Console.WriteLine("Сумма чисел главной диагонали и под ней данной матрицы:");
            int sum = 0;
            int numbersToSum; // Сколько чисел из данной строке нужно прибавить к общей сумме: 0 - значит 1 число, 1 - 2 числа и т.д.
            for (int i = 0; i < m.height; i++)
            {
                numbersToSum = i; 
                for (int j = 0; j < m.width; j++)
                {
                    if (j <= numbersToSum)
                    {
                        sum += m.Get(i, j);
                        Console.Write($"{m.Get(i, j)} + ");
                    }
                }
            }
            Console.WriteLine($"= {sum}");
        }

        public static void Third()
        {
            const int height = 5, width = 6, // Количество строк и столбцов матрицы
                minValue = 0, maxValue = 5; // Диапазон случайных чисел

            Matrix m = new Matrix(height, width); // Создание матрицы
            m.Initialize(new int[,]{ { 1, 1, 2, 5, 6, 1 }, { 5, 6, 8, 5, 6, 7 }, { 10, 12, 10, 12, 11, 11 }, { 8, 10, 5, 6, 8, 9 }, { 6, 5, 10, 12, 15, 19 } });
            m.Print();


            ArrayList saddlePoints = new ArrayList(); // Список для хранения узловых точек
            int number;
            for (int row = 0; row < m.height; row++)
            {
                for (int col = 0; col < m.width; col++)
                {
                    number = m.Get(row, col);
                    
                    // Если это число наименьшее в этой строке и наибольшее в этом столбце, тогда это узловая точка
                    if (m.isMinInRow(number, row) && m.isMaxInCol(number, col))
                    {
                        saddlePoints.Add(new Point(row, col)); // Добавление координат числа в список узловых точек
                    }
                }
            }

            // Если найдена хотя бы одна узловая точка, тогда вывести результаты на консоль
            if (saddlePoints.Count > 0)
            {
                Console.WriteLine("Координаты узловых точек матрицы (строка, столбец):");
                foreach (Point saddlePoint in saddlePoints)
                {
                    Console.Write($"({saddlePoint.row}, {saddlePoint.col}) ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Матрица не имеет узловых точек.");
            }

        }

        public static void Fourth()
        {
            Matrix m1 = new Matrix(2, 3); // Создание первой матрицы
            m1.RandomFill(0, 10); // Заполнение случайными числами
            Console.WriteLine("Первая матрица:");
            m1.Print();

            Matrix m2 = new Matrix(3, 1); // Создание второй матрицы
            m2.RandomFill(0, 10); // Заполнение случайными числами
            Console.WriteLine("Вторая матрица:");
            m2.Print();

            // Перемножение матриц
            Matrix result = m1.MultiplyBy(m2);
            Console.WriteLine("Результат перемножения матриц:");
            result.Print();
        }

    }
}