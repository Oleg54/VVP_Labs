using System;

//структура для представления матрицы
public struct Matrix<T>
{
	public T[,] values;

	public int M => values.GetLength(0);
	public int N => values.Length / values.GetLength(0);

	public Matrix(int _m, int _n)
	{
		values = new T[_m, _n];
	}

	//индексатор для упрощенного доступа
	public T this[int _m, int _n]
	{
		get
        {
			return values[_m, _n];
        }
	}
}
