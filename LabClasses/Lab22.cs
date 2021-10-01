using System;
using System.Collections.Generic;

namespace Labs
{

	public static class Lab22
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
			Console.WriteLine("Ответы на лабораторную 22");

			Console.WriteLine("Задание 1 (поменять местами минимальный и максимальный элемент в каждой строке): ");
			Matrix<float> _matrix1;

			_matrix1.values = new float[,]
			{
				{ 3,    5,   6,    11,   20 },

				{ 634, 435, 0,  131,   55 },

				{ 43,  342,  6,    11,   4 },

				{ 53,  435, 3456,  345,  43 },
			};

			Console.WriteLine(GetAnswerToExercise1(_matrix1));

			Console.WriteLine();

			Console.WriteLine("Задание 2 (поменять местами столбцы с минимальным и максимальным элементом): ");
			Matrix<float> _matrix2;

			_matrix2.values = new float[,]
			{
				{ 3,    5,   6,    11,   20 },

				{ 634, 435, 0,  131,   -3 },

				{ 43,  342,  6,    11,   4 },

				{ 53,  435, 3456,  345,  43 },
			};

			Console.WriteLine(GetAnswerToExercise2(_matrix2));


			Console.WriteLine("Задание 3 (поменять местами левую верхнюю и правую нижнюю четверти матрицы): ");
			Matrix<float> _matrix3;

			_matrix3.values = new float[,]
			{
				{ 3,    5,   6,    11 },

				{ 634, 435, 0,  131},

				{ 43,  342,  6,    11},

				{ 53,  435, 3456,  345},
			};

			Console.WriteLine(GetAnswerToExercise3(_matrix3));

			Console.WriteLine("Задание 4 (упорядочить строки так, чтобы их первые элементы образовывали возрастующую последовательность): ");
			Matrix<float> _matrix4;

			_matrix4.values = new float[,]
			{
				{ 3,    5,   6,    11 },

				{ 634, 435, 0,  131},

				{ 43,  342,  6,    11},

				{ 53,  435, 3456,  345},
			};

			Console.WriteLine(GetAnswerToExercise4(_matrix4));

			Console.WriteLine("Задание 5 (найти сумму элементов диагоналей, параллельный главной): ");
			Matrix<float> _matrix5;

			_matrix5.values = new float[,]
			{
				{ 3,    5,   6,    11 },

				{ 634, 435,  0,    131},

				{ 43,  342,  6,     11},

				{ 53,  435, 3456,  345},
			};

			WriteArray(GetAnswerToExercise5(_matrix5));
		}


		public static Matrix<float> GetAnswerToExercise1(Matrix<float> _matrix)
		{

			for (int m = 0; m < _matrix.M; m++)
			{

				(int, int) _indexes = new(0, 0); // item1 - минимального элемента, item2 - индекс максимального
				for (int n = 0; n < _matrix.N; n++)
				{
					if (_matrix[m, n] < _matrix[m, _indexes.Item1]) _indexes.Item1 = n;
					if (_matrix[m, n] > _matrix[m, _indexes.Item2]) _indexes.Item2 = n;
				}

				float _temp = _matrix[m, _indexes.Item1];
				_matrix[m, _indexes.Item1] = _matrix[m, _indexes.Item2];
				_matrix[m, _indexes.Item2] = _temp;
			}

			return _matrix;
		}

		public static Matrix<float> GetAnswerToExercise2(Matrix<float> _matrix)
		{
			(int, int) _indexes = new(0, 0); // item1 - индекс столбца с минимальным элементом, item2 - столбца с максимальным
			(float, float) _elements = new(999999999, -999999999); // item1 - минимальный элемент, item2 - максимальный

			for (int n = 0; n < _matrix.N; n++)
			{
				for (int m = 0; m < _matrix.M; m++)
				{
					if (_elements.Item1 > _matrix[m, n])
					{
						_elements.Item1 = _matrix[m, n];
						_indexes.Item1 = n;
					}
					if (_elements.Item2 < _matrix[m, n])
					{
						_elements.Item2 = _matrix[m, n];
						_indexes.Item2 = n;
					}
				}
			}


			for (int m = 0; m < _matrix.M; m++)
			{
				float _temp = _matrix[m, _indexes.Item1];
				_matrix[m, _indexes.Item1] = _matrix[m, _indexes.Item2];
				_matrix[m, _indexes.Item2] = _temp;
			}

			return _matrix;
		}

		public static Matrix<float> GetAnswerToExercise3(Matrix<float> _matrix)
		{
			for (int n = 0; n < _matrix.N / 2; n++)
			{
				for (int m = 0; m < _matrix.M / 2; m++)
				{
					float _temp = _matrix[m, n];
					_matrix[m, n] = _matrix[m + _matrix.M / 2, n + _matrix.N / 2];
					_matrix[m + _matrix.M / 2, n + _matrix.N / 2] = _temp;
				}
			}

			return _matrix;
		}

		public static Matrix<float> GetAnswerToExercise4(Matrix<float> _matrix)
		{

			bool _isSorted = false;

			//сортировка строк по первому элементу
			while (!_isSorted)
			{
				_isSorted = true;
				for (int m = 1; m < _matrix.M; m++)
				{
					if (_matrix[m - 1, 0] > _matrix[m, 0])
					{
						_isSorted = false;
						SwapLines(_matrix, m, m - 1);
					}
				}

			}
			//меняет местами строки матрицы
			Matrix<T> SwapLines<T>(Matrix<T> _matrix, int _line1, int _line2)
			{
				for (int n = 0; n < _matrix.N; n++)
				{
					T _temp = _matrix[_line1, n];
					_matrix[_line1, n] = _matrix[_line2, n];
					_matrix[_line2, n] = _temp;
				}
				return _matrix;
			}

			return _matrix;
		}
		public static float[] GetAnswerToExercise5(Matrix<float> _matrix)
		{
			List<float> _result = new List<float>();

			//индекс стартового столбца, начинается с последнего
			for (int _startColumn = _matrix.N - 1; _startColumn >= 0; _startColumn--)
			{
				_result.Add(0);
				//увеличение индексов строки и столбца для движения по диагонали
				for (int m = 0, n = _startColumn; n < _matrix.N && m < _matrix.M; m++, n++) _result[_result.Count - 1] += _matrix[m, n];
			}
			//индекс стартовой строки
			for (int _startLine = 1; _startLine < _matrix.M; _startLine++)
			{
				_result.Add(0);
				//увеличение индексов строки и столбца для движения по диагонали
				for (int m = _startLine, n = 0; m < _matrix.M; m++, n++) _result[_result.Count - 1] += _matrix[m, n];
			}



			return _result.ToArray();
		}
	}

}