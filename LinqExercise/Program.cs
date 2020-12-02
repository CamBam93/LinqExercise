using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /* 
             * Complete every task using Method OR Query syntax.
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             */

            //Print the Sum and Average of numbers

            var sum = numbers.Sum();
            var avg = numbers.Average();
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine("-------------");
            Console.WriteLine($"Average: {avg}");
            Console.WriteLine("-------------");

            //Order numbers in ascending order and decsending order. Print each to console.

            var asc = numbers.OrderBy(num => num);
            Console.WriteLine("Ascending:");
            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("-------------");
            var desc = numbers.OrderByDescending(num => num);
            Console.WriteLine("Descending:");
            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("-------------");

            //Print to the console only the numbers greater than 6

            var grtr6 = numbers.Where(num => num > 6);
            Console.WriteLine("Numbers greater than 6:");
            foreach(var num in grtr6)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("-------------");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("Only four numbers, ascending:");
            foreach(var num in asc.Take(4))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("-------------");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Added age to array");
            numbers[4] = 27;
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var filter1 =
                employees.Where(p => p.FirstName.StartsWith('C') || p.FirstName.StartsWith('S'))
                .OrderBy(p => p.FirstName);
            Console.WriteLine("Names starting with C or S");
            foreach (var p in filter1)
            {
                Console.WriteLine(p.FullName);
            }
            Console.WriteLine("-------------");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var over26 = employees.Where(p => p.Age > 26).OrderBy(p => p.Age).ThenBy(p => p.FirstName);
            Console.WriteLine("Employees over the age 26");
            foreach (var p in over26)
            {
                Console.WriteLine($"Age: {p.Age} Full Name: {p.FullName} ");
            }
            Console.WriteLine("-------------");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var yoe = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35);
            var sumYOE = yoe.Sum(e => e.YearsOfExperience);
            var avgYOE = yoe.Average(e => e.YearsOfExperience);
            Console.WriteLine("Total Years of Experience");
            Console.WriteLine($"Sum: {sumYOE} Avg: {avgYOE}");
            Console.WriteLine("-------------");

            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Rick", "James", 69, 13)).ToList();
            foreach (var e in employees)
            {
                Console.WriteLine($"{e.Age} {e.FullName}");
            }
            Console.WriteLine("-------------");

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
