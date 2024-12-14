using System;

namespace EmployeeManagementSystem
{
    // Represents an employee with basic details
    class Employee
    {
        // Unique identifier for the Employee
        public int Id { get; set; }
        // First name of the Employee
        public string FirstName { get; set; }
        // Last name of the Employee
        public string LastName { get; set; }

        // Defines equality based on the Employee's Id
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // Null handling to avoid referencing errors
            if (object.ReferenceEquals(emp1, null) || object.ReferenceEquals(emp2, null))
                return object.ReferenceEquals(emp1, emp2);

            // True if both IDs are the same
            return emp1.Id == emp2.Id;
        }

        // Necessary to define '!=' when '==' is overloaded
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        // Overrides the default Equals method
        public override bool Equals(object obj)
        {
            Employee other = obj as Employee;
            return other != null && this.Id == other.Id;
        }

        // Override GetHashCode as best practice when overriding Equals
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initialize two Employee objects with distinct names but the same ID
            Employee employee1 = new Employee { Id = 2, FirstName = "Alice", LastName = "Johnson" };
            Employee employee2 = new Employee { Id = 2, FirstName = "Bob", LastName = "King" };

            // Use the overloaded equality operator to check if they are considered the same
            bool areEqual = employee1 == employee2;

            // Output the result of the equality check
            Console.WriteLine("Are Employee 1 and Employee 2 considered equal? " + areEqual);
        }
    }
}
