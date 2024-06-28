// ЗАДАЧА 2
// Назовем число "интересным", если его сумма цифр четная
// Создать двумерный массив, состоящий из целых чисел. Вывести на экран 
// "интересные" элементы массива

int[,] CreateMatrix(int rowCount, int ColumnCount)
{
    int[,] matrix = new int[rowCount, ColumnCount];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(1, 1000);
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

int[,] matrix = CreateMatrix(3, 8);
ShowMatrix(matrix);

foreach (int elem in matrix)
{
    if (IsInteresting(elem) == true)
    {
        System.Console.WriteLine(elem);
    }
}

bool IsInteresting(int value)
{
    int sumOfDigits = GetSumofDigits(value);
    if (sumOfDigits % 2 == 0)
    {
        return true;
    }
    return false;
}

int GetSumofDigits(int value)
{

    int sum = 0;
    while (value > 0)
    {
        sum = sum + value % 10;
        value = value / 10;
    }
    return sum;
}