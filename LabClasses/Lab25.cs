using System;
using System.IO;

namespace Labs
{
    public static class Lab25
    {
        private static string _filesPath = "C:/Users/craw4/Documents/TrainingFiles/VVP/";
        private static string _pathForChangedFiles = "C:/Users/craw4/Documents/TrainingFiles/VVP/ChangedFiles/";

        //Метод для вывода результатов, вызывается из класса Program
        public static void WriteAllExercises()
        {
            Console.WriteLine();
            Console.WriteLine("Ответы на лабораторную 24");

            Console.Write("Задание 1 (удалить из файла символы, стоящие перед пробелом) ");
            AnswerToExercise1("text1.txt");

            Console.Write("Задание 2 (создать файл с N строк и K столбцов *) ");
            AnswerToExercise2("text2.txt", 5, 7);

            Console.Write("Задание 3 (добавить в начало первого файла содержимое второго) ");
            AnswerToExercise3("text3.1.txt", "text3.2.txt");


            Console.Write("Задание 4 (убрать множественные пробелы) ");
            AnswerToExercise4("text4.txt");


            Console.Write("Задание 5 (вывести количество абзацев) ");
            Console.WriteLine(GetAnswerToExercise5("text5.txt"));

        }


        public static void AnswerToExercise1(string fileName)
        {
            string text = File.ReadAllText($"{_filesPath}{fileName}");

            string result = text.Substring(text.IndexOf(' ') + 1);

            File.WriteAllText($"{_pathForChangedFiles}{fileName}", result);
        }

        public static void AnswerToExercise2(string fileName, int N, int K)
        {
            string[] result = new string[N];

            for (int n = 0; n < N; n++)
            {
                for (int k = 0; k < K; k++)
                {
                    result[n] += "*";
                }
            }

            File.WriteAllLines($"{_pathForChangedFiles}{fileName}", result);
        }
        public static void AnswerToExercise3(string fileName1, string fileName2)
        {
            string file1 = File.ReadAllText($"{_filesPath}{fileName1}");
            string file2 = File.ReadAllText($"{_filesPath}{fileName2}");
            
            //запись в первый файл содержимого второго и первого
            File.WriteAllText($"{_pathForChangedFiles}{fileName1}", file2 + file1);
        }

        public static void AnswerToExercise4(string fileName)
        {
            string file = File.ReadAllText($"{_filesPath}{fileName}");
            
            //пока в строки есть двойные пробелы, заменить их на единичные
            while (file.Contains("  ")) file = file.Replace("  ", " ");

            File.WriteAllText($"{_pathForChangedFiles}{fileName}", file);
        }

        public static int GetAnswerToExercise5(string fileName)
        {
            //получение содержимого файла, далее метод Split разделяет его на массив строк по разделителю "     ",
            //выводится длина этого массива - 1, так как первая красная строка не учитывается
            return File.ReadAllText($"{_filesPath}{fileName}").Split("     ").Length - 1;
        }
    }
}
