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

            Console.Write("Задание 1 (удалить из файла символы, стоящие перед пробелом): ");
            AnswerToExercise1("C:/Users/o.k.kravchenko/Desktop/text1.txt");

            Console.Write("Задание 2 (удалить из файла символы, стоящие перед пробелом): ");
            AnswerToExercise2("C:/Users/o.k.kravchenko/Desktop/", "text2", 5, 7);

        }


        public static void AnswerToExercise1(string path)
        {
            string text = File.ReadAllText(path);

            string result = text.Substring(text.IndexOf(' ') + 1);
            
            File.WriteAllText(path, result);
        }

        public static void AnswerToExercise2(string path, string fileName, int N, int K)
        {
            string result = "";

            for (int n = 0; n < N; n++)
            {
                for (int k = 0; k < K; k++)
                {
                    result += "*";
                }
                result += "\n";
            }


            File.WriteAllText(path + fileName + ".txt", result);
        }
    }
}
