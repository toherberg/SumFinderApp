using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SumFinderApp
{
    class Program
    {
        private static bool checkAgain = true;


        static void Main(string[] args)
        {

            while (checkAgain)
            {
                if (InputProcessor.GetValidInformationFromUser())
                {
                    var numbers = InputProcessor.CreateCollectionOfNumbersOnDefinedRange();
                    var matches = numbers.GetNumbersWhereDigitsMatchSum(InputProcessor.Sum);
                    matches.PrintReportAboutDigitsAdditionMatches(InputProcessor.Sum);
                    checkAgain = InputProcessor.AskUserToRestartOrTerminate();
                }
                else
                {
                    InputProcessor.PrintValidationErrorMessage();
                }

            }

            Console.WriteLine("Thanks for using, hope my app was helpful for you! See you later!");

        }
    }
}
