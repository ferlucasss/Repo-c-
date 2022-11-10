using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Lucas");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);           

            var stats = book.GetStatistics();

            Console.WriteLine($"El promedio de notas es: {stats.Average:N2}");
            Console.WriteLine($"El mayor numero es: {stats.High}");
            Console.WriteLine($"El menor numero es: {stats.Low}");
            Console.WriteLine($"La letra de la calificacion es: {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Ingrese una nota o 'q' para salir");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("a grade was added");
        }
    }
}
