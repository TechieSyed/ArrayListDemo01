using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
namespace ArrayListDemo01
{
    class Employee : IComparable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Employee()
        {

        }
        public Employee(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public override string ToString()
        {
            return string.Format("ID= {0} Name= {1}", this.ID, this.Name);
        }

        public int CompareTo(object obj)
        {
            Employee e = obj as Employee;
            return this.ID.CompareTo(e.ID);
        }

        public override bool Equals(object obj)
        {
            Employee e = obj as Employee;
            return this.ID == e.ID;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    class EmployeeComparer : IComparer
    {        
        //x==y return 0
        //x>y return 1
        //x<y return -1
        public int Compare(object x, object y)
        {
            Employee e = x as Employee;
            Employee e1 = y as Employee;
            //if (e.ID == e1.ID)
            //    return 0;
            //else if (e.ID > e1.ID)
            //    return 1;
            //else
            //    return -1;
            return e.ID.CompareTo(e1.ID);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Employees = new ArrayList();
            Employees.Add(new Employee(102, "Sam"));
            Employees.Add(new Employee(101, "Jojo"));
            Employees.Add(new Employee(100, "Sarah"));
            //Employees.Add(10); //Generates runtime error when trying to convert to employee during iteration

            Console.WriteLine("Total employees : " + Employees.Count);
            foreach(object obj in Employees)
            {
                Employee e = obj as Employee;
                //Console.WriteLine(e.ID + " " + e.Name);
                Console.WriteLine(e.ToString());
            }

            //Employees.Sort(new EmployeeComparer());
            Employees.Sort(); //only works if Employee class implements IComparable interface
            Employee emp;
            Console.WriteLine("Employees list after sort");
            foreach (object obj in Employees)
            {
                emp = obj as Employee;
                Console.WriteLine(emp.ToString());
            }


            Employee temp = new Employee(101, "Jojo");
            int index = Employees.BinarySearch(temp);
            if (index >= 0)
            {
                Console.WriteLine("Employee found");
                var e = Employees[index] as Employee;
                Console.WriteLine(e.ToString());
            }
            else
            {
                Console.WriteLine("Employee not found");
            }

            Employees.Remove(temp);
            Console.WriteLine("After removing {0}", temp);
            foreach (object obj in Employees)
            {
                emp = obj as Employee;
                Console.WriteLine(emp.ToString());
            }


            Console.ReadKey();
        }
    }
}
