/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

int[,] Generate2DArray(int m, int n)
{
    int[,] array = new int[m, n];
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(1, 10);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

void Sort2DArray(int[,] array)
{
    int tmp = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = j + 1; k < array.GetLength(1); k++)
            {
                if (array[i, j] > array[i, k])
                {
                    tmp = array[i, j];
                    array[i, j] = array[i, k];
                    array[i, k] = tmp;
                }
            }
        }
    }
}

/*
int[,] array = Generate2DArray(3,4);

PrintArray(array);

Console.WriteLine();

Sort2DArray(array);

PrintArray(array);
*/

/*Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку 
с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке 
и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

int FindRowWithMinSum(int[,] array)
{
    int min = 999;
    int row = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum = sum + array[i, j];

        }
        if (sum < min)
        {
            min = sum;
            row++;
        }

    }
    return row;
}

/*
int[,] array = Generate2DArray(3, 4);

PrintArray(array);

int row = FindRowWithMinSum(array);

Console.WriteLine($"Номер строки с наименьшей суммой элементов: {row} строка");
*/


/*Задача 58: Задайте две матрицы. Напишите программу, 
которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

int[,] ProductOfMatrix(int[,] array, int[,] array2)
{
    int[,] result = new int[array.GetLength(0), array2.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1); k++)
            {
                result[i, j] += array[i, k] * array2[k, j];
            }
        }
    }
    return result;
}

/*
int[,] array = Generate2DArray(2, 2);

PrintArray(array);

Console.WriteLine();

int[,] array2 = Generate2DArray(2, 2);

PrintArray(array2);

Console.WriteLine();

int[,] result = ProductOfMatrix(array, array2);

PrintArray(result);
*/


/*Задача 60. ...Сформируйте трёхмерный массив из 
неповторяющихся двузначных чисел. Напишите программу, 
которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/


int[,,] Generate3DArray(int m, int n, int o)
{
    int[,,] array = new int[m, n, o];
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = random.Next(10, 100);
            }
        }
    }
    return array;
}

void Print3DArray(int[,,] array)
{
    for (int k = 0; k < array.GetLength(2); k++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write($"{array[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}


Dictionary<int, int> RandomNumbers(int[,,] array)
{
    Dictionary<int, int> dic = new Dictionary<int, int>();

    Random random = new Random();

    for (int k = 0; k < array.GetLength(2); k++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (!dic.TryAdd(array[i, j, k], 1))
                {
                    array[i, j, k] = random.Next(10, 100);
                    j--;
                }
            }
        }
    }
    return dic;
}


/*
int[,,] array = Generate3DArray(2, 2, 2);

RandomNumbers(array);

Print3DArray(array);
*/

/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

int[,] FillArraySpiral(int m, int n)
{
    int[,] array = new int[m, n];

    for (int i = 0; i < length; i++)
    {
        for (int i = 0; i < length; i++)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] += 1;
                }
            }
        }
    }

}


//  Я не знаю как это сделать. Пытался гуглить, смотрел видео и всё равно ничего не понял.