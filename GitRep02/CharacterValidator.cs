using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitRep02
{
    public static class CharacterValidator
    {
        // Константы для диапазонов русских букв
        private const char FIRST_LOWERCASE = 'а';
        private const char LAST_LOWERCASE = 'я';
        private const char FIRST_UPPERCASE = 'А';
        private const char LAST_UPPERCASE = 'Я';
        private const char LOWERCASE_YO = 'ё';
        private const char UPPERCASE_YO = 'Ё';

        public static bool ContainsOnlyLowercaseLetters(char[] row)
        {
            if (row == null)
                throw new ArgumentNullException(nameof(row), "Массив символов не может быть null");

            // Если массив пустой - считаем, что условие выполняется
            if (row.Length == 0)
                return true;

            foreach (char c in row)
            {
                if (!IsRussianLowercaseLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsRussianLowercaseLetter(char c)
        {
            return (c >= FIRST_LOWERCASE && c <= LAST_LOWERCASE) || c == LOWERCASE_YO;
        }

        public static bool IsRussianUppercaseLetter(char c)
        {
            return (c >= FIRST_UPPERCASE && c <= LAST_UPPERCASE) || c == UPPERCASE_YO;
        }

        public static bool IsRussianLetter(char c)
        {
            return IsRussianLowercaseLetter(c) || IsRussianUppercaseLetter(c);
        }

        public static int CountLowercaseLetters(char[] row)
        {
            if (row == null) return 0;

            int count = 0;
            foreach (char c in row)
            {
                if (IsRussianLowercaseLetter(c))
                {
                    count++;
                }
            }
            return count;
        }

        public static int CountUppercaseLetters(char[] row)
        {
            if (row == null) return 0;

            int count = 0;
            foreach (char c in row)
            {
                if (IsRussianUppercaseLetter(c))
                {
                    count++;
                }
            }
            return count;
        }

        public static bool ContainsAnyLowercaseLetter(char[] row)
        {
            if (row == null) return false;

            foreach (char c in row)
            {
                if (IsRussianLowercaseLetter(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ContainsAnyUppercaseLetter(char[] row)
        {
            if (row == null) return false;

            foreach (char c in row)
            {
                if (IsRussianUppercaseLetter(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static (int lowercase, int uppercase) GetLetterStatistics(char[] row)
        {
            if (row == null) return (0, 0);

            int lowercase = 0;
            int uppercase = 0;

            foreach (char c in row)
            {
                if (IsRussianLowercaseLetter(c))
                    lowercase++;
                else if (IsRussianUppercaseLetter(c))
                    uppercase++;
            }

            return (lowercase, uppercase);
        }

        public static char[] ConvertToLowercase(char[] row)
        {
            if (row == null) return null;

            char[] result = new char[row.Length];

            for (int i = 0; i < row.Length; i++)
            {
                result[i] = ToLowercase(row[i]);
            }

            return result;
        }

        public static char ToLowercase(char c)
        {
            if (c >= FIRST_UPPERCASE && c <= LAST_UPPERCASE)
            {
                // Сдвиг от заглавной к строчной в таблице Unicode
                return (char)(c + (FIRST_LOWERCASE - FIRST_UPPERCASE));
            }
            else if (c == UPPERCASE_YO)
            {
                return LOWERCASE_YO;
            }

            return c;
        }

        public static bool ContainsOnlyRussianLetters(char[] row)
        {
            if (row == null) return false;

            foreach (char c in row)
            {
                if (!IsRussianLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static List<int> FindLowercaseIndices(char[] row)
        {
            var indices = new List<int>();

            if (row == null) return indices;

            for (int i = 0; i < row.Length; i++)
            {
                if (IsRussianLowercaseLetter(row[i]))
                {
                    indices.Add(i);
                }
            }

            return indices;
        }

        public static List<int> FindUppercaseIndices(char[] row)
        {
            var indices = new List<int>();

            if (row == null) return indices;

            for (int i = 0; i < row.Length; i++)
            {
                if (IsRussianUppercaseLetter(row[i]))
                {
                    indices.Add(i);
                }
            }

            return indices;
        }

        public static string GenerateReport(char[] row)
        {
            if (row == null) return "Массив символов: null";

            var stats = GetLetterStatistics(row);
            bool onlyLowercase = ContainsOnlyLowercaseLetters(row);
            bool onlyUppercase = ContainsOnlyLowercaseLetters(ConvertToLowercase(row)) && row.Length > 0;
            bool onlyRussian = ContainsOnlyRussianLetters(row);

            return $"Отчет анализа строки:\n" +
                   $"Длина: {row.Length} символов\n" +
                   $"Строчные буквы: {stats.lowercase}\n" +
                   $"Заглавные буквы: {stats.uppercase}\n" +
                   $"Только строчные: {onlyLowercase}\n" +
                   $"Только заглавные: {onlyUppercase}\n" +
                   $"Только русские буквы: {onlyRussian}\n" +
                   $"Содержимое: {new string(row)}";
        }
    }
}
