namespace Activity4
{
    // Base class: Student
    class Student
    {
        // Properties
        public string Name { get; set; }
        public int ID { get; set; }
        public double Marks { get; set; }

        // Constructor
        public Student(string name, int id, double marks)
        {
            Name = name;
            ID = id;
            Marks = marks;
        }

        // Method to calculate grade based on marks
        public string GetGrade()
        {
            if (Marks >= 90)
                return "A";
            else if (Marks >= 80)
                return "B";
            else if (Marks >= 70)
                return "C";
            else if (Marks >= 60)
                return "D";
            else
                return "F";
        }

        // Method to display student details
        public virtual void DisplayDetails()
        {
            Console.WriteLine("Student Details:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Marks: {Marks}");
            Console.WriteLine($"Grade: {GetGrade()}");
        }
    }

    // Derived class: StudentIITGN
    class StudentIITGN : Student
    {
        // Additional property
        public string Hostel_Name_IITGN { get; set; }

        // Constructor
        public StudentIITGN(string name, int id, double marks, string hostelName)
            : base(name, id, marks) // Call base class constructor
        {
            Hostel_Name_IITGN = hostelName;
        }

        // Override the DisplayDetails method
        public override void DisplayDetails()
        {
            base.DisplayDetails(); // Call the base class method
            Console.WriteLine($"Hostel: {Hostel_Name_IITGN}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Object-Oriented Programming Demo");
            Console.WriteLine("--------------------------------");

            // Create a regular Student object
            Student regularStudent = new Student("John Doe", 12345, 85);
            regularStudent.DisplayDetails();

            Console.WriteLine("\n");

            // Create an IITGN Student object
            StudentIITGN iitgnStudent = new StudentIITGN("Jane Smith", 67890, 92, "Dudhsagar");
            iitgnStudent.DisplayDetails();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
