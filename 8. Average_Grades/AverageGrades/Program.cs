using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("output.txt", "");
            string[] input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);
            Student[] students = new Student[n];
            for (int i = 0; i < n; i++)
            {
                students[i] = ReadStudent(input[i + 1]); //might blow up
            }

            foreach (Student student in students.Where(x => x.AverageGrade >= 5).OrderBy(x => x.name).ThenByDescending(x => x.AverageGrade))
            {
                File.AppendAllText("output.txt", $"{student.name} -> {student.AverageGrade:F2}" + Environment.NewLine);
                Console.WriteLine("{0} -> {1:F2}", student.name, student.AverageGrade);
            }
        }

        static Student ReadStudent(string input)
        {
            string[] values = input.Split(' ');
            List<double> gradesList = new List<double>();
            foreach (string value in values.Skip(1))
            {
                gradesList.Add(double.Parse(value));
            }

            return new Student { name = values[0], Grades = gradesList };
        }
    }

    class Student
    {
        public string name { get; set; }
        public List<double> Grades { get; set; }
        public double AverageGrade { get { return Grades.Average(); } }
    }
}
