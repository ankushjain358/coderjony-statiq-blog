Title: Passing by value & passing by reference in C# using Reference Types
Published: 16/04/2019
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
## Case 1: 

Both are same.

```
    public class Program
    {
            static void Main()
            {
                Employee employee;

                employee = new Employee();
                PopulateEmployee(employee);
                Console.WriteLine($"Sr.No: {employee.SrNo} & Name: {employee.Name}");

                employee = new Employee();
                PopulateEmployeeByRef(ref employee);
                Console.WriteLine($"Sr.No: {employee.SrNo} & Name: {employee.Name}");

                Console.ReadLine();
            }

            public static void PopulateEmployee(Employee employee)
            {
                //employee = new Employee();
                employee.SrNo = 1;
                employee.Name = "Ankush Jain";
            }

            public static void PopulateEmployeeByRef(ref Employee employee)
            {
                //employee = new Employee();
                employee.SrNo = 1;
                employee.Name = "Ankush Jain";
            }
    }

    public class Employee
    {
            public int SrNo { get; set; }
            public string Name { get; set; }
    }
    ```

## Case 2:

Instantiation of the parameter in passing by reference actually changes the value of properties of passed argument while passing by value does not.

```
    public class Program
    {
            static void Main()
            {
                Employee employee;

                employee = new Employee();
                PopulateEmployee(employee);
                Console.WriteLine($"Sr.No: {employee.SrNo} & Name: {employee.Name}");

                employee = new Employee();
                PopulateEmployeeByRef(ref employee);
                Console.WriteLine($"Sr.No: {employee.SrNo} & Name: {employee.Name}");

                Console.ReadLine();
            }

            public static void PopulateEmployee(Employee employee)
            {
                employee = new Employee();
                employee.SrNo = 1;
                employee.Name = "Ankush Jain";
            }

            public static void PopulateEmployeeByRef(ref Employee employee)
            {
                employee = new Employee();
                employee.SrNo = 1;
                employee.Name = "Ankush Jain";
            }
    }

    public class Employee
    {
            public int SrNo { get; set; }
            public string Name { get; set; }
    }
    ```

* * *

**Reference:** [https://stackoverflow.com/a/1293120/1273882](https://stackoverflow.com/a/1293120/1273882)

                