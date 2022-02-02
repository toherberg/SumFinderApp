using System;
using System.Collections.Generic;

namespace SumFinderApp
{
    public static class InputProcessor
    {
        private static int firstElement;
        private static int lastElement;
        private static int sum;
        private static string validationErrorMessage;

        public static int Sum { get => sum; }

        // method to get valid user input from keyboard and write it into app variables
        public static bool GetValidInformationFromUser()
        {
            Console.WriteLine("Enter first element of array:");
            if (int.TryParse(Console.ReadLine(), out firstElement))
            {
                if (firstElement < 0)
                {
                    validationErrorMessage = "Using of negative numbers is forbidden!";
                    return false;
                }
            }
            else
            {
                validationErrorMessage = "You input wrong value for firstElement value, it can't be parsed as int";
                return false;
            }

            Console.WriteLine("Enter last element of array");
            if (int.TryParse(Console.ReadLine(), out lastElement))
            {
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
            if (int.TryParse(Console.ReadLine(), out sum))
            {
                if (sum <= 0)
                {
                    validationErrorMessage = "It's not valid to enter 0 or negative number as sum value";
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

        public static void PrintValidationErrorMessage()
        {
            Console.WriteLine("Wrong input, please try again and enter valid values. Details: ");
            Console.WriteLine(validationErrorMessage);
        }

        // method to create collection of numbers, based on input values, where next element is greater by one than previous
        public static IEnumerable<int> CreateCollectionOfNumbersOnDefinedRange()
        {
            var result = new List<int>();
            for (int i = firstElement; i <= lastElement; i++)
            {
                result.Add(i);
            }
            return result;
        }

        // method allows user to restart or terminate program after each successful work cycle
        public static bool AskUserToRestartOrTerminate()
        {
            Console.WriteLine("Press 1 to restart. Any other input will terminate program: ");
            int userInput;
            int.TryParse(Console.ReadLine(), out userInput);
            if (userInput != 1)
            {
                return false;
            }
            return true;
        }
    }
}
