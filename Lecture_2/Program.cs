// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// ФУНКЦИИ И МАССИВЫ

// ФУНКЦИИ
//Поищем максимум из 9 чисел
int a1 = 5;
int b1 = 888;
int c1 = 4;
int a2 = 8;
int b2 = 24;
int c2 = 50;
int a3 = 42;
int b3 = 112;
int c3 = 15;


int Max(int arg1, int arg2, int arg3)
{
    int result = arg1;
    if (arg2 > result) result = arg2;
    if (arg3 > result) result = arg3;
    return result;
}

// int max1 = Max(a1, b1, c1);
// int max1 = Max(a2, b2, c2);
// int max1 = Max(a3, b3, c3);

// int max = Max(max1, max2, max3);

// Перепишем результирующий вариант
// вместо того, чтобы использовать дополнительные переменные, внутри аргумента передадим функцию

int max = Max(
Max(a1, b1, c1),
Max(a2, b2, c2),
Max(a3, b3, c3));
Console.WriteLine(max);

// МАССИВЫ

// Найдем максимальный элемент массива.
// Нам требуется определить массив. Пишем int, затем ставим квадратные скобки, даём какое-то
// наименование и после этого перечисляем значения, которые хотим использовать

int[] array = { 11, 21, 31, 41, 15, 61, 17, 18, 19 };

// Технически мы можем воспользоваться уже описанным функционалом. Сделаем это так же,
// как в предыдущем примере, то есть укажем функцию. Далее трижды вызываем array 0, array
// 1 и array 2. После этого ставим запятую, здесь уже появляются автоматические подсказки:

int maxArr = Max(
Max(array[0], array[1], array[2]),
Max(array[3], array[4], array[5]),
Max(array[6], array[7], array[8])
);

Console.WriteLine(maxArr);

// ЗАДАЧА

// Допустим, у нас есть массив array, в котором n элементов. Найдём элемент, совпадающий с
// некоторым значением, который определяет пользователей.

int[] arrayNew = { 1, 12, 31, 4, 15, 16, 17, 18 };
int n = arrayNew.Length;
int find = 4;
int index = 0;

while (index < n)
{
    if (arrayNew[index] == find)
    {
        Console.WriteLine(index);
        break;
    }
    index++;
}

// СИНТАКСИС ЯЗЫКА

// В примере выше мы указывали значение массива вручную. А сейчас перепишем этот код с
// использованием генератора псевдослучайных чисел с использованием методов. Мы
// потренируем то, каким образом можно взять, например, метод, передать в него массив и
// заполнить массив нужным количеством элементов. На следующем этапе опишем метод,
// который будет выводить все элементы по порядку. Затем превратим наш код поиска нужного
// индекса в метод.

// Сначала определим новый массив. Пусть это будет массив под именем array. Далее укажем,
// что в этом массиве будет по умолчанию 10 элементов. Запомним новую конструкцию new int
// [10], которая дословно означает «создай новый массив, где будет 10 элементов». По
// умолчанию, кстати, он будет наполнен нулями.

int[] array2 = new int[10];

void FillArray(int[] collection)
{
    int length = collection.Length;
    int index = 0;
    while (index < length)
    {
        collection[index] = new Random().Next(1, 10);
        //index = index + 1;
        index++;
    }
}

void PrintArray(int[] col)
{
    int count = col.Length;
    int position = 0;
    while (position < count)
    {
        Console.WriteLine(col[position]);
        position++;
    }
}

FillArray(array2);
PrintArray(array2);

// ЗАДАЧА

// Мы попробовали написать свои первые методы: метод заполнения массива и метод его
// печати на экран. Теперь попробуем адаптировать решение предыдущей задачи, в которой
// находили нужные элементы и позицию нужного элемента в массиве.

int IndexOf(int[] collection, int find)
{
    int count = collection.Length;
    int index = 0;
    int position = -1; //искусственный прием. Если элемент не найдется, выведет позицию (индекс) -1
    while (index < count)
    {
        if (collection[index] == find)
        {
            position = index;
            break;
        }
        index++;
    }
    return position;
}

int pos = IndexOf(array2, 4);
Console.WriteLine(pos);