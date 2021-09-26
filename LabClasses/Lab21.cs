using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Labs
{
    public static class Lab21
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
            Console.WriteLine("Ответы на лабораторную 21");

            Console.WriteLine("Задание 1 (вывести элементы матрицы по часовой стрелке): ");

            Matrix<float> _matrix1;

            _matrix1.values = new float[,]
            {
                { 3,    5,   6,    11,   20 },

                { 634, 435, 543,  131,   55 },

                { 43,  342,  6,    11,   4 },

                { 53,  435, 3456,  345,  43 },

                { 673, 534,  46,  1341,  20 },
            };


            float[] _result1 = GetAnswerToExercise1(_matrix1);
            WriteArray(_result1);
            Console.WriteLine();

            Console.WriteLine("Задание 2 (найти сумму и произведение K строки матрицы): ");

            Matrix<float> _matrix2;

            _matrix2.values = new float[,]
            {
                { 3,    5,   6,    11,   20 },

                { 634, 435, 543,  131,   55 },

                { 43,  342,  6,    11,   4 },

                { 53,  435, 3456,  345,  43 },
            };

            float _sum;
            float _multiplicationResult;

            GetAnswerToExercise2(3, _matrix2, out _sum, out _multiplicationResult);

            Console.WriteLine($"Сумма: {_sum}");
            Console.WriteLine($"Произведение: {_multiplicationResult}");


            Console.WriteLine();

            Console.WriteLine("Задание 3 (найти столбец с наименьшим произведением): ");

            Matrix<float> _matrix3;

            _matrix3.values = new float[,]
            {
                { 3,    5,   6,    11,   20 },

                { 634, 435, 0,  131,   55 },

                { 43,  342,  6,    11,   4 },

                { 53,  435, 3456,  345,  43 },
            };

            float _nNumber;

            GetAnswerToExercise3(_matrix3, out _nNumber, out _multiplicationResult);

            Console.WriteLine($"Номер столбца: {_nNumber}");
            Console.WriteLine($"Произведение: {_multiplicationResult}");

            Console.WriteLine();


            Console.WriteLine("Задание 4 (в каждом столбце найти кол-во элементов, которые больше среднего арифметического этого столбца): ");

            Matrix<float> _matrix4;

            _matrix4.values = new float[,]
            {
                { 3,    5,   6,    11,   20 },

                { 634, 435, 0,  131,   55 },

                { 43,  342,  6,    11,   4 },

                { 53,  435, 3456,  345,  43 },
            };


            int[] _count = GetAnswerToExercise4(_matrix4);

            WriteArray(_count);

            Console.WriteLine();

            Console.WriteLine("Задание 5 (найти номер первого из столбцов матрицы, содержащего только нечетные числа): ");

            Matrix<float> _matrix5;

            _matrix5.values = new float[,]
            {
                { 3,    5,   6,    11,   20 },

                { 634, 435, 0,  131,   55 },

                { 43,  342,  6,    11,   4 },

                { 53,  435, 3456,  345,  43 },
            };


            Console.WriteLine(GetAnswerToExercise5(_matrix5));


            Console.WriteLine();

        }

        public static T[] GetAnswerToExercise1<T>(Matrix<T> _matrix)
        {
            List<T> _result = new List<T>();


            int _currentM = 0;
            int _currentN = 0;

            for (int _count = 0; _count < _matrix.M / 2; _count++)
            {
                for (int m = 0 + _count; m < _matrix.M - _count; m++)
                {
                    _currentN = _count;
                    _currentM = m;
                    _result.Add(_matrix[_currentM, _currentN]);
                }

                for (int n = 0 + _count + 1; n < _matrix.N - _count; n++)
                {
                    _currentN = n;
                    _result.Add(_matrix[_currentM, _currentN]);
                }

                for (int m = _currentM - 1; m >= 0 + _count; m--)
                {
                    _currentM = m;
                    _result.Add(_matrix[_currentM, _currentN]);
                }

                for (int n = _currentN - 1; n >= 1 + _count; n--)
                {
                    _currentN = n;
                    _result.Add(_matrix[_currentM, _currentN]);
                }
            }

            _result.Add(_matrix[_matrix.M / 2, _matrix.N / 2]);

            return _result.ToArray();

        }

        public static void GetAnswerToExercise2(int K, Matrix<float> _matrix, out float _sum, out float _multiplicationResult)
        {
            K--;

            _sum = 0;
            _multiplicationResult = 1;

            for (int n = 0; n < _matrix.N; n++)
            {
                _sum += _matrix[K, n];
                _multiplicationResult *= _matrix[K, n];
            }
        }
        public static void GetAnswerToExercise3(Matrix<float> _matrix, out float _nNumber, out float _multiplicationResult)
        {
            //Item1 - индекс столбца, Item2 - произведениие элементов
            (int, float) _result = new(0, 99999999);

            for (int n = 0; n < _matrix.N; n++)
            {
                float _tempMultiplicationResult = 1;
                for (int m = 0; m < _matrix.M; m++) _tempMultiplicationResult *= _matrix[m, n];
                if (_tempMultiplicationResult < _result.Item2)
                {
                    _result.Item1 = n;
                    _result.Item2 = _tempMultiplicationResult;
                }
            }
            _nNumber = _result.Item1 + 1;
            _multiplicationResult = _result.Item2;

        }

        public static int[] GetAnswerToExercise4(Matrix<float> _matrix)
        {
            int[] _result = new int[_matrix.N];

            for (int n = 0; n < _matrix.N; n++)
            {
                float _average = 0;

                for (int m = 0; m < _matrix.M; m++) _average += _matrix[m, n];
                _average /= _matrix.M;

                for (int m = 0; m < _matrix.M; m++) if (_matrix[m, n] > _average) _result[n]++;
            }
            return _result;
        }
        public static int GetAnswerToExercise5(Matrix<float> _matrix)
        {

            for (int n = 0; n < _matrix.N; n++)
            {
                bool _isCorrect = true;
                for (int m = 0; m < _matrix.M; m++)
                {
                    if (_matrix[m, n] % 2 == 0)
                    {
                        _isCorrect = false;
                        break;
                    }
                }
                if(_isCorrect) return n + 1;
            }


            return 0;
        }
    }

}
