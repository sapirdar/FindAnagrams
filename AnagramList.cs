using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FindAnagram
{
    public class AnagramList
    {

        private static List<string> Words = new List<string>();

        //A dictionary of a sorted chars string and a list of ita anagrams in the file
        private static Dictionary<string, List<string>> AnagramsDictionary = new Dictionary<string, List<string>>();

        public static void Init()
        {
            try
            {
                // Load the string list from the txt file
                LoadDataFromFile();

                Words.ForEach(str =>
                {
                    // Sort chars in the string
                    string sorted = SortString(str);

                    if (AnagramsDictionary.ContainsKey(sorted))
                    {
                        // Sorted word exists, add it to the dictionart value
                        AnagramsDictionary[sorted].Add(str);
                    }
                    else
                    {
                        AnagramsDictionary.Add(sorted, new List<string>() { str });
                    }

                });
            }
            catch (Exception)
            {
                //TODO: Log error
                throw;
            }
        }

        // Find the anagrams in the initialized data set
        public static List<string> FindAnagrams(string input)
        {
            List<string> res = null;

            // Sort input string to find in the dictionary:
            string sorted = SortString(input);
            if(AnagramsDictionary.ContainsKey(sorted))
            {
                res = AnagramsDictionary[sorted];
            }

            return res;
        }

        // Validate alphanumeric 5 characters
        public static bool ValidateInput(string input)
        {
            if (input.Length != 5)
            {
                return false;
            }
            else
            {
                Regex alphanumericRegex = new Regex("^[a-zA-Z0-9]*$");
                if (!alphanumericRegex.IsMatch(input))
                {
                    return false;
                }
            }
            return true;
        }

        private static string SortString(string str)
        {
            char[] chars = str.ToLower().ToCharArray();
            Array.Sort(chars);
            string sorted = new string(chars);
            return sorted;
        }

        private static void LoadDataFromFile()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"data.txt");

                foreach (string line in lines)
                {
                    Words.Add(line);
                }
            }
            catch (Exception)
            {
                //TODO: Log error
                throw;
            }

        }
    }
}
