namespace Activity5
{
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

        // Method to divide numbers with exception handling
        public double Divide()
        {
            if (Number2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero!");
            }
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
            Console.WriteLine("Calculator with Exception Handling");
            Console.WriteLine("----------------------------------");

            try
            {
                // Get first number from user with validation
                double num1 = GetValidNumber("Enter the first number: ");

                // Get second number from user with validation
                double num2 = GetValidNumber("Enter the second number: ");

                // Create a Calculator object
                Calculator calc = new Calculator(num1, num2);

                // Perform calculations with exception handling
                double sum = calc.Add();
                double difference = calc.Subtract();
                double product = calc.Multiply();
                double quotient = 0;

                try
                {
                    quotient = calc.Divide();
                    Console.WriteLine($"Division: {num1} / {num2} = {quotient}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Division Error: {ex.Message}");
                }

                // Display results
                Console.WriteLine($"\nResults:");
                Console.WriteLine($"Addition: {num1} + {num2} = {sum}");
                Console.WriteLine($"Subtraction: {num1} - {num2} = {difference}");
                Console.WriteLine($"Multiplication: {num1} * {num2} = {product}");

                // Check if sum is even or odd
                string evenOddResult = calc.CheckEvenOdd(sum);
                Console.WriteLine($"\nThe sum {sum} is {evenOddResult}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Helper method to get a valid number from the user
        static double GetValidNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                try
                {
                    return Convert.ToDouble(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number is too large or too small.");
                }
            }
        }
    }
}
