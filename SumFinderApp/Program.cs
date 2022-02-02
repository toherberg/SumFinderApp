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

        private static bool checkAgain = true;

        static void Main(string[] args)
        {

            while (checkAgain)
            {

                if (GetInformationFromUser())
                {
                    var numbers = CreateArrayOnRange(firstElement, lastElement); 
                    var matches = GetNumbersWhereDigitsMatchSum(numbers, sum);

                    PrintResultOfOperation(matches);
                    AskUserToRestartOrTerminate();
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again and enter valid valid values!");
                }

            }

            Console.WriteLine("Thanks for using, hope my app was helpful for you! See you later!");

        }

        // method to get valid user input from keyboard and write it into app variables
        private static bool GetInformationFromUser()
        {
            Console.WriteLine("Enter first element of array:");
            int.TryParse(Console.ReadLine(), out firstElement);

            Console.WriteLine("Enter last element of array");
            int.TryParse(Console.ReadLine(), out lastElement);

            Console.WriteLine("Enter sum parameter to check array elements: ");
            int.TryParse(Console.ReadLine(), out sum);

            if ((firstElement >= 0 && lastElement > 0) && (firstElement < lastElement) && (sum > 0))
            {
                return true;
            }
            return false;
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
