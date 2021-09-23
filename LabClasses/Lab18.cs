using System;
using System.Collections.Generic;

namespace Labs
{
    public static class Lab18
    {

        private static void WriteArray<T>(T[] _array)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write(_array[i]);
                if (i < _array.Length - 1) Console.Write(", ");
            }
        }

        //Метод для вывода результатов, вызывается из класса Program
        public static void WriteAllExercises()
        {
            Console.WriteLine();
            Console.WriteLine("Ответы на лабораторную 18");


            Console.WriteLine("Задание 1 (поменять местами элементы двух массивов и вывести сначала первый, затем второй): ");

            int[] _arrayA = new int[] { 2, 4, 5, 7, 8, 12 };
            int[] _arrayB = new int[] { 34, 29, 26, 20, 21, 15 };

            GetAnswerToExercise1(ref _arrayA, ref _arrayB);

            WriteArray(_arrayA);
            Console.WriteLine();
            WriteArray(_arrayB);
            Console.WriteLine();

            Console.WriteLine("Задание 2 (сформировать новый массив по правилу): ");

            float[] _array = new float[] { 1, 3, 4, 5.3f, 3.02f, 2 };
            WriteArray(GetAnswerToExercise2(_array));

            Console.WriteLine();

            Console.WriteLine("Задание 3 (прибавить ко всем нечетным элементам массива последний нечетный элемент): ");
            int[] _array3 = new int[] { 2, 4, 5, 7, 8, 12 };

            WriteArray(GetAnswerToExercise3(_array3));
            Console.WriteLine();

            Console.WriteLine("Задание 4 (обнулить все элементы между минимальным и максимальным элементами): ");
            int[] _array4 = new int[] { 3, 1, 5, 7, 83, 12 };

            WriteArray(GetAnswerToExercise4(_array4));

            Console.WriteLine();

            Console.WriteLine("Задание 5 (переместить начальный элемент в правильную позицию, чтобы массив был отсортирован): ");
            int[] _array5 = new int[] { 9, 1, 5, 7, 12, 21 };

            WriteArray(GetAnswerToExercise5(_array5));

            Console.WriteLine();
        }

        public static void GetAnswerToExercise1<T>(ref T[] A, ref T[] B)
        {
            for (int i = 0; i < A.Length; i++)
            {
                T _temp = A[i];
                A[i] = B[i];
                B[i] = _temp;
            }
        }

        public static float[] GetAnswerToExercise2(float[] _input)
        {
            float[] _result = new float[_input.Length];

            for (int i = 0; i < _result.Length; i++)
            {
                float _average = 0;

                for (int x = 0; x <= i; x++) _average += _input[x];
                _average /= i + 1;
                _result[i] = _average;
            }
            return _result;
        }
        public static int[] GetAnswerToExercise3(int[] _input)
        {
            int _lastOddNumber;

            //вычисление последнего нечетного элемента
            if (_input.Length % 2 == 1) _lastOddNumber = _input[_input.Length - 1];
            else _lastOddNumber = _input[_input.Length - 2];

            //нечетные элементы имеют индексы 0, 2, 4...
            for (int i = 0; i < _input.Length; i += 2) _input[i] += _lastOddNumber;

            return _input;
        }
        public static int[] GetAnswerToExercise4(int[] _input)
        {
            int _minNumberIndex = 0;
            int _maxNumberIndex = 0;

            for (int i = 0; i < _input.Length; i++)
            {
                if (_input[i] < _input[_minNumberIndex]) _minNumberIndex = i;
                if (_input[i] > _input[_maxNumberIndex]) _maxNumberIndex = i;
            }

            (int, int) _indexes = new(_minNumberIndex, _maxNumberIndex);
            if (_minNumberIndex > _maxNumberIndex) _indexes = new(_maxNumberIndex, _minNumberIndex);

            for (int i = _indexes.Item1 + 1; i < _indexes.Item2; i++) _input[i] = 0;

            return _input;
        }

        public static int[] GetAnswerToExercise5(int[] _input)
        {
            List<int> _result = new List<int>();

            for (int i = 1; i < _input.Length; i++) _result.Add(_input[i]);
            for (int i = 0; i < _result.Count; i++)
            {
                if (_input[0] < _result[i])
                {
                    _result.Insert(i, _input[0]);
                    break;
                }

            }
            return _result.ToArray();
        }
    }
}