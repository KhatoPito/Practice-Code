
using System;
using System.Collections.Generic;
 
namespace Organization
{


    public static class Company
    {
        // IMPORTANT: DO NOT MODIFY THIS CLASS
        public sealed class Employee
        {
            private readonly int id;
            private readonly string name;
            private List<Employee> reports;

            public Employee(int id, string name)
            {
                this.id = id;
                this.name = name;
                this.reports = new List<Employee>();
            }

            public int getId()
            {
                return id;
            }

            public string getName()
            {
                return name;
            }

            public IList<Employee> getReports()
            {
                return reports;
            }

            public void addReport(Employee employee)
            {
                reports.Add(employee);
            }
        }

        //
        // Read the attached PDF for more explanation about the problem
        //
        // Note: Don't modify the signature of this function 
        //
        public static Employee closestCommonManager(Employee ceo, Employee firstEmployee, Employee secondEmployee)
        {

            var visited = new HashSet<Employee>();
            bool firstFound = false, secondFound = false;

            Stack<Employee> stack = new Stack<Employee>(); // DFS
            stack.Push(ceo);

            while (stack.Count != 0)
            {
                Employee current = stack.Pop();
                IList<Employee> employeeList = current.getReports();

                if (!visited.Add(current))
                    continue;

                if (firstEmployee.getId() == current.getId())
                {
                    firstFound = true;                
                }

                if (secondEmployee.getId() == current.getId())
                    secondFound = true;

                if (firstFound && secondFound)
                    return current;

                Console.WriteLine(current.getName());

                foreach (var employee in employeeList)
                        stack.Push(employee);

            }

            return null;
        }

        public class Program
        {
            static void Main(string[] args)
            {
                Employee ceoBill = new Employee(1, "Bill");
                Employee micheal = new Employee(2, "Micheal");
                Employee sameer = new Employee(3, "Sameer");
                Employee dom = new Employee(4, "Dom");
                Employee bob = new Employee(5, "Bob");
                Employee peter = new Employee(6, "Peter");
                Employee porter = new Employee(7, "Porter");
                Employee milton = new Employee(8, "Milton");
                Employee nina = new Employee(9, "Nina");

                ceoBill.addReport(dom);
                ceoBill.addReport(sameer);
                ceoBill.addReport(micheal);

                dom.addReport(bob);
                dom.addReport(peter);
                dom.addReport(porter);

                peter.addReport(milton);
                peter.addReport(nina);


               //closestCommonManager(Milton, Nina) = Peter

                Employee employee = closestCommonManager(ceoBill, peter, nina);

                Console.Write(employee.getName());
                Console.ReadLine();
            }

        }

    }
}