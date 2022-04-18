// See https://aka.ms/new-console-template for more information
using System;

namespace Program // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        delegate void Sort(int[,] matrix, bool largestFirst);
        static void Main(string[] args)
        {
            Random random = new Random();
            int[,] matrix = new int[5,5];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = random.Next(1,99);
            while (true)
            {
                Console.WriteLine("Нажмите 1 для создания матрицы\nНажмите s для демонстрации текущей матрицы\n" +
    "Нажмите 2 для сортировки матрицы\nНажмите e для выхода");
                char c = Char.ToUpper(Convert.ToChar(Console.ReadKey().KeyChar));
                switch (c)
                {
                    case '1':
                        matrix = createMatrix();
                        break;
                    case 'S':
                        showMatrix(matrix);
                        break;
                    case '2':
                        pickAlgorithm(matrix);
                        Console.WriteLine("\nОтсортированная матрица:");
                        showMatrix(matrix);
                        break;
                    case 'E':
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }
        }
        public static int[,] createMatrix()
        {
            Console.WriteLine("\nВведите количество строк");
            byte rows = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов");
            byte columns = Convert.ToByte(Console.ReadLine());
            int[,] returnMatrix = new int[rows, columns];
            for (byte i = 0; i < returnMatrix.GetLength(0); i++)
            {
                Console.WriteLine("Введите {0} строку, вводя по одному элементу на строку",i+1);
                for (byte j = 0; j < returnMatrix.GetLength(1); j++)
                {
                    Console.WriteLine("Введите {0} элемент {1} строки", j + 1, i + 1);
                    returnMatrix[i,j] = Int32.Parse(Console.ReadLine());
                }
            }
            return returnMatrix;
        }
        public static void showMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        public static void pickAlgorithm(int[,] matrix)
        {
            Sort sort = MatrixSortMax.sort;
            Console.WriteLine("\n1 — сортировка по сумме элементов");
            Console.WriteLine("2 — сортировка по максимальному элементу");
            Console.WriteLine("3 — сортировка по минимальному элементу");
            char c = Convert.ToChar(Console.ReadKey().KeyChar);
            switch (c)
            {
                case '1':
                    sort = MatrixSortSum.sort;
                    break;
                case '2':
                    sort = MatrixSortMax.sort;
                    break;
                case '3':
                    sort = MatrixSortMin.sort;
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("1 - сортировка по возрастанию \n2 — сортировка по убыванию");
            c = Convert.ToChar(Console.ReadKey().KeyChar);
            switch (c)
            {
                case '1':
                    sort(matrix, false);
                    break;
                case '2':
                    sort(matrix, true);
                    break;
            }
        }
        public static void Swap(int[,] ar, int firstStr, int secondStr)
        {
            int[] buf = new int[ar.GetLength(1)];
            for (int i = 0; i < ar.GetLength(1); i++)
            {
                buf[i] = ar[firstStr,i];
                ar[firstStr,i] = ar[secondStr,i];
                ar[secondStr,i] = buf[i];
            }
        }
    }
    class MatrixSortSum
    {
        public static void sort(int[,] matrix, bool largestFirst)
        {
            bool wasSwaped = true;
            while (wasSwaped)
            {
                wasSwaped = false;
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    int sum1 = 0;
                    int sum2 = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        sum1 += matrix[i, j];
                        sum2 += matrix[i + 1, j];
                    }
                    if (largestFirst)
                    {
                        if (sum1 < sum2)
                        {
                            Program.Swap(matrix, i, i + 1);
                            wasSwaped = true;
                        }
                    } else
                    {
                        if (sum1 > sum2)
                        {
                            Program.Swap(matrix, i, i + 1);
                            wasSwaped = true;
                        }
                    }
                }
            }
        }
    }
    class MatrixSortMax
    {
        public static void sort(int[,] matrix, bool largestFirst)
        {
            bool wasSwaped = true;
            while (wasSwaped)
            {
                wasSwaped = false;
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    int max1 = int.MinValue;
                    int max2 = int.MinValue;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > max1)
                            max1 = matrix[i, j];
                        if (matrix[i + 1, j] > max2)
                            max2 = matrix[i + 1, j];
                    }
                    if (largestFirst)
                    {
                        if (max1 < max2)
                        {
                            Program.Swap(matrix, i, i + 1);
                            wasSwaped = true;
                        }
                    }
                    else
                    {
                        if (max1 > max2)
                        {
                            Program.Swap(matrix, i, i + 1);
                            wasSwaped = true;
                        }
                    }
                }
            }
        }
    }
    class MatrixSortMin
    {
        public static void sort(int[,] matrix, bool largestFirst)
        {
            bool wasSwaped = true;
            while (wasSwaped)
            {
                wasSwaped = false;
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    int min1 = int.MaxValue;
                    int min2 = int.MaxValue;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] < min1)
                            min1 = matrix[i, j];
                        if (matrix[i + 1, j] < min2) 
                            min2 = matrix[i + 1, j];
                    }
                    if (largestFirst)
                    {
                        if (min1 < min2)
                        {
                            Program.Swap(matrix, i, i + 1);
                            wasSwaped = true;
                        }
                    }
                    else
                    {
                        if (min1 > min2)
                        {
                            Program.Swap(matrix, i, i + 1);
                            wasSwaped = true;
                        }
                    }
                }
            }
        }
    }
}