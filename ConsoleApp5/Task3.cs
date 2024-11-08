using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Cafe<T> : IEnumerable<T> where T : Employee
    {
        private T[] cafeTeam;
        private int count = 0;

        public Cafe(int c)
        {
            cafeTeam = new T[c];
        }
        public Cafe()
        {
            cafeTeam = new T[10];
        }

        public void AddEmp(T empl)
        {
            if (count < cafeTeam.Length)
            {
                cafeTeam[count] = empl;
                count++;
            }
            else
            {
                Console.WriteLine("Cannot add another employee");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return cafeTeam[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Salary { get; set; }
    }


    public class Program3
    {
        public static void Main(string[] args)
        {
            Cafe<Employee> cafeTeam = new Cafe<Employee>(5);
            cafeTeam.AddEmp(new Employee { Name = "Oleg", Age = 21, Salary = "1000"});
            cafeTeam.AddEmp(new Employee { Name = "Danya", Age = 22, Salary = "1500" });
            cafeTeam.AddEmp(new Employee { Name = "Alex", Age = 24, Salary = "2000" });

            foreach (var emp in cafeTeam)
            {
                Console.WriteLine($"Name: {emp.Name}, Age: {emp.Age}, Salary: {emp.Salary}");
            }
        }
    }
}
