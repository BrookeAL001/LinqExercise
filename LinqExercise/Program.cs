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
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //DONE TODO: Print the Sum of numbers

            var Sum = numbers.Sum();
            Console.WriteLine($"The sum of the numbers is {Sum}");
            Console.WriteLine("--------------------------------");

            //DONE TODO: Print the Average of numbers
            var Average = numbers.Average();
            Console.WriteLine($"The average of the numbers is {Average}");
            Console.WriteLine("--------------------------------");

            //DONE !! TODO: Order numbers in ascending order and print to the console
            var Ascending = numbers.OrderBy(num => num);
            Console.WriteLine("These are the numbers in ascending order:");
            foreach (var num in Ascending)
            {
                Console.WriteLine($"{num}");
            }
            Console.WriteLine("--------------------------------");

            //DONE !! TODO: Order numbers in decsending order adn print to the console

            var Descending = numbers.OrderByDescending(num => num);
            Console.WriteLine("These are the numbers in descending order:");
            foreach (var num in Descending)
            {
                Console.WriteLine($"{num}");
            }
            Console.WriteLine("--------------------------------");

            //DONE!! TODO: Print to the console only the numbers greater than 6

            var GreaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine("These are the numbers greater than six");
            foreach (var num in GreaterThanSix)
            {
                Console.WriteLine($"{num}");
            }
            Console.WriteLine("--------------------------------");

            //DONE!! TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            var TakeFour = Ascending.Take(4);
            Console.WriteLine("Four of the printed numbers:");
            foreach (var num in TakeFour) { Console.WriteLine($"{num}"); }
            Console.WriteLine("--------------------------------");


            //DONE!! TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 37;
            var DescendingAge = numbers.OrderByDescending(num => num);
            Console.WriteLine("These are the numbers with age added in descending order:");
            foreach (var num in DescendingAge)
            {
                Console.WriteLine($"{num}");
            }
            Console.WriteLine("--------------------------------");


            // DONE!! List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //DONE!! TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.
            var filtered = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'))
                .OrderBy(person => person.FirstName);

            Console.WriteLine("C and S Employees");
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine("--------------------------------");

            //TODO: DONE!! Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var twentySeven = employees.Where(person => person.Age > 26).OrderBy(person => person.Age).ThenBy(person => person.FirstName);

            Console.WriteLine("Employees over the age of 26");
            foreach (var employee in twentySeven)
            { 
                Console.WriteLine($"Name: {employee.FullName}  Age: {employee.Age}");
                
            }
            Console.WriteLine("--------------------------------");

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35
            var yoeEmployees = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sumYears = yoeEmployees.Sum(emp => emp.YearsOfExperience);
            var avgOfYOE = yoeEmployees.Average(emp => emp.YearsOfExperience);

            Console.WriteLine($"Sum of Years of Experience = {sumYears}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Average of Years of Experience = {avgOfYOE}");
            Console.WriteLine("--------------------------------");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee { FirstName = "Brooke", LastName = "Allison", Age = 37, YearsOfExperience = 2 }).ToList();

            Console.WriteLine("Updated Employee List:");

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Age}");
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine();

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
