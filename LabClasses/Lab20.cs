using System;
using System.Collections.Generic;
using System.Linq;

namespace Labs
{
    public class Lab20
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
            Console.WriteLine("Ответы на лабораторную 20");

            Console.WriteLine("Задание 1 (сформировать массивы B и C, записав с первый длины серий, а во второй значения серий): ");
            int[] _array1 = new int[] { 3, 4, 6, 5, 5, 5, 6, 6, 2, 3, 1, 1, 1, 1 };

            int[] _array1_B;
            int[] _array1_C;

            GetAnswerToExercise1(_array1, out _array1_B, out _array1_C);

            Console.Write("Длины серий: ");
            WriteArray(_array1_B);
            Console.WriteLine();
            Console.Write("Значения элементов серий: ");
            WriteArray(_array1_C);

            Console.WriteLine();


            Console.WriteLine("Задание 2 (заменить серии, длины которых больше L, на 0): ");
            int[] _array2 = new int[] { 3, 4, 4, 78, 55, 45, 45, 64, 2543, 543, 543, 543, 43123423, 3, 3, 3, 3 };
            _array2 = GetAnswerToExercise2(2, _array2);
            WriteArray(_array2);

            Console.WriteLine();

            Console.WriteLine("Задание 3 (поменять местами последнюю серию массива и его серию с номером K): ");
            int[] _array3 = new int[] { 3, 4, 4, 78, 55, 45, 45, 64, 2543, 543, 543, 543, 43123423, 3, 3, 3, 3 };
            WriteArray(GetAnswerToExercise3(0, _array3));

            Console.WriteLine();

            Console.WriteLine("Задание 4 (среди точек второй четверти найти наиболее отдаленную): ");
            Vector2[] _array4 = new Vector2[] 
            {
                new Vector2(1, 1.5f),
                new Vector2(3.4f, 3.8f),
                new Vector2(76.5f, 5.3f),
                new Vector2(3.34f, 2.45f),
                new Vector2(54.35f, 54.5432f),
                new Vector2(1.45423f, 36.34f),
                new Vector2(1.4f, 435.5f),
                new Vector2(2.5f, 0.432f),
            };
            Vector2 _result = GetAnswerToExercise4(_array4);
            Console.WriteLine($"{_result}");

            Console.WriteLine();

            Console.WriteLine("Задание 5 (найти наибольший периметр треугольник, состоящего из точек массива, и вывести его периметр и точки): ");

            Vector2[] _array5 = new Vector2[]
            {
                new Vector2(1, 2),
                new Vector2(3, 5),
                new Vector2(34, 56),
                new Vector2(24, 12),
                new Vector2(6454, 562),
                new Vector2(2, 0),
            };

            (float, Vector2[]) _result5 = GetAnswerToExercise5(_array5);

            Console.WriteLine($"Периметр: {_result5.Item1}");

            Console.WriteLine($"Точка 1: {_result5.Item2[0]}");
            Console.WriteLine($"Точка 2: {_result5.Item2[1]}");
            Console.WriteLine($"Точка 3: {_result5.Item2[2]}");
            Console.WriteLine();

        }


        public static void GetAnswerToExercise1(int[] _input, out int[] B, out int[] C)
        {
            List<int> _BList = new List<int>();
            List<int> _CList = new List<int>();

            _CList.Add(_input[0]);

            int _currentSeriesLength = 1;
            for(int i = 1; i < _input.Length; i++)
            {
                if(_input[i] != _input[i - 1])
                {
                    _BList.Add(_currentSeriesLength);
                    _currentSeriesLength = 1;
                    _CList.Add(_input[i]);
                }
                else
                {
                    _currentSeriesLength++;
                    if(i == _input.Length - 1)
                    {
                        _BList.Add(_currentSeriesLength);
                    }
                }
            }

            B = _BList.ToArray();
            C = _CList.ToArray();

        }

        public static int[] GetAnswerToExercise2(int L, int[] _input)
        {
            List<int> _result = new List<int>();

            List<int> _currentSeries = new List<int>();

            _currentSeries.Add(_input[0]);

            for (int i = 1; i < _input.Length; i++)
            {
                if (_input[i] != _input[i - 1])
                {
                    if (_currentSeries.Count > L) _result.Add(0);
                    else for (int x = 0; x < _currentSeries.Count; x++) _result.Add(_currentSeries[x]);
                    _currentSeries.Clear();
                    _currentSeries.Add(_input[i]);
                }
                else
                {
                    _currentSeries.Add(_input[i]);
                    if (i == _input.Length - 1)
                    {
                        if (_currentSeries.Count > L) _result.Add(0);
                        else for (int x = 0; x < _currentSeries.Count; x++) _result.Add(_currentSeries[x]);
                    }
                }
            }

            return _result.ToArray();
        }

        public static int[] GetAnswerToExercise3(int K, int[] _input)
        {
            List<List<int>> _series = new List<List<int>>();
            List<int> _result = new List<int>();

            _series.Add(new List<int>());

            _series[0].Add(_input[0]);

            //добавление серий в массив серий

            for (int i = 1; i < _input.Length; i++)
            {
                if (_input[i] != _input[i - 1]) _series.Add(new List<int>());
                _series[_series.Count - 1].Add(_input[i]);
            }

            //проверка на выход за границы массива
            if (K >= _series.Count) return new int[0];

            //перемещение серий
            List<int> _movedSeries = _series[_series.Count - 1];
            _series[_series.Count - 1] = _series[K];
            _series[K] = _movedSeries;

            //перемещение серий в результирующий массив
            for (int i = 0; i < _series.Count; i++)
            {
                for (int x = 0; x < _series[i].Count; x++)
                {
                    _result.Add(_series[i][x]);
                }
            }

            return _result.ToArray();
        }

        public static Vector2 GetAnswerToExercise4(Vector2[] _input)
        {
            if (_input.Length == 0) return new Vector2();

            int _startIndex = _input.Length / 4;
            int _finalIndex = _startIndex + _input.Length / 4 - 1;

            int _maxDistanceIndex = _startIndex;

            for (int i = _startIndex; i <= _finalIndex; i++)
            {
                if (Vector2.Distance(new Vector2(0, 0), _input[i]) > Vector2.Distance(new Vector2(0, 0), _input[_maxDistanceIndex])) _maxDistanceIndex = i;
            }

            return _input[_maxDistanceIndex];
        }


        //возвращает в кортеже периметр и массив из трех точек
        public static (float, Vector2[]) GetAnswerToExercise5(Vector2[] _input)
        {


            Vector2[] _triangle = new Vector2[3];

            for (int _t0 = 0; _t0 < _input.Length; _t0++)
            {
                for (int _t1 = 0; _t1 < _input.Length; _t1++)
                {
                    for (int _t2 = 0; _t2 < _input.Length; _t2++)
                    {
                        Vector2[] _tempTriangle = new Vector2[]
                        {
                             _input[_t0],
                             _input[_t1],
                             _input[_t2]
                        };

                        if (CalculatePerimeter(_tempTriangle) > CalculatePerimeter(_triangle)) _triangle = _tempTriangle;
                    }
                }
            }

            static float CalculatePerimeter(Vector2[] _dots)
            {
                float _result = Vector2.Distance(_dots[0], _dots[_dots.Length - 1]);

                for(int i = 1; i < _dots.Length; i++)  _result += Vector2.Distance(_dots[i - 1], _dots[i]);

                return _result;
            }

            return (CalculatePerimeter(_triangle), _triangle);

        }


        
    }
}
