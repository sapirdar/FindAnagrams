using System;
using System.Collections.Generic;

namespace FindAnagram
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                // Init the data
                AnagramList.Init();

                Console.WriteLine("Please type an input of an alphanumerical 5 characters long");
                string input = Console.ReadLine();

                // Validate input
                while (!AnagramList.ValidateInput(input))
                {
                    // Show an error ask for a valid input
                    Console.WriteLine("Input was not in the right format (5 characters alphanumerical)");
                    input = Console.ReadLine();
                }

                // Get the search results
                List<string> anagrams = AnagramList.FindAnagrams(input);
                while (anagrams == null)
                {
                    Console.WriteLine("No anagrams found, Try another string");
                    input = Console.ReadLine();
                    anagrams = AnagramList.FindAnagrams(input);
                }
                Console.WriteLine($"{anagrams.Count} found:");

                anagrams.ForEach(str =>
                {
                    Console.WriteLine(str);
                });

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // TODO: log error
                Console.WriteLine("An error as occured");
            }
        }




    }
}
