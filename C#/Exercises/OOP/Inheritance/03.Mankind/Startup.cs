namespace _03.Mankind
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;

    public class Startup
    {
        static void Main()
        {
            string[] studentArgs = Console.ReadLine().Split();
            string[] workerArgs = Console.ReadLine().Split();

            string studentFirstName = studentArgs[0];
            string studentLastName = studentArgs[1];
            string facultyNumber = studentArgs[2];

            string workerFirstName = workerArgs[0];
            string workerLastName = workerArgs[1];
            double weeklySalary = double.Parse(workerArgs[2]);
            double workingHoursPerDay = double.Parse(workerArgs[3]);

            try
            {
                var student = new Student(studentFirstName, studentLastName, facultyNumber);
                Console.WriteLine(student);

                var worker = new Worker(workerFirstName, workerLastName, weeklySalary, workingHoursPerDay);
                Console.WriteLine(worker);
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }            
        }
    }
}
