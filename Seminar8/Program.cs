/*Задача 53: Задайте двумерный массив. 
Напишите программу, которая поменяет местами первую и последнюю строку массива.
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

void ChangeFirstAndLastString(int[,] array)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        int tmp = array[0, i];
        array[0, i] = array[array.GetLength(0) - 1, i];
        array[array.GetLength(0) - 1, i] = tmp;
    }
}
/*
int[,] array = Generate2DArray(3, 4);
PrintArray(array);
Console.WriteLine();
ChangeFirstAndLastString(array);
PrintArray(array);
*/

/*Задача 55: Задайте двумерный массив. 
Напишите программу, которая заменяет строки на столбцы. 
В случае, если это невозможно, программа должна вывести 
сообщение для пользователя.*/

/*
int[,] array = Generate2DArray(3, 3);

PrintArray(array);

Console.WriteLine();

ChangeRowsToColums(array);

PrintArray(array);
*/
void ChangeRowsToColums(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = i; j < array.GetLength(1); j++)
        {
            int tmp = array[i, j];
            array[i, j] = array[j, i];
            array[j, i] = tmp;
        }
    }
}

/*Задача 57: Составить частотный словарь элементов двумерного массива. 
Частотный словарь содержит информацию о том, сколько раз 
встречается элемент входных данных.
Набор данных
Частотный массив
{ 1, 9, 9, 0, 2, 8, 0, 9 }
0 встречается 2 раза
1 встречается 1 раз
2 встречается 1 раз
8 встречается 1 раз
9 встречается 3 раза
1, 2, 3 4, 6, 1 2, 1, 6
1 встречается 3 раза
2 встречается 2 раз
3 встречается 1 раз
4 встречается 1 раз
6 встречается 2 раза
*/

int[,] array = Generate2DArray(2, 8);

PrintArray(array);

Console.WriteLine();

Dictionary<int, int> result = dawdaw(array);

PrintDictionary(result);

void PrintDictionary(Dictionary<int, int> result)
{
    foreach (var row in result)
    {
        if (row.Value % 10 == 2 | row.Value % 10 == 3 | row.Value % 10 == 4)
        {
            Console.WriteLine($"{row.Key} встречатся {row.Value} раза");
        }
        else
        {
            Console.WriteLine($"{row.Key} встречатся {row.Value} раз");
        }
    }
}

Dictionary<int, int> dawdaw(int[,] array)
{
    Dictionary<int, int> dic = new Dictionary<int, int>();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (!dic.TryAdd(array[i, j], 1))
            {
                dic[array[i, j]] += 1;
            }

        }
    }
    return dic;
}


