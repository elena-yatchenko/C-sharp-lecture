﻿// Закрашивание замкнутой области

// Идея: 
// обычная прямоугольная таблица чисел, для которых вы можете определить в качестве 0 незакрашенный
// пиксель, а в качестве 1 — закрашенный. Это абсолютно прямая отсылка к двумерным числовым массивам. 
// Если мы посмотрим только на единицы, увидим палец вверх - лайк

// Итак, допустим, мы договорились, что у нас есть прямоугольная таблица чисел. В ней 23 строки и 25
// столбцов. 0 — незакрашенный пиксель, 1 — закрашенный. Как же закрасить область?
// Для этого определяем какую-то точку, которая находится внутри замкнутого контура. 

// После этого нам надо определиться с тем, как мы будем делать обход внутренних точек. Если мы
// попали в точку, и эта точка не закрашена, мы её закрашиваем. Далее определяем правило обхода. В
// моём случае правило такое — сначала идём вверх, потом влево, потом вниз и вправо. 

// Итак, мы остановились на точке. Дальше смотрим на точку выше. 
// Если она не закрашена, мы её красим. От неё же смотрим на точку выше. Если она не закрашена,
// красим. И так пока не встретим закрашенную точку. 

// Дальше по правилу обхода смотрим на точку слева. Если бы её можно было закрасить, мы бы
// закрасили. Но в нашем случае снова попадаем на контур. Следующая по порядку точка ниже. Она тоже
// закрашена — не красим. Идём в последнее правое направление. Точка не закрашена — красим. 

// Затем для текущей точки повторяем все те же действия: идём вверх, если можно, красим, если нельзя
// — не красим. Двигаемся дальше по правилу. 

// Давайте формально опишем шаги влево, вверх, вправо и вниз. Если мы находимся в текущей точке с
// координатами x, y (в данном случае x — позиция строчки, а y — столбца), движение будет выглядеть
// таким образом:

// x-1, y - на шаг верх (минус строка)
// x, y-1- на шаг влево (минус столбец)
// x, y - текущая точка
// x+1, y - на шаг вниз (плюс строка)
// x, y+1 - на шаг вправо (плюс столбец)

// Далее мы должны определить порядок действий. Я договариваюсь ходить сначала вверх, потом
// влево, вниз и вправо. Всё ровно так, как на примере с закрашиванием пикселей.

// Теперь давайте попробуем написать код, который позволит нам взять картинку и закрасить область
// внутри контура. 
// Не обязательно указывать количество строк и столбцов, если у вас есть фиксированные данные.

int[,] pic = new int[,]
{
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
{0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
};

void PrintImage(int[,] image)
{
    for (int i = 0; i < image.GetLength(0); i++)
    {
        for (int j = 0; j < image.GetLength(1); j++)
        {
            if (image[i, j] == 0) Console.Write($" ");
            else Console.Write($"+");
        }
        Console.WriteLine();
    }
}
PrintImage(pic);

// Дальше предлагаю описать метод, который будет закрашивать картинку. По аналогии назовём его
// FillImage. А в качестве аргумента я укажу позицию строки и пикселя, с которого мы должны будем
// начать закраску. Дальше я проверяю условие: если текущий пиксель (pic) с указанной позицией (row,
// col) равен нулю (то есть не закрашен), я буду его красить единичкой. А дальше вызову FillImage. И
// здесь мы определяем правило — что за чем идёт. Сначала поднимаемся на строчку выше (row-1, col),
// потом идём влево (row, col-1), потом вниз (row+1, col), потом вправо (row, col+1). 

void FillImage(int row, int col)
{
    if (pic[row, col] == 0)
    {
        pic[row, col] = 1;
        FillImage(row - 1, col);
        FillImage(row, col - 1);
        FillImage(row + 1, col);
        FillImage(row, col + 1);
    }
}
PrintImage(pic);
FillImage(13, 13);
PrintImage(pic);

// Давайте попробуем посмотреть, к чему нас это приведёт. В качестве случайной точки я указал (13, 13).
// Очищу терминал и запущу по новой. 