namespace Activity2
{
    // Define a Calculator class for arithmetic operations
    class Calculator
    {
        // Properties to store the two numbers
        public double Number1 { get; set; }
        public double Number2 { get; set; }

        // Constructor
        public Calculator(double num1, double num2)
        {
            Number1 = num1;
            Number2 = num2;
        }

        // Method to add numbers
        public double Add()
        {
            return Number1 + Number2;
        }

        // Method to subtract numbers
        public double Subtract()
        {
            return Number1 - Number2;
        }

        // Method to multiply numbers
        public double Multiply()
        {
            return Number1 * Number2;
        }

        // Method to divide numbers
        public double Divide()
        {
            return Number1 / Number2;
        }

        // Method to check if a number is even or odd
        public string CheckEvenOdd(double number)
        {
            if (number % 2 == 0)
                return "even";
            else
                return "odd";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Basic Calculator Program");
            Console.WriteLine("------------------------");

            // Get first number from user
            Console.Write("Enter the first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            // Get second number from user
            Console.Write("Enter the second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            // Create a Calculator object
            Calculator calc = new Calculator(num1, num2);

            // Perform calculations
            double sum = calc.Add();
            double difference = calc.Subtract();
            double product = calc.Multiply();
            double quotient = calc.Divide();

            // Display results
            Console.WriteLine($"\nResults:");
            Console.WriteLine($"Addition: {num1} + {num2} = {sum}");
            Console.WriteLine($"Subtraction: {num1} - {num2} = {difference}");
            Console.WriteLine($"Multiplication: {num1} * {num2} = {product}");
            Console.WriteLine($"Division: {num1} / {num2} = {quotient}");

            // Check if sum is even or odd
            string evenOddResult = calc.CheckEvenOdd(sum);
            Console.WriteLine($"\nThe sum {sum} is {evenOddResult}.");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
