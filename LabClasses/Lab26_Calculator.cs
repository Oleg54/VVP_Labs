using System;
using System.Collections.Generic;

namespace Labs
{

	public static class Lab26_Calculator
	{
        private static char[] _availabilityOperations = new char[] { '/', '*', '+', '-' };

        private static bool CharIsOperation(char _example)
        {
            for (int i = 0; i < _availabilityOperations.Length; i++) if (_example == _availabilityOperations[i]) return true;
            return false;
        }

		private static bool ExampleIsSolved(string _example)
        {
            for (int x = 0; x < _availabilityOperations.Length; x++) if (_example.Contains($"[{_availabilityOperations[x]}]")) return false;
            return true;
        }

        private static string MakeOperation(double _num1, double _num2, int _operationIndex)
        {
            switch (_availabilityOperations[_operationIndex])
            {
                case '/':
                    return (_num1 / _num2).ToString();
                case '*':
                    return (_num1 * _num2).ToString();
                case '+': 
                    return (_num1 + _num2).ToString();
                case '-': 
                    return (_num1 - _num2).ToString();
            }
            throw new Exception("Operation is invalid");
        }

		private static string GetResult(string _example)
        {
            string[] _nums = null;
            int _operationIndex = -1;

            for (int i = 0; i < _availabilityOperations.Length; i++)
            {
                _nums = _example.Split($"[{_availabilityOperations[i]}]");
                if (_nums.Length > 1)
                {
                    _operationIndex = i;
                    break;
                }
            }
            double _number1 = Convert.ToDouble(_nums[0]);
            double _number2 = Convert.ToDouble(_nums[1]);

            return MakeOperation(_number1, _number2, _operationIndex);

        }

        private static string Calculate(string _example)
        {
            while (!ExampleIsSolved(_example))
            {
                int _splitIndex = 1000000;
                int _muliplyIndex = 10000000;

                int _subtractionIndex = 1000000;
                int _additionIndex = 10000000;

                int _operationPlaceIndex;

                if (_example.Contains("[/]") || _example.Contains("[*]"))
                {
                    if (_example.Contains("[/]")) _splitIndex = _example.IndexOf("[/]") + 1;
                    if (_example.Contains("[*]")) _muliplyIndex = _example.IndexOf("[*]") + 1;
                    if (_splitIndex < _muliplyIndex) _operationPlaceIndex = _splitIndex;
                    else _operationPlaceIndex = _muliplyIndex;
                }
                else
                {
                    if (_example.Contains("[-]")) _subtractionIndex = _example.IndexOf("[-]") + 1;
                    if (_example.Contains("[+]")) _additionIndex = _example.IndexOf("[+]") + 1;
                    if (_subtractionIndex < _additionIndex) _operationPlaceIndex = _subtractionIndex;
                    else _operationPlaceIndex = _additionIndex;
                }


                int _startIndex = -1;
                int _finalIndex = -1;

                for (int i = _operationPlaceIndex - 1; i >= 0; i--)
                {
                    if (CharIsOperation(_example[i]))
                    {
                        if (i == 0)
                        {
                            _startIndex = i;
                            break;
                        }
                        else if (_example[i - 1] == '[' && _example[i + 1] == ']')
                        {
                            _startIndex = i + 2;
                            break;
                        }
                    }
                }

                for (int i = _operationPlaceIndex + 1; i < _example.Length; i++)
                {
                    if (CharIsOperation(_example[i]))
                    {
                        if (i == _example.Length - 1) throw new Exception();
                        else if (_example[i - 1] == '[' && _example[i + 1] == ']')
                        {
                            _finalIndex = i - 2;
                            break;
                        }
                    }
                }


                if (_startIndex == -1) _startIndex = 0;
                if (_finalIndex == -1) _finalIndex = _example.Length - 1;

                int _exampleLength = _finalIndex - _startIndex + 1;

                string _tempExample = _example.Substring(_startIndex, _exampleLength);

                _example = _example.Remove(_startIndex, _exampleLength);
                _example = _example.Insert(_startIndex, GetResult(_tempExample).ToString());

            }
            return _example;
        }

        private static int GetCloseBracketIndex(string _example, int _firstBracketIndex)
        {
            int _needCloseBrackets = 1;

            for(int i = _firstBracketIndex + 1; i < _example.Length; i++)
            {
                if (_example[i] == ')') _needCloseBrackets--;
                else if (_example[i] == '(') _needCloseBrackets++;
                if (_needCloseBrackets == 0) return i;
            }
            return -1;
        }

        private static string CalculateBrackets(string _example)
        {
            if (_example.Contains("("))
            { 
                int _startIndex = _example.IndexOf("(");
                int _finalIndex = GetCloseBracketIndex(_example, _startIndex);
                int _exampleLength = _finalIndex - _startIndex + 1;

                string _tempExample = _example.Substring(_startIndex, _exampleLength);

                _tempExample = _tempExample.Remove(0, 1);
                _tempExample = _tempExample.Remove(_tempExample.Length - 1, 1);
                if (_tempExample.Contains("(")) _tempExample = CalculateBrackets(_tempExample);

                _tempExample = Calculate(_tempExample);

                _example = _example.Remove(_startIndex, _exampleLength);
                _example = _example.Insert(_startIndex, _tempExample.ToString());
            }
            while (_example.Contains("(")) _example = CalculateBrackets(_example);

            return _example;
        }

        private static string ConvertExample(string _example)
        {
            _example = _example.Replace(" ", "");

            string _result = "";

            for(int i = 0; i < _example.Length; i++)
            {
                bool _charIsOperation = false;

                if (_example[i] != '-' || (_example[i] == '-' && i > 0 && !CharIsOperation(_example[i - 1]) && !CharIsOperation(_example[i + 1])))
                {
                    for (int x = 0; x < _availabilityOperations.Length; x++)
                    {
                        if (_availabilityOperations[x] == _example[i])
                        {
                            _result += "[";
                            _result += _example[i];
                            _result += "]";
                            _charIsOperation = true;
                            break;

                        }
                    }
                }


                if (!_charIsOperation) _result += _example[i];
            }
            return _result;
        }

        private static void BeginCalculations()
        {
            Console.WriteLine();
            Console.WriteLine("Введите выражение"); 

            string _example;
            try
            {
                _example = ConvertExample(Console.ReadLine());

                _example = CalculateBrackets(_example);
                _example = Calculate(_example);

                Console.WriteLine("Ответ: " + _example);
            }
            catch
            {
                Console.WriteLine("Введено некорректное выражение");
            }

            BeginCalculations();
        }

        public static void StartCalculator()
        {
            Console.WriteLine();
            Console.WriteLine("Калькулятор v.0.1a. Поддерживаемые операции: /, *, +, -");

            BeginCalculations();
        }

	}
}