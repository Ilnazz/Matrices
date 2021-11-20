using System;
using System.Collections;

namespace Matrices
{
    class Matrix
    {
        public int height { get; }
        public int width { get; }
        private int[,] data;

        public Matrix(int h, int w)
        {
            height = h;
            width = w;

            data = new int[h, w];
        }

        public int Get(int row, int col)
        {
            if (row < 0 || row - 1 > height)
            {
                throw new ArgumentException("Неверный номер строки");
            }
            else if (col < 0 || col - 1 > width)
            {
                throw new ArgumentException("Неверный номер столбца");
            }
            return data[row, col];
        }

        public void Set(int row, int col, int value)
        {
            if (row < 0 || row - 1 > height)
            {
                throw new ArgumentException("Неверный номер строки");
            }
            else if (col < 0 || col - 1 > width)
            {
                throw new ArgumentException("Неверный номер столбца");
            }
            data[row, col] = value;
        }

        public void RandomFill(int min, int max)
        {
            Random rnd = new Random();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    data[i, j] = rnd.Next(min, max);
                }
            }
        }

        public void Initialize(int[,] data)
        {
            if (data.GetLength(0) < height || data.GetLength(1) < width)
            {
                throw new ArgumentException("Размерность матрицы больше, чем размерность переданных данных");
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    this.data[i, j] = data[i, j];
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write($"{data[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public Matrix MultiplyBy(Matrix other)
        {
            if (this.width != other.height)
            {
                Console.WriteLine("Ширина первой матрицы должна быть равна высоте второй.");
                return null;
            }

            Matrix result = new Matrix(this.height, other.width);

            for (int thisRow = 0; thisRow < this.height; thisRow++)
            {
                for (int otherCol = 0; otherCol < other.width; otherCol++)
                {
                    int sum = 0;
                    for (int otherRow = 0; otherRow < other.height; otherRow++)
                    {
                        sum += this.data[thisRow, otherRow] * other.data[otherRow, otherCol];
                    }
                    result.data[thisRow, otherCol] = sum;
                }
            }

            return result;
        }

        public bool isMinInRow(int number, int row)
        {
            int min = data[row, 0];
            for (int col = 1; col < width; col++)
            {
                if (data[row, col] < min)
                {
                    min = data[row, col];
                }
            }
            if (min == number)
            {
                return true;
            }
            return false;
        }

        public bool isMaxInCol(int number, int col)
        {
            int max = data[0, col];
            for (int row = 1; row < height; row++)
            {
                if (data[row, col] > max)
                {
                    max = data[row, col];
                }
            }
            if (max == number)
            {
                return true;
            }
            return false;
        }
    }
}
