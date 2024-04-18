
/*
 * Tutorial from:
 * https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-console?view=vs-2022#revise-the-code
 * 
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


using CalculatorLibrary;
using System.Text.RegularExpressions;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            Calculator calculator = new Calculator();

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

                string? op = null;

                // Loop if the user inputs the wrong operator
                while (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
                {
                    // Ask the user to choose an operator.
                    Console.WriteLine("Choose an operator from the list:");
                    Console.WriteLine("\ta - Add");
                    Console.WriteLine("\ts - Subtract");
                    Console.WriteLine("\tm - Multiply");
                    Console.WriteLine("\td - Divide");
                    Console.Write("Your option? ");

                    op = Console.ReadLine();

                    // Validate input is not null, and matches the pattern
                    if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
                    {
                        Console.WriteLine("Error: Unrecognized input. Please try again: \n");
                    }

                    else
                    {
                        try
                        {
                            // result = CalculatorLibrary.Calculator.DoOperation(cleanNum1, cleanNum2, op);
                            result = calculator.DoOperation(cleanNum1, cleanNum2, op);
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
            // Add call to close the JSON writer before return.
            calculator.Finish();
            return;
        }
    }
}