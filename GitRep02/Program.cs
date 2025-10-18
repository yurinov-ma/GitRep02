using System;

class Program
{
    // Процедура для проверки, содержит ли строка только строчные буквы русского алфавита
    static bool ContainsOnlyLowercaseLetters(char[] row)
    {
        foreach (char c in row)
        {
            // Проверяем, что символ - строчная буква русского алфавита
            if (!(c >= 'а' && c <= 'я'))
            {
                return false;
            }
        }
        return true;
    }

    // Процедура для обработки массива и вывода номеров строк со строчными буквами
    static void ProcessArray(char[,] array, string arrayName)
    {
        Console.WriteLine($"\nОбработка массива {arrayName}:");

        bool hasLowercaseRows = false;
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        // Создаем временный массив для хранения элементов текущей строки
        char[] currentRow = new char[cols];

        for (int i = 0; i < rows; i++)
        {
            // Копируем элементы текущей строки во временный массив
            for (int j = 0; j < cols; j++)
            {
                currentRow[j] = array[i, j];
            }

            // Проверяем строку с помощью процедуры
            if (ContainsOnlyLowercaseLetters(currentRow))
            {
                Console.WriteLine($"Строка {i + 1} не содержит заглавных букв");
                hasLowercaseRows = true;
            }
        }

        if (!hasLowercaseRows)
        {
            Console.WriteLine($"В массиве {arrayName} нет строк, содержащих только строчные буквы");
        }
    }

    static void Main(string[] args)
    {
        // Примеры массивов (можно заменить на ввод с клавиатуры)
        char[,] array1 = {
            { 'а', 'б', 'в', 'г' },
            { 'Д', 'е', 'ж', 'з' },
            { 'и', 'й', 'к', 'л' },
            { 'м', 'н', 'о', 'п' }
        };

        char[,] array2 = {
            { 'А', 'Б', 'В', 'Г' },
            { 'Д', 'Е', 'Ж', 'З' },
            { 'р', 'с', 'т', 'у' },
            { 'ф', 'х', 'ц', 'ч' }
        };

        // Обработка первого массива
        ProcessArray(array1, "№1");

        // Обработка второго массива
        ProcessArray(array2, "№2");

        // Проверка, есть ли хотя бы в одном массиве строки со строчными буквами
        bool anyLowercaseRows = CheckAnyArrayHasLowercaseRows(array1, array2);

        if (!anyLowercaseRows)
        {
            Console.WriteLine("\nСообщение: Ни в одном массиве нет строк, содержащих только строчные буквы");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    // Дополнительная функция для проверки, есть ли хотя бы в одном массиве строки со строчными буквами
    static bool CheckAnyArrayHasLowercaseRows(char[,] array1, char[,] array2)
    {
        return CheckArrayHasLowercaseRows(array1) || CheckArrayHasLowercaseRows(array2);
    }

    static bool CheckArrayHasLowercaseRows(char[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        char[] currentRow = new char[cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                currentRow[j] = array[i, j];
            }

            if (ContainsOnlyLowercaseLetters(currentRow))
            {
                return true;
            }
        }
        return false;
    }
}