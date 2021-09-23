using System;

namespace Labs
{
    public static class Lab17
    {
        public static void WriteAllExercises()
        {
            Console.WriteLine("Ответы на лабораторную 17");

            int[] _numbers = new int[] { 2, 5, 4, 5, 2, 84, 73, 5, 52, 21, 3, 543, 6, 3, 556 };

            Console.WriteLine(GetAnswerToExercise1(_numbers, 3, 11));

            _numbers = new int[] { 1, 4, 7, 10, 13, 16, 19, 22 };
            Console.WriteLine(GetAnswerToExercise2(_numbers));

            float[] _floatNumbers = new float[] { 1.3f, 4.4f, 765.343f, 2.543643f, 36.32f };
            Console.WriteLine(GetAnswerToExercise3(_floatNumbers));
            Console.WriteLine(GetAnswerToExercise4(_floatNumbers));

            _numbers = new int[] { 1, 453, 43, 67, 45, 89, 46, 43 };
            Console.WriteLine(GetAnswerToExercise5(_numbers));

        }

        public static float GetAnswerToExercise1(int[] _input, int K, int L)
        {
            if (_input.Length < 2) return float.NaN;

            float _result = 0;
            for (int i = K - 1; i < L; i++) _result += _input[i];

            return _result / (L - K + 1);

        }

        public static float GetAnswerToExercise2(int[] _input)
        {
            if (_input.Length < 2) return float.NaN;

            float _difference = _input[1] - _input[0];

            for (int i = 2; i < _input.Length; i++) if (_input[i] - _input[i - 1] != _difference) return 0;
            return _difference;

        }

        public static float GetAnswerToExercise3(float[] _input)
        {
            float _minNum = 10000000;

            //индексация массива начинается с 0, в таком случае четные элементы имеют индексы 1, 3, 5 
            for (int i = 1; i < _input.Length; i += 2) if (_input[i] < _minNum) _minNum = _input[i];

            return _minNum;
        }

        public static int GetAnswerToExercise4(float[] _input)
        {
            int _number = -1;

            for (int i = 0; i < _input.Length; i++)
            {
                bool _isLocalMax = true;

                if (i > 0 && _input[i - 1] >= _input[i]) _isLocalMax = false;
                if (i < _input.Length - 1 && _input[i + 1] >= _input[i]) _isLocalMax = false;

                if (_isLocalMax) _number = i;
            }

            return _number + 1; //был найден индекс элемента, в задаче требуется номер элемента
        }

        public static string GetAnswerToExercise5(int[] _input)
        {
            (int, int) _indexes = new(-1, -1);

            for(int i = 0; i < _input.Length; i++)
            {
                for (int x = 0; x < _input.Length; x++)
                {
                    if (x == i) continue;

                    if(_input[i] == _input[x])
                    {
                        _indexes.Item1 = i;
                        _indexes.Item2 = x;
                        break;
                    }
                }
            }

            if (_indexes.Item1 == -1 || _indexes.Item2 == -1) return "";

            //индексы на единицу меньше, чем номер
            _indexes.Item1++;
            _indexes.Item2++;

            if (_indexes.Item1 > _indexes.Item2) return $"{ _indexes.Item2} { _indexes.Item1}";
            else return $"{ _indexes.Item1} { _indexes.Item2}";

        }
    }
}