using System;
using System.Collections.Generic;
using System.Linq;

namespace SumFinderApp
{
    class Program
    {
        private static int firstElement;
        private static int lastElement;
        private static int sum;
        private static string validationErrorMessage;

        private static bool checkAgain = true;

        static void Main(string[] args)
        {

            while (checkAgain)
            {
                validationErrorMessage = string.Empty;
                if (GetValidInformationFromUser())
                {
                    var numbers = CreateArrayOnRange(firstElement, lastElement); 
                    var matches = GetNumbersWhereDigitsMatchSum(numbers, sum);

                    PrintResultOfOperation(matches);
                    AskUserToRestartOrTerminate();
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again and enter valid values. Details: ");
                    Console.WriteLine(validationErrorMessage); 
                }

            }

            Console.WriteLine("Thanks for using, hope my app was helpful for you! See you later!");

        }

        // method to get valid user input from keyboard and write it into app variables
        private static bool GetValidInformationFromUser()
        {
            Console.WriteLine("Enter first element of array:");
            if (int.TryParse(Console.ReadLine(), out firstElement))
            {
                if (firstElement < 0)
                {
                    validationErrorMessage = "First element must positive number or 0";
                    return false;
                }
            }
            else
            {
                validationErrorMessage = "You input wrong value for firstElement value, it can't be parsed as int";
                return false;
            }

            Console.WriteLine("Enter last element of array");
            if(int.TryParse(Console.ReadLine(), out lastElement))
            {
                if (lastElement < 1)
                {
                    validationErrorMessage = "Last element has to be above 0";
                    return false;
                }
                if (lastElement <= firstElement)
                {
                    validationErrorMessage = "Last element can't be less than first or the same";
                    return false;
                }
            }
            else
            {
                validationErrorMessage = "You input wrong value for lastElement, it can't be parsed as int";
                return false;
            }

            Console.WriteLine("Enter sum parameter to check array elements: ");
            if(int.TryParse(Console.ReadLine(), out sum))
            {
                if (sum <= 0)
                {
                    validationErrorMessage= "It's not valid to enter 0 or negative number as sum value";
                    return false;
                }
            }
            else
            {
                validationErrorMessage = "You input wrong value for sum, it can't be parsed as int";
                return false;
            }

            return true;
        }

        // method allows user to restart or terminate program after each successful work cycle
        private static void AskUserToRestartOrTerminate()
        {
            Console.WriteLine("1 to restart. Any other input will terminate program: ");
            int userInput;
            int.TryParse(Console.ReadLine(), out userInput);
            if (userInput != 1)
            {
                checkAgain = false;
            }
        }

        // method to create collection of numbers, where next element is greater by one than previous
        private static IEnumerable<int> CreateArrayOnRange(int first, int last)
        {
            var result = new List<int>();
            for (int i = first; i <= last; i++)
            {
                result.Add(i);
            }
            return result;
        }

        // method returns collection of numbers where digits sum = predefined by user sum or returns empty one if there wasn't any match
        private static IEnumerable<int> GetNumbersWhereDigitsMatchSum(IEnumerable<int> numbers, int sum)
        {
            var result = new List<int>();

            foreach (var number in numbers)
            {
                if (GetNumberDigitsSum(number) == sum)
                {
                    result.Add(number);
                }
            }

            return result;
        }

        // method prints numbers, that match our conditions (sum of digis = sum) or informs that there wasn't any
        private static void PrintResultOfOperation(IEnumerable<int> matches)
        {
            Console.WriteLine("The program checked elements and here your result: ");

            if (matches.Count() > 0)
            {
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine($"There are no matches with sum: {sum} on range from {firstElement} to {lastElement}");
            }
        }



        // method gets each digit of number and returns result of their addition (666 - 6 + 6 + 6 = 18)
        private static int GetNumberDigitsSum(int number)
        {
            var sum = 0;
            var index = 10;

            while (index <= number)
            {
                var element = number % index;
                sum += element;
                number = (number - element) / index;
            }

            return sum + number;
        }
    }
}
