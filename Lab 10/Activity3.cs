namespace Activity3
{
    class LoopsAndFunctions
    {
        // Method to print numbers from 1 to n using a for loop
        public void PrintNumbers(int n)
        {
            Console.WriteLine($"Printing numbers from 1 to {n}:");
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n");
        }

        // Method to get user input until they type "exit"
        public void GetUserInputUntilExit()
        {
            string userInput = "";
            Console.WriteLine("Enter text (type 'exit' to quit):");

            while (userInput.ToLower() != "exit")
            {
                userInput = Console.ReadLine();
                if (userInput.ToLower() != "exit")
                {
                    Console.WriteLine($"You entered: {userInput}");
                }
            }
            Console.WriteLine("Exiting input loop.\n");
        }

        // Method to calculate factorial of a number
        public long CalculateFactorial(int number)
        {
            if (number < 0)
                return -1; // Error for negative numbers

            if (number == 0 || number == 1)
                return 1;

            long factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loops and Functions Demo");
            Console.WriteLine("------------------------");

            // Create an instance of our class
            LoopsAndFunctions demo = new LoopsAndFunctions();

            // Activity 1: Print numbers from 1 to 10 using a for loop
            demo.PrintNumbers(10);

            // Activity 2: Get user input until they type "exit" using a while loop
            demo.GetUserInputUntilExit();

            // Activity 3: Calculate factorial of a user-provided number
            Console.Write("Enter a number to calculate its factorial: ");
            int number = Convert.ToInt32(Console.ReadLine());
            long factorial = demo.CalculateFactorial(number);

            if (factorial == -1)
                Console.WriteLine("Cannot calculate factorial of a negative number.");
            else
                Console.WriteLine($"The factorial of {number} is {factorial}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

