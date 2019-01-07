using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // run Manager until user exits
            bool moreCalcs = true;
            while (moreCalcs)
            {
                moreCalcs = Manager();
            }

        }

        static bool Manager()
        {
            // get inputs from user
            Console.Clear();
            Console.WriteLine("(Enter 'add', 'subtract', 'multiply', 'divide', or 'exit'.)");
            string operation = ValidateOperation(Console.ReadLine()); // save input to new variable 'operation'
            Console.WriteLine("Please enter first operand:");
            double num1 = ValidateNum(Console.ReadLine()); // collect input, validate, save to new variable 'num1'
            Console.WriteLine("Please enter second operand:");
            double num2 = ValidateNum(Console.ReadLine()); // collect input, validate, save to new variable 'num1'

            // set answer variable
            double answer;

            // route to appropriate operation function
            switch (operation)
            {
                case "add": // Route to Add function
                    answer = Add(num1, num2);
                    Console.WriteLine($"The sum of {num1} & {num2} is {answer}. (More? Press 'enter'.)");
                    break;
                case "subtract": // Route to Subtract function
                    answer = Subtract(num1, num2);
                    Console.WriteLine($"The difference of {num1} & {num2} is {answer}. (More? Press 'enter'.)");
                    break;
                case "multiply": // Route to Multiply function
                    answer = Multiply(num1, num2);
                    Console.WriteLine($"The product of {num1} & {num2} is {answer}. (More? Press 'enter'.)");
                    break;

                case "divide": // Route to Divide function
                    if (num2 == 0)
                    {
                        Console.WriteLine("Can't divide by 0.");
                    }
                    else
                    {
                        answer = Divide(num1, num2);
                        Console.WriteLine($"The quotient of {num1} & {num2} is {answer}. (More? Press 'enter'.)");
                    }
                    break;
                default:
                    break;
            }

            Console.ReadLine(); // keep console open until user exits
            return true; // user hasn't chosen 'exit' - run again

        }

        // validate user's inputs
        private static double ValidateNum(string input) // numeric inputs
        {
            double validInput = 0; // set return variable
            bool valid = false; // set validation loop condition

            while (!valid)
            {
                try
                {
                    validInput = Double.Parse(input); // parse input to double and save to new variable 'num1'
                    valid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Try again.");
                    input = Console.ReadLine();
                }
            }
            return validInput;
        }

        private static string ValidateOperation(string input) // numeric inputs
        {
            // loop for invalid inputs
            while (input != "add" && input != "subtract" && input != "multiply" && input != "divide" && input != "exit")
            {
                Console.WriteLine("Invalid input. Try again.");
                input = Console.ReadLine();
            }
            if(input == "exit")
            {
                System.Environment.Exit(0); // exit at user's command
            }
            else
            {
                return input; // continue to calculate
            }
        }


        // operation functions - pass in both operands to selected operation, return answer for display

        // add function
        private static double Add(double num1, double num2)
        {
            return (num1 + num2);
        }

        // subtract function
        private static double Subtract(double num1, double num2)
        {
            return (num1 - num2);
        }

        // multiply function
        private static double Multiply(double num1, double num2)
        {
            return (num1 * num2);
        }

        // divide function
        private static double Divide(double num1, double num2)
        {
            return (num1 / num2);
        }
    }
}
