// МНОГОМЕРНЫЕ МАССИВЫ

// Многомерные массивы обладают всеми свойствами одномерных
// !!! В памяти двумерные массивы хранятся в виде одномерного массива (т.е. не таблицы, а строки)
// Размерность - количество измерений массива
// Применение: матрицы (математика), картинки, графика игр

// ЗАДАЧА 1
//Создать двумерный массив с размерами 3 * 5, состоящий из целых чисел. 
// Вывести его элементы на экран
// создание массива: указание типа, имени массива,выделение памяти под элементы 
// int[,] table = new int[3,5];
// matrix.GetLength(0) - получение количества строк массива
// matrix.GetLength(1) - получение количества столбцов

int[,] CreateMatrix(int rowCount, int ColumnCount)
{
    int[,] matrix = new int[rowCount, ColumnCount];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(1, 11);
        }
    }
    return matrix;
}

void ShowMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write($"{matrix[i, j]} ");
        }
        System.Console.WriteLine();
    }
}

int[,] matrix = CreateMatrix(4, 6);
ShowMatrix(matrix);

// 
