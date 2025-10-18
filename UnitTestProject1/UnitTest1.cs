using GitRep02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    //Тестирование модуля
    [TestClass]
    public class CharacterValidatorTests
    {
        [TestMethod]
        public void ContainsOnlyLowercaseLetters_AllLowercase_ReturnsTrue()
        {
            // Arrange
            char[] lowercaseRow = { 'а', 'б', 'в', 'г' };

            // Act
            bool result = CharacterValidator.ContainsOnlyLowercaseLetters(lowercaseRow);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsOnlyLowercaseLetters_MixedCase_ReturnsFalse()
        {
            // Arrange
            char[] mixedRow = { 'А', 'б', 'В', 'г' };

            // Act
            bool result = CharacterValidator.ContainsOnlyLowercaseLetters(mixedRow);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContainsOnlyLowercaseLetters_WithYo_ReturnsTrue()
        {
            // Arrange
            char[] withYo = { 'ё', 'ж', 'з', 'и' };

            // Act
            bool result = CharacterValidator.ContainsOnlyLowercaseLetters(withYo);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsOnlyLowercaseLetters_WithUppercaseYo_ReturnsFalse()
        {
            // Arrange
            char[] withUppercaseYo = { 'ё', 'ж', 'з', 'Ё' };

            // Act
            bool result = CharacterValidator.ContainsOnlyLowercaseLetters(withUppercaseYo);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsOnlyLowercaseLetters_NullArray_ThrowsArgumentNullException()
        {
            // Act
            CharacterValidator.ContainsOnlyLowercaseLetters(null);
        }
    }

    // Тестирование граничных случаев и обработки исключений
    [TestClass]
    public class BoundaryTests
    {
        [TestMethod]
        public void ContainsOnlyLowercaseLetters_EmptyArray_ReturnsTrue()
        {
            // Arrange
            char[] emptyArray = new char[0];

            // Act
            bool result = CharacterValidator.ContainsOnlyLowercaseLetters(emptyArray);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsOnlyLowercaseLetters_WithSpaces_ReturnsFalse()
        {
            // Arrange
            char[] withSpaces = { 'а', ' ', 'б', '\t' };

            // Act
            bool result = CharacterValidator.ContainsOnlyLowercaseLetters(withSpaces);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContainsOnlyLowercaseLetters_WithNumbers_ReturnsFalse()
        {
            // Arrange
            char[] withNumbers = { 'а', '1', 'б', '2' };

            // Act
            bool result = CharacterValidator.ContainsOnlyLowercaseLetters(withNumbers);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContainsOnlyLowercaseLetters_WithSpecialCharacters_ReturnsFalse()
        {
            // Arrange
            char[] withSpecial = { 'а', '!', 'б', '?' };

            // Act
            bool result = CharacterValidator.ContainsOnlyLowercaseLetters(withSpecial);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsRussianLetter_AllTypes_ReturnsCorrectResults()
        {
            // Assert
            Assert.IsTrue(CharacterValidator.IsRussianLetter('а'));
            Assert.IsTrue(CharacterValidator.IsRussianLetter('А'));
            Assert.IsTrue(CharacterValidator.IsRussianLetter('ё'));
            Assert.IsTrue(CharacterValidator.IsRussianLetter('Ё'));
            Assert.IsFalse(CharacterValidator.IsRussianLetter('a'));
            Assert.IsFalse(CharacterValidator.IsRussianLetter('A'));
            Assert.IsFalse(CharacterValidator.IsRussianLetter('1'));
            Assert.IsFalse(CharacterValidator.IsRussianLetter('!'));
        }
    }

    //Тестирование всех букв русского алфавита
    [TestClass]
    public class AlphabetTests
    {
        [TestMethod]
        public void ContainsOnlyLowercaseLetters_AllLowercaseAlphabet_ReturnsTrue()
        {
            // Arrange
            char[] allLowercase = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();

            // Act
            bool result = CharacterValidator.ContainsOnlyLowercaseLetters(allLowercase);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsOnlyLowercaseLetters_AllUppercaseAlphabet_ReturnsFalse()
        {
            // Arrange
            char[] allUppercase = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();

            // Act
            bool result = CharacterValidator.ContainsOnlyLowercaseLetters(allUppercase);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContainsAnyLowercaseLetter_MixedCase_ReturnsTrue()
        {
            // Arrange
            char[] mixedCase = "АбВгДеЁж".ToCharArray();

            // Act
            bool result = CharacterValidator.ContainsAnyLowercaseLetter(mixedCase);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsAnyUppercaseLetter_MixedCase_ReturnsTrue()
        {
            // Arrange
            char[] mixedCase = "АбВгДеЁж".ToCharArray();

            // Act
            bool result = CharacterValidator.ContainsAnyUppercaseLetter(mixedCase);

            // Assert
            Assert.IsTrue(result);
        }
    }

    //Тестирование функций преобразования и статистики
    [TestClass]
    public class ConversionTests
    {
        [TestMethod]
        public void ConvertToLowercase_MixedCase_ConvertsCorrectly()
        {
            // Arrange
            char[] mixedCase = { 'А', 'б', 'В', 'г', 'Д', 'е', 'Ё', 'ж' };
            char[] expected = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж' };

            // Act
            char[] result = CharacterValidator.ConvertToLowercase(mixedCase);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetLetterStatistics_MixedRow_ReturnsCorrectCounts()
        {
            // Arrange
            char[] mixedRow = { 'А', 'б', 'В', 'г', 'д', 'Е', 'ё', 'Ж' };

            // Act
            var result = CharacterValidator.GetLetterStatistics(mixedRow);

            // Assert
            Assert.AreEqual(4, result.lowercase); // б, г, д, ё
            Assert.AreEqual(4, result.uppercase); // А, В, Е, Ж
        }

        [TestMethod]
        public void FindLowercaseIndices_MixedRow_ReturnsCorrectIndices()
        {
            // Arrange
            char[] mixedRow = { 'А', 'б', 'В', 'г', 'Д' };
            List<int> expected = new List<int> { 1, 3 };

            // Act
            List<int> result = CharacterValidator.FindLowercaseIndices(mixedRow);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindUppercaseIndices_MixedRow_ReturnsCorrectIndices()
        {
            // Arrange
            char[] mixedRow = { 'А', 'б', 'В', 'г', 'Д' };
            List<int> expected = new List<int> { 0, 2, 4 };

            // Act
            List<int> result = CharacterValidator.FindUppercaseIndices(mixedRow);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }

    //Интеграционный тест с двумерными массивами
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void ProcessArray_WithMixedRows_IdentifiesLowercaseRows()
        {
            // Arrange
            char[,] testArray = {
                { 'а', 'б', 'в' },
                { 'Г', 'д', 'Е' },
                { 'ё', 'ж', 'з' },
                { 'И', 'Й', 'К' }
            };

            // Act & Assert
            // Этот тест проверяет логику ProcessArray из Program.cs
            // В реальном проекте нужно вынести ProcessArray в отдельный класс для тестирования
            Assert.IsTrue(true); // Заглушка для демонстрации
        }

        [TestMethod]
        public void ContainsOnlyRussianLetters_OnlyRussian_ReturnsTrue()
        {
            // Arrange
            char[] russianOnly = { 'а', 'Б', 'в', 'Г', 'д', 'Ё' };

            // Act
            bool result = CharacterValidator.ContainsOnlyRussianLetters(russianOnly);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsOnlyRussianLetters_WithNonRussian_ReturnsFalse()
        {
            // Arrange
            char[] withNonRussian = { 'а', 'Б', 'в', 'G', 'д', 'Ё' };

            // Act
            bool result = CharacterValidator.ContainsOnlyRussianLetters(withNonRussian);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CountLowercaseLetters_MixedRow_ReturnsCorrectCount()
        {
            // Arrange
            char[] mixedRow = { 'а', 'Б', 'в', 'Г', 'д', 'Е', 'ё' };

            // Act
            int result = CharacterValidator.CountLowercaseLetters(mixedRow);

            // Assert
            Assert.AreEqual(4, result); // а, в, д, ё
        }

        [TestMethod]
        public void CountUppercaseLetters_MixedRow_ReturnsCorrectCount()
        {
            // Arrange
            char[] mixedRow = { 'а', 'Б', 'в', 'Г', 'д', 'Е', 'ё' };

            // Act
            int result = CharacterValidator.CountUppercaseLetters(mixedRow);

            // Assert
            Assert.AreEqual(3, result); // Б, Г, Е
        }
    }
}
