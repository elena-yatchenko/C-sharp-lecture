// СТРОКИ

// Строка - неизменяемый тип данных (не может быть изменен размер, не могут быть изменены элементы)
// Для изменений нужно создавать новую строку

// СОЗДАНИЕ СТРОК В С#

//!!!!! Данные типа string пишем в двойных кавычках "", а данные типа char - в одинарных ''.
string s1 = "hello";

char[] ch_array = { 'w', 'o', 'r', 'l', 'd' };
string s2 = new String(ch_array);

string s3 = new String('a', 6); // результатом будет строка "aaaaaa";

// МЕТОДЫ СТРОК В С#endregion
//Contains - Определяет, содержится ли подстрока в строке
// EndsWith - Определяет, совпадает ли конец строки с подстрокой (определение расширения файла, например)
// IndexOf - Находит индекс первого вхождения символа или подстроки в строке
// Insert - Вставляет в строку подстроку
// Replace - Замещает в строке символ или подстроку другим символом или подстрокой

// Методы Insert и Replace НЕ измеряют текущую строку, а создают новую, которая присваивается новой переменной

// ЗАДАЧА 3

// Считать из консоли строку, состоящую из цифр и латинский букв
// Сформировать новую строку, состоящую из букв исходной строки

string GetLetters(string str)
{
    string letters = "";
    foreach (char s in str)
    {
        if (char.IsLetter(s) == true)
        {
            letters = letters + s;
        }
    }
    return letters;
}

string text = Console.ReadLine();
string result = GetLetters(text);
System.Console.WriteLine(result);


// пример использования оператора CONTINUE

for (int i = 1; i <= 5; i++)
{
    System.Console.Write($"Iteration {i}: ");
    if (i == 3)
    {
        System.Console.WriteLine("Skip");
        continue;
    }
    System.Console.WriteLine("Some processing");
}