using System;
using System.Collections.Generic;
using System.Linq;

namespace Labs
{
    public class Lab19
    {
        private static void WriteArray<T>(T[] _array)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write(_array[i]);
                if (i < _array.Length - 1) Console.Write(", ");
            }
        }

        public static void WriteAllExercises()
        {
            Console.WriteLine();
            Console.WriteLine("Ответы на лабораторную 19");

            Console.WriteLine("Задание 1 (удалить из массива все соседние одинаковые элементы, оставив их первые вхождения): ");
            int[] _array1 = new int[] { 3, 4, 4, 78, 55, 45, 45, 64, 2543, 543, 543, 43123423 };
            WriteArray(GetAnswerToExercise1(_array1));

            Console.WriteLine();

            Console.WriteLine("Задание 2 (удалить из массива все элементы, встречающиеся ровно два раза): ");
            int[] _array2 = new int[] { 3, 4, 4, 78, 55, 45, 45, 64, 2543, 543, 543, 543, 43123423, 3, 3, 3, 3 };
            _array2 = GetAnswerToExercise2(_array2);
            Console.WriteLine($"Длина массива: {_array2.Length}, состав массива: ");
            WriteArray(_array2);

            Console.WriteLine();

            Console.WriteLine("Задание 3 (вставить 0 перед минимальным и после максимального элементов): ");
            int[] _array3 = new int[] { 4, 55, 5, 2, 4643, 63, 454435 };
            WriteArray(GetAnswerToExercise3(_array3));

            Console.WriteLine();

            Console.WriteLine("Задание 4 (после каждого отрицательного элемента массива вставить элемент с нулевым значением): ");
            int[] _array4 = new int[] { 4, -55, 5, -2, -4643, 0, 454435, -34 };
            WriteArray(GetAnswerToExercise4(_array4));

            Console.WriteLine();

            Console.WriteLine("Задание 5 (перед каждым положительным элементом массива вставить элемент с нулевым значением): ");
            int[] _array5 = new int[] { 4, -55, 5, -2, -4643, 0, 454435, -34 };
            WriteArray(GetAnswerToExercise5(_array5));

        }


        public static int[] GetAnswerToExercise1(int[] _input)
        {
            List<int> _result = new List<int>();

            _result.Add(_input[0]);

            for (int i = 1; i < _input.Length; i++)
            {
                if (_input[i] != _input[i - 1]) _result.Add(_input[i]);
            }

            return _result.ToArray();
        }

        public static int[] GetAnswerToExercise2(int[] _input)
        {
            List<int> _result = new List<int>();

            for (int i = 0; i < _input.Length; i++)
            {

                int _coincidenceCount = 1;
                for (int x = 0; x < _input.Length; x++)
                {
                    if (x == i) continue;
                    if (_input[i] == _input[x]) _coincidenceCount++;
                }
                if (_coincidenceCount != 2) _result.Add(_input[i]);
            }

            return _result.ToArray();
        }

        public static int[] GetAnswerToExercise3(int[] _input)
        {
            List<int> _result = new List<int>();

            (int, int) _indexes = new(0, 0); // первый элемент - индекс минимального элемента, второй - максимального

            for (int i = 0; i < _input.Length; i++)
            {
                if (_input[_indexes.Item1] > _input[i]) _indexes.Item1 = i;
                if (_input[_indexes.Item2] < _input[i]) _indexes.Item2 = i;
            }

            for (int i = 0; i < _input.Length; i++)
            {
                if (i == _indexes.Item1) _result.Add(0);
                _result.Add(_input[i]);
                if (i == _indexes.Item2) _result.Add(0);
            }

            return _result.ToArray();
        }

        public static int[] GetAnswerToExercise4(int[] _input)
        {
            List<int> _result = new List<int>();

            for (int i = 0; i < _input.Length; i++)
            {
                _result.Add(_input[i]);
                if (_input[i] < 0) _result.Add(0);
            }

            return _result.ToArray();
        }
        public static int[] GetAnswerToExercise5(int[] _input)
        {
            List<int> _result = new List<int>();

            for (int i = 0; i < _input.Length; i++)
            {
                if (_input[i] > 0) _result.Add(0);
                _result.Add(_input[i]);
            }

            return _result.ToArray();
        }
    }
}