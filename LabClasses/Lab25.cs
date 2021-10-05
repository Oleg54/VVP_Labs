using System;
using System.IO;

namespace Labs
{
    public static class Lab25
    {
        public static void Main() { WriteAllExercises(); }

        //Метод для вывода результатов, вызывается из класса Program
        public static void WriteAllExercises()
        {
            Console.WriteLine();
            Console.WriteLine("Ответы на лабораторную 24");

            Console.Write("Задание 1 (удалить из файла символы, стоящие перед пробелом) ");
            AnswerToExercise1("C:/Users/o.k.kravchenko/Desktop/text1.txt");

            Console.Write("Задание 2 (создать файл с N строк и K столбцов *) ");
            AnswerToExercise2("C:/Users/o.k.kravchenko/Desktop/", "text2", 5, 7);

            Console.Write("Задание 3 (добавить в начало первого файла содержимое второго) ");
            AnswerToExercise3("C:/Users/o.k.kravchenko/Desktop/text3.1.txt", "C:/Users/o.k.kravchenko/Desktop/text3.2.txt");


            Console.Write("Задание 4 (убрать множественные пробелы) ");
            AnswerToExercise4("C:/Users/o.k.kravchenko/Desktop/text4.txt");


            Console.Write("Задание 5 (вывести количество абзацев) ");
            Console.WriteLine(GetAnswerToExercise5("C:/Users/o.k.kravchenko/Desktop/text5.txt"));

        }


        public static void AnswerToExercise1(string path)
        {
            string text = File.ReadAllText(path);

            string result = text.Substring(text.IndexOf(' ') + 1);

            File.WriteAllText(path, result);
        }

        public static void AnswerToExercise2(string path, string fileName, int N, int K)
        {
            string[] result = new string[N];

            for (int n = 0; n < N; n++)
            {
                for (int k = 0; k < K; k++)
                {
                    result[n] += "*";
                }
            }

            File.WriteAllLines(path + fileName + ".txt", result);
        }
        public static void AnswerToExercise3(string path1, string path2)
        {
            string file1 = File.ReadAllText(path1);
            string file2 = File.ReadAllText(path2);
            
            //запись в первый файл содержимого второго и первого
            File.WriteAllText(path1, file2 + file1);
        }

        public static void AnswerToExercise4(string path)
        {
            string file = File.ReadAllText(path);
            
            //пока в строки есть двойные пробелы, заменить их на единичные
            while (file.Contains("  ")) file = file.Replace("  ", " ");

            File.WriteAllText(path, file);
        }

        public static int GetAnswerToExercise5(string path)
        {
            //получение содержимого файла, далее метод Split разделяет его на массив строк по разделителю "     ",
            //выводится длина этого массива - 1, так как первая красная строка не учитывается
            return File.ReadAllText(path).Split("     ").Length - 1;
        }
    }
}
