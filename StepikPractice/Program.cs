using System;
using System.Collections.Generic;

namespace Hometask
{
    class Program
    {
        public class Student
        {
            public string FirstName;
            public string LastName;
            public int Age;
            public Student(string firstName, string lastName, int age)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
            }

        }
        public class School
        {
            public string Name;
            public List<Student> Students;
            public School(string SchoolName)
            {
                Name = SchoolName;
                Students = new List<Student>();
            }

            public void printStudents()
            {
                if (Students.Count == 0)
                {
                    Console.WriteLine($"В школе {Name} пока нет учеников!");
                }
                else
                {
                    Console.WriteLine("{0,-5}{1, -10}{2,-10}{3,-10}", "№", "|Имя|", "|Фамилия|", "|Возраст|");
                    for (int i = 0; i < Students.Count; i++)
                    {
                        Console.WriteLine("{0,-6}{1,-10}{2,-10}{3,-11}", i + 1, Students[i].FirstName, Students[i].LastName, Students[i].Age);
                    }
                }
            }

            public void AddNewStudent(Student student)
            {
                Students.Add(student);
                Console.WriteLine($"Ученик {student.FirstName} {student.LastName} успешно добавлен в школу {Name}!");
            }

            public void DeleteStudent(int studentNum)
            {
                Students.Remove(Students[studentNum-1]);
                Console.WriteLine($"Ученик №{studentNum} удален!");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите название школы: ");
            string SchoolName = Console.ReadLine();
            School newSchool = new School(SchoolName);
            Console.WriteLine($"Школа {SchoolName} успешно создана!");
            while (true)
            {
                Console.WriteLine($"Вы хотите посмотреть список учеников школы {SchoolName}? Введите да или нет: ");
                string userAnswer = Console.ReadLine().ToLower();
                if (userAnswer == "да")
                {
                    newSchool.printStudents();
                    Console.WriteLine($"Вы хотите удалить какого-либо ученика из школы {SchoolName}? Введите да или нет: ");
                    userAnswer = Console.ReadLine().ToLower();
                    if (userAnswer == "да")
                    {
                        while (true)
                        {
                            Console.WriteLine("Введите порядковый номер ученика для удаления: ");
                            try
                            {
                                int studentNum = int.Parse(Console.ReadLine());
                                newSchool.DeleteStudent(studentNum);
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Введите корректный порядковый номер ученика!!!");
                            }
                        }
                    }
                }
                Console.WriteLine($"Вы хотите добавить нового ученика в школу {SchoolName}? Введите да или нет: ");
                userAnswer = Console.ReadLine().ToLower();
                if (userAnswer == "да")
                {
                    Console.WriteLine("Введите имя ученика: ");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Введите фамилию ученика: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Введите возраст ученика: ");
                    int age = int.Parse(Console.ReadLine());
                    Student student = new Student(firstName, lastName, age);
                    newSchool.AddNewStudent(student);
                }
            }
        }
    }
}