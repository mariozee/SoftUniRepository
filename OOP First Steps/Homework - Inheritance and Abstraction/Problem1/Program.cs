using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stu1 = new Student("Pesho", "Peshev", "38F7H2D");
            var stu2 = new Student("Ivan", "Ivanov", "DJH38FJ3");
            var stu3 = new Student("Vasko", "Vasev", "3837RHRH");

            var studenList = new List<Student>
            {
                stu1,
                stu2,
                stu3
            };

            studenList = studenList.OrderBy(s => s.FacultyNumber).ToList();

            foreach (var student in studenList)
            {
                Console.WriteLine(student.FacultyNumber);
            }

            Console.WriteLine();

            var work1 = new Worker("Pesho", "Goshev", 200, 40);
            var work2 = new Worker("Mincho", "Svirchev", 100, 45);
            var work3 = new Worker("Shevket", "Bosov", 10000, 4);

            var workerList = new List<Worker>
            {
                work1,
                work2,
                work3
            };

            workerList = workerList.OrderByDescending(w => w.MoneyPerHour(w.WeekSalary, w.WorkHoursPayDay)).ToList();

            foreach (var worker in workerList)
            {
                Console.WriteLine(worker.MoneyPerHour(worker.WeekSalary, worker.WorkHoursPayDay));
            }

            Console.WriteLine();

            var humanList = new List<Human>();
            humanList.AddRange(workerList);
            humanList.AddRange(studenList);

            humanList = humanList.OrderBy(h => h.FirstName).ThenBy(h => h.LastName).ToList();

            foreach (var humans in humanList)
            {
                Console.WriteLine(humans.FirstName + " " + humans.LastName);
            }

            Console.WriteLine();
        }
    }
}
