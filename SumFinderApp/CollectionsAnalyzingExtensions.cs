using System;
using System.Collections.Generic;
using System.Linq;

namespace SumFinderApp
{

    // here we have set of extensions and additional private methods to perform operations with collections
    public static class CollectionsAnalyzingExtensions
    {

        // method returns collection of numbers where digits sum = predefined by user sum or returns empty one if there wasn't any match
        public static IEnumerable<int> GetNumbersWhereDigitsMatchSum(this IEnumerable<int> numbers, int sum)
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

        // method prints numbers, that match our conditions (sum of digis = sum) or informs that there wasn't any
        public static void PrintReportAboutDigitsAdditionMatches(this IEnumerable<int> matches, int sum)
        {
            Console.WriteLine($"The program caclucated each number digits addition and checked for equality with {sum}. Result: ");

            if (matches.Count() > 0)
            {
                Console.WriteLine("Collection elements that match requirments:");
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine($"There wasn't found any numbers on range, where digits sum = {sum}");
            }
        }

    }
}
