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
        }


        public static void AnswerToExercise1(string path)
        {
            string text = File.ReadAllText(path);

            string result = text.Substring(text.IndexOf(' ') + 1);
            
            File.WriteAllText(path, result);
        }
    }
}
