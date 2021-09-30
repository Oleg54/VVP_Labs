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
	
		public override string ToString()
		{
			string _result = "";
			
			for(int m = 0; m < M; m++)
			{
				_result += "| ";
				for(int n = 0; n < N; n++)
				{
					_result += values[m, n].ToString();
					if(n != N - 1) _result += ", ";
				}
				_result += " | \n";
			}
			
			
			return _result;
		}
}
