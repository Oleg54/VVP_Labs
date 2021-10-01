using System;

namespace Labs
{
	public static class Lab23
	{

		public static void WriteAllExercises()
		{
			Console.WriteLine();
			Console.WriteLine("Ответы на лабораторную 23");

			Console.WriteLine("Задание 1 (вывести символы, стоящие до и после символа C в кодовой таблице): ");
			Console.WriteLine(GetAnswerToExercise1('C'));


			Console.WriteLine("Задание 2 (вывести входную строку, разделив ее символы пробелами): ");
			Console.WriteLine(GetAnswerToExercise2("fdggfdz"));

			Console.WriteLine("Задание 3 (подсчитать количество строчных латинских букв): ");
			Console.WriteLine(GetAnswerToExercise3("пар34gfdFd5г"));

			Console.WriteLine("Задание 4 (удвоить каждый символ C в строке): ");
			Console.WriteLine(GetAnswerToExercise4('5', "gdf4bk5v5523nsa"));

			Console.WriteLine("Задание 5 (определить кол-во вхождений подстроки в строку): ");
			Console.WriteLine(GetAnswerToExercise5("TTGFDTTRTRBVTT", "TT"));
		}

		//(byte)char преобразовывает символ в его номер в кодовой таблице, (char)byte работает наоборот
		public static (char, char) GetAnswerToExercise1(char _inputSymbol) => new((char)(((byte)_inputSymbol) - 1), (char)(((byte)_inputSymbol) + 1));

		public static string GetAnswerToExercise2(string _input)
		{
			string _result = "";
			for (int i = 0; i < _input.Length; i++)
			{
				_result += _input[i];
				if (i < _input.Length - 1) _result += " ";
			}
			return _result;
		}

		public static int GetAnswerToExercise3(string _input)
		{
			int _counter = 0;

			for (int i = 0; i < _input.Length; i++) if (SymbolIsSuitable(_input[i])) _counter++;

			//проверяет, является символ прописной строчной буквой
			bool SymbolIsSuitable(char _symbol)
			{
				//хранит крайние коды подходящих символов солгасно кодовой таблице, [97; 122]
				(byte, byte) _codes = new(97, 122);
				return (byte)_symbol >= _codes.Item1 && (byte)_symbol <= _codes.Item2;

			}

			return _counter;
		}

		public static string GetAnswerToExercise4(char C, string _input)
        {
			string _result = "";
			for (int i = 0; i < _input.Length; i++)
            {
				_result += _input[i];
				if (_input[i] == C) _result += C;
            }
			return _result;
		}
		public static int GetAnswerToExercise5(string _input, string _part)
		{
			int _counter = 0;

			int _startPartIndex = -1;

			for (int i = 0; i < _input.Length; i++)
            {
				if(_startPartIndex == -1)
                {
					if (_input[i] == _part[0]) _startPartIndex = i;
                }
                else
				{
					if (i - _startPartIndex >= _part.Length)
					{
						_startPartIndex = -1;
						_counter++;
					}
					else if (_input[i] != _part[i - _startPartIndex])
                    {
						_startPartIndex = -1;
						_counter++;
                    }
                }
            }

			return _counter;
		}
	}
}
