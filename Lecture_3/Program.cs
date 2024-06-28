﻿// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// // МЕТОДЫ
// // Функции в программировании.
// // Мы знаем о том, что любой метод, как правило, имеет возвращаемый тип. Также у любого
// // метода есть идентификатор или имя, набор аргументов и тело метода. Сегодня настало время
// // разобраться, что значит, метод что-то возвращает или возвращает void. Что же это за void
// // такой?
// // ● Первая группа методов — не принимает никаких аргументов и ничего не возвращают.

// void Metod1()
// {
//     Console.WriteLine("Автор …");
// }

// // Вызов метода:

// Metod1(); // где Metod1, является идентификатором метода.

// // ● Вторая группа методов — принимает какие-то аргументы, но ничего не возвращают.

// void Metod2(string msg) // где void ключевое слово, дальше идентификатор, в скобках
// // указаны какие-то аргументы.
// {
//     Console.WriteLine(msg); //оператор, в скобках указан принятый аргумент.
// }
// Metod2("Текст сообщения"); //где Metod2 является идентификатором, а в скобках указан текст, выводимый в консоли.

// // Эти две группы — так называемые void методы, которые ничего не возвращают.

// // ● Третья группа методов — может что-то возвращать, но не принимает никаких
// // аргументов. Например, может служить для генерации случайных данных.
// // Если метод что-то возвращает, мы в обязательном порядке должны указать тип данных, 
// // значение которого ожидаем.

// int Metod3() // не принимает никакие аргументы
// {
//     return DataTime.Now.Year; // обязательное использование оператора return,
// }
// int year = Metod3(); // вызываем метод, в левой части используем идентификатор
// // переменной (year) и через оператор присваивания (=) кладём нужное значение
// Console.WriteLine(year);

// // В дальнейшем используем переменную year, и то значение, которое нам вернул метод. То есть
// // return DataTime.Now.Year провёл какую-то работу и в переменную year будет положен
// // результат работы метода, дальше мы можем его использовать.

// // ● Четвёртая группа методов — самая важная группа методов. Что-то принимает (аргументы, данные), и что-то
// // возвращает для дальнейшей работы.
// string Metod4(int count, string text)
// {
//     int i = 0;
//     string result = String.Empty;
//     while (i < count)
//     {
//         result = result + text;
//         i++;
//     }
//     return result;
// }
// string res = Metod4(10, "asdf");
// Console.WriteLine(res);

// // ИМЕНОВАННЫЕ АРГУМЕНТЫ


// void Metod21(string msg, int count)
// {
//     int i = 0;
//     while (i < count)
//     {
//         Console.WriteLine(msg); // где переменная count отображает на экране определённое количество сообщений msg.
//         i++;
//     }
// }
// // Metod21("Текст", 4); // метод вызывает Текст, после запятой указано количество вызовов, в нашем случае 4.

// // // Здесь будет использоваться значение переменной count, чтобы показывать на экране
// // // определённое количество сообщений, которые будут передаваться непосредственно в наш метод.
// // // Теперь идея в том, что мы можем в том числе явно указывать к какому аргументу, какое
// // // значение мы хотим присвоить, через такую конструкцию.

// Metod21(msg: "Текст", count: 4);

// // // Явно указывая наименование аргумента, не обязательно писать их по порядку.
// Metod21(count: 4, msg: "Текст");

// Увеличение счётчика на 1 называют инкрементом, а уменьшение на 1 - декрементом

// Цикл FOR

// Поправим наш 4 метод, который был завязан на цикле while

string Metod4(int count, string text)
{
    string result = String.Empty;
    for (int i = 0; i < count; i++) // вначале ключевое слово, затем инициализация
                                    // счётчика, после проверка условия и инкремент (увеличение счётчика).
    {
        result = result + text;
    }
    return result;
}
string res = Metod4(10, "asdf");
Console.WriteLine(res);

// ЦИКЛ В ЦИКЛЕ

// Классической демонстрацией использования циклов в цикле я предлагаю рассмотреть задачу
// вывода таблицы умножения на экран. Итак, идея следующая.

// for (int i = 2; i <= 10; i++)
// {
//     for (int j = 2; j <= 10; j++)
//     {
//         Console.WriteLine($"{i} * {j} = {i * j}");
//     }
//     Console.WriteLine();
// }

// У нас есть цикл for, он очень легко строится. Дальше, мы указываем начальное значение.
// Таблица умножения начинается с 2. Затем говорим, что пока счётчик i меньше или равен 10,
// надо его увеличивать. После возьмём второй цикл, обратите внимание, что в первом
// (внешнем) цикле использовался счётчик i, значит, внутренний будет j, который мы также
// будем менять. Например, от 2 до меньше или равен 10. А телом второго цикла мы укажем
// непосредственное произведение. Сделать это можно различными способами. Я использую
// интерполяцию строк.

// ЗАДАЧА

// Дан текст. В нём нужно все пробелы заменить чёрточками, маленькие буквы «к»
// заменить большими «К», а большие «С» заменить на маленькие «с».

string text = "— Я думаю, — сказал князь, улыбаясь, — что,"
+ "ежели бы вас послали вместо нашего милого Винценгероде,"
+ "вы бы взяли приступом согласие прусского короля."
+ "Вы так красноречивы. Вы дадите мне чаю?";

string Replace(string text, char oldValue, char newValue)
{
    string result = String.Empty;
    int length = text.Length;
    for (int i = 0; i < length; i++)
    {
        if (text[i] == oldValue) result = result + $"{newValue}";
        else result = result + $"{text[i]}";
    }
    return result;
}

// string newText = Replace(text, ' ', '|');
// Console.WriteLine(newText);
// Console.WriteLine();
// newText = Replace(text, 'к', 'К');
// Console.WriteLine(newText);

// Упорядочить массивы

//Напишем код
int[] arr = { 1, 5, 4, 3, 2, 6, 7, 1, 1 };
void PrintArray(int[] array)
{
    int count = array.Length;
    for (int i = 0; i < count; i++)
    {
        Console.Write($"{array[i]}");
    }
    Console.WriteLine();
}
PrintArray(arr);


void SelectionSort(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int minPosition = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] < array[minPosition])
            {
                minPosition = j;
            }
        }
        int temporary = array[i];
        array[i] = array[minPosition];
        array[minPosition] = temporary;
    }
}

SelectionSort(arr);
PrintArray(arr);
