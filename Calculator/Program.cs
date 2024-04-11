// See https://aka.ms/new-console-template for more information
/*
bool repeatGame = true;
while (repeatGame)
{

    double num1 = 0, num2 = 0;


    Console.WriteLine("Console Calculator in C#\r");
    Console.WriteLine("------------------------\n");

    Console.WriteLine("Type a number, and then press Enter: ");
    num1 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Type a second number, and then press Enter: ");
    num2 = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Choose an option from the list:");
    Console.WriteLine("\ta - Add");
    Console.WriteLine("\ts - Subtract");
    Console.WriteLine("\tm - Multiply");
    Console.WriteLine("\td - Divide");
    Console.Write("Your option? ");

    switch (Console.ReadLine())
    {
        case "a":
            Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
            break;
        case "s":
            Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
            break;
        case "m":
            Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
            break;
        case "d":
            while (num2 == 0)
            {
                Console.WriteLine("Enter a non-zero divisor: ");
                num2 = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
            break;
    }

    Console.WriteLine("Would you like to play again? y or n ");
    char userYorN = Convert.ToChar(Console.ReadLine());
    if (userYorN == 'y')
    {
        repeatGame = true;
        Console.WriteLine();
    }

    else { repeatGame = false;
        Console.Write("Press any key to close the Calculator console app.");
        Console.ReadKey();
    }
}
*/

using System.Text.RegularExpressions;

class Calculator
{
    public static double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.

        switch (op)
        {
            case "a":
                result = num1 + num2;
                break;
            case "s":
                result = num2 - num1;
                break;
            case "m":
                result = num1 * num2;
                break;
            case "d":
                // check for divide by zero
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {
            // Declare variables set to empty.
            // Use Nullable types (with ?) to match type of System.Console.ReadLine
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            // Ask user for the first number.
            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numerical value: ");
                numInput1 = Console.ReadLine();
            }

            // Ask the user for a second number.
            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a numerical value: ");
                numInput2 = Console.ReadLine();
            }

            // Ask the user to choose an operator.
            Console.WriteLine("Choose an operator from the list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            string? op = Console.ReadLine();

            // Validate input is not null, and matches the pattern
            if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else
            {
                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                    // same as else Console.WriteLine($"Your result: {result:0.##}\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
            }
            Console.WriteLine("------------------------\n");

            // Wait for the user to respond before closing.
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n")
            {
                endApp = true;
            }
            Console.WriteLine();
        }
        return;
    }
}