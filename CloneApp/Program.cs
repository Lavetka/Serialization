namespace Clone
{
    class Program
    {
        static void Main()
        {
            Department originalDepartment = new Department("IT");
            originalDepartment.Employees.Add(new Employee("Hleb1", 1));
            originalDepartment.Employees.Add(new Employee("Hleb2", 2));

            Department clonedDepartment = DeepCopyHelper.DeepCopy(originalDepartment);

            clonedDepartment.DepartmentName = "IT2";
            clonedDepartment.Employees[0].EmployeeName = "Modified Hleb";
            clonedDepartment.Employees[0].EmployeeId = 5;

            Department clonedDepartmentTwo = DeepCopyHelper.DeepCopy(originalDepartment);

            Console.WriteLine("Original Department:");
            DisplayDepartmentInfo(originalDepartment);

            Console.WriteLine("\nCloned Department with changes:");
            DisplayDepartmentInfo(clonedDepartment);

            Console.WriteLine("\nCloned Department with no changes:");
            DisplayDepartmentInfo(clonedDepartmentTwo);


        }

        static void DisplayDepartmentInfo(Department department)
        {
            Console.WriteLine($"Department Name: {department.DepartmentName}");

            Console.WriteLine("Employees:");
            foreach (var employee in department.Employees)
            {
                Console.WriteLine($" - {employee.EmployeeName} (ID: {employee.EmployeeId})");
            }

            Console.WriteLine();
        }
    }
}