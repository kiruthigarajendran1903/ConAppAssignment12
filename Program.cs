using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ConAppAssignment12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a piece of text:");
            string inputText = Console.ReadLine();

            // Count words
            int wordCount = CountWords(inputText);
            Console.WriteLine($"Word count: {wordCount}");

            // Validate email addresses
            List<string> emailAddresses = GetEmailAddresses(inputText);
            if (emailAddresses.Count > 0)
            {
                Console.WriteLine("Email addresses found:");
                foreach (var email in emailAddresses)
                {
                    Console.WriteLine(email);
                }
            }
            else
            {
                Console.WriteLine("No email addresses found.");
            }

            // Extract mobile numbers
            List<string> mobileNumbers = GetMobileNumbers(inputText);
            if (mobileNumbers.Count > 0)
            {
                Console.WriteLine("Mobile numbers found:");
                foreach (var number in mobileNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("No mobile numbers found.");
            }

            // Custom regex search
            Console.WriteLine("Enter a custom regular expression:");
            string customRegex = Console.ReadLine();
            List<string> customMatches = PerformCustomRegexSearch(inputText, customRegex);
            if (customMatches.Count > 0)
            {
                Console.WriteLine("Custom regex matches found:");
                foreach (var match in customMatches)
                {
                    Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine("No matches found for the custom regex.");
            }
            Console.ReadKey();
        }

        static int CountWords(string text)
        {
            return text.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        static List<string> GetEmailAddresses(string text)
        {
            List<string> emailAddresses = new List<string>();
            string emailPattern = @"[\w\.-]+@[\w\.-]+\.\w+";
            MatchCollection matches = Regex.Matches(text, emailPattern);

            foreach (Match match in matches)
            {
                emailAddresses.Add(match.Value);
            }

            return emailAddresses;
        }

        static List<string> GetMobileNumbers(string text)
        {
            List<string> mobileNumbers = new List<string>();
            string mobilePattern = @"\d{10}";
            MatchCollection matches = Regex.Matches(text, mobilePattern);

            foreach (Match match in matches)
            {
                mobileNumbers.Add(match.Value);
            }

            return mobileNumbers;
        }

        static List<string> PerformCustomRegexSearch(string text, string customRegex)
        {
            List<string> customMatches = new List<string>();
            MatchCollection matches = Regex.Matches(text, customRegex);

            foreach (Match match in matches)
            {
                customMatches.Add(match.Value);
            }

            return customMatches;
        }
    }

}
  