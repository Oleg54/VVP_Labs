using System;

namespace Labs
{
    public static class Lab24
    {
        //Метод для вывода результатов, вызывается из класса Program
        public static void WriteAllExercises()
        {
            Console.WriteLine();
            Console.WriteLine("Ответы на лабораторную 24");

            Console.Write("Задание 1 (Найти кол-во слов в строке): ");
            Console.WriteLine(GetAnswerToExercise1("Сегодня,     разглядывая  на снегу   следы зверушек    и птиц, вот что    я  по    этим следам     прочитал"));

            Console.Write("Задание 2 (Найти длину самого короткого слова): ");
            Console.WriteLine(GetAnswerToExercise2("Сегодня,     разглядывая  на снегу   следы зверушек    и птиц, вот что    я  по    этим следам     прочитал"));

            Console.Write("Задание 3 (Заменить все вхождения первой буквы слова на .): ");
            Console.WriteLine(GetAnswerToExercise3("МИНИМАЛЬНЫЙ МИНИМУМ МАКСИМАЛЬНЫЙ МАКСИМУМ"));

            Console.Write("Задание 4 (Подсчитать кол-во гласных букв): ");
            Console.WriteLine(GetAnswerToExercise4("Солнечный день в самом начале лета"));

            Console.Write("Задание 5 (Выделить имя файла из его полного пути): ");
            Console.WriteLine(GetAnswerToExercise5("C:\\Windows\\DiagTrack\\analyticsevents.dat"));

            Console.Write("Задание 6 (Выделить из полного пути файла последний каталог, в котором находится файл): ");
            Console.WriteLine(GetAnswerToExercise6("C:\\Windows\\DiagTrack\\analyticsevents.dat"));

            Console.Write("Задание 7 (Зашифровать строку): ");
            Console.WriteLine(GetAnswerToExercise7("Программа"));
        }

        //Возвращает строку, в которой удалены двойные пробелы
        private static string DeleteDoubleSpaces(this string _input)
        {
            string _result = "";
            for (int i = 0; i < _input.Length; i++)
            {
                if (_input[i] != ' ') _result += _input[i];
                else if (i > 0 && _input[i - 1] != ' ') _result += _input[i];

            }
            return _result;
        }

        //Проверяет, является ли буква гласной
        private static bool CharacterIsVowel(this char _input)
        {
            string _vowels = "аеёиоуыэюя";
            for (int i = 0; i < _vowels.Length; i++) if (_input == _vowels[i]) return true;
            return false;
        }


        public static int GetAnswerToExercise1(string _input)
        {
            int _wordCount = 0;

            for (int i = 0; i < _input.Length; i++)
            {
                if (_input[i] != ' ')
                {
                    if (i == 0) _wordCount++;
                    else if (_input[i - 1] == ' ') _wordCount++;
                }
            }
            return _wordCount;

        }

        public static int GetAnswerToExercise2(string _input)
        {
            _input += " ";
            _input = _input.DeleteDoubleSpaces();

            int _minLength = 100000;

            int _currentLength = 0;

            for (int i = 0; i < _input.Length; i++)
            {
                if (_input[i] != ' ') _currentLength++;
                else
                {
                    if (_currentLength < _minLength) _minLength = _currentLength;
                    _currentLength = 0;
                }
            }
            return _minLength;
        }

        public static string GetAnswerToExercise3(string _input)
        {
            string _result = "";

            string _firstCharacter = "";
            for (int i = 0; i < _input.Length; i++)
            {

                if (_firstCharacter == "")
                {
                    if (_input[i] != ' ') _firstCharacter = _input[i].ToString();
                    _result += _input[i];
                }
                else
                {
                    if (_input[i] == ' ')
                    {
                        _firstCharacter = "";
                        _result += _input[i];
                    }
                    else
                    {
                        if (_firstCharacter == _input[i].ToString()) _result += ".";
                        else _result += _input[i];
                    }
                }

            }

            return _result;
        }

        public static int GetAnswerToExercise4(string _input)
        {
            int _count = 0;
            for (int i = 0; i < _input.Length; i++) if (_input[i].CharacterIsVowel()) _count++;
            return _count;
        }

        public static string GetAnswerToExercise5(string _input)
        {
            string _fileName = "";

            int _startIndex = 0;
            int _finalIndex = 0;

            for (int i = _input.Length - 1; i >= 0; i--)
            {
                if (_input[i] == '.') _finalIndex = i;
                if (_input[i] == '/' || _input[i] == '\\')
                {
                    _startIndex = i;
                    break;
                }
            }

            for (int i = _startIndex + 1; i < _finalIndex; i++) _fileName += _input[i];

            return _fileName;
        }

        public static string GetAnswerToExercise6(string _input)
        {
            string _catalogName = "";

            int _startIndex = 0;
            int _finalIndex = 0;

            int _slashCount = 0;

            for (int i = _input.Length - 1; i >= 0; i--)
            {
                if (_input[i] == '/' || _input[i] == '\\')
                {
                    if (_slashCount == 0)
                    {
                        _finalIndex = i;
                        _slashCount++;
                    }
                    else
                    {
                        _startIndex = i;
                        break;
                    }
                }
            }

            if (_startIndex == 0) return "\\";
            else
            {
                for (int i = _startIndex + 1; i < _finalIndex; i++) _catalogName += _input[i];
                return _catalogName;
            }

        }

        public static string GetAnswerToExercise7(string _input)
        {
            string _result = "";

            string _oddCharacters = "";
            //индексация начинается с 0, значит четными будут элементы с индексами 1, 3, 5...
            for (int i = 1; i < _input.Length; i += 2) _result += _input[i];
            //нечетными будут элементы с индексами 0, 2, 4...
            for (int i = 0; i < _input.Length; i += 2) _oddCharacters += _input[i];

            for (int i = _oddCharacters.Length - 1; i >= 0; i--) _result += _oddCharacters[i];

            return _result;
        }
    }
}
