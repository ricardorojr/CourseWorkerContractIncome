using System;
using System.Globalization;
using CourseWorkerContractIncome.Entities.Enums;
using CourseWorkerContractIncome.Entities;

namespace CourseWorkerContractIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter level (Junior/MidLevel/Senior): ");
            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine()); 
            Console.WriteLine("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Department department = new Department(deptName);
            Worker worker = new Worker(name, workerLevel, baseSalary, department);
            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valuePerHour = double .Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract hourContract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(hourContract);
            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name " + worker.Name);
            Console.WriteLine("Department " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + " : " +worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}


