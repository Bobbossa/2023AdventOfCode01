﻿
namespace _2023AdventOfCode01 {

    internal class Program {
        //static string[] regularDigits = ["0","1","2","3","4","5","6","7","8","9"];
        static char[] regularDigits = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
        static Dictionary<string, string> digitDic = new Dictionary<string, string>();
        //static string[] digitDic = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        static List<int> processedInts = new List<int>();
        static int finalTotal = 0;

        static void Main() {
            //Build dictionary.
            digitDic.Add("0","zero");
            digitDic.Add("1", "one");
            digitDic.Add("2", "two");
            digitDic.Add("3", "three");
            digitDic.Add("4", "four");
            digitDic.Add("5", "five");
            digitDic.Add("6", "six");
            digitDic.Add("7", "seven");
            digitDic.Add("8", "eight");
            digitDic.Add("9", "nine");


            Console.ForegroundColor = ConsoleColor.Green;
            string stringToProcess = "processing file...";
            using (var sr = new StreamReader("2023AOC01Input.txt"))

                while (stringToProcess != null) {                
                Console.WriteLine(stringToProcess);
                if (CheckTextLineForNumbers(stringToProcess)) {
                    stringToProcess = StripLettersFromString(stringToProcess);
                    stringToProcess = StripMiddleCharactersFromString(stringToProcess);
                    processedInts.Add(ConvertStringToInt(stringToProcess));                    
                }
                //Goes to the next line in the file.
                stringToProcess = sr.ReadLine();
            }

            //Sums all the aquired values.
            foreach (int i in processedInts) {
                finalTotal += i;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Total = " + finalTotal);
            ReadPartialString("pleasework", 1, 4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("...processing complete.");
        }
        
        //Checks to see if there are any numbers in the string.
        static bool CheckTextLineForNumbers(string input) {
            foreach (char digit in regularDigits) {
                if (input.Contains(digit)) {
                    return true;
                }
            }
            return false;
        }
        
        //Removes all characters from a string that are not containted within 'regularDigits[]'.
        static string StripLettersFromString(string input) {
            string output = "";
            for (int x = 0; x < input.Length; x++) {
                for (int y = 0; y < regularDigits.Length; y++) {
                    if (input[x] == regularDigits[y]) {
                        output += input[x];
                    }
                }
            }
            return output;
        }

        //Removes all characters from a string that are not the first character or the last character. Always returns a 2 character string. So input 7 would be returned as 77.
        static string StripMiddleCharactersFromString(string input) {
            string output = "";
            output += input[0];
            if(input.Length > 1) {
                output += input[input.Length - 1];
            }
            else {
                output += output;
            }            
            return output;
        }

        static int ConvertStringToInt(string input) {
            int output = int.Parse(input);
            return output;
        }

        static string ReadPartialString(string wholeString, int startIndex, int selectionSize = 1) {
            string partialString = "";
            int loopCount = 0;
            //Reduces selectionSize if it would exceed the dimensions of the array.
            if (wholeString.Length < startIndex + 1 + selectionSize) {
                selectionSize = wholeString.Length - startIndex;
            }
            while (loopCount < selectionSize) {
                partialString += wholeString[startIndex + loopCount];
                loopCount++;
                Console.WriteLine(partialString);
            }
            return partialString;
        }

        //untested
        static string CompareStringToDictionary(string input, Dictionary<string, string> dic) {
            foreach (KeyValuePair<string,string> kvp in dic) {
                if (input.Contains(kvp.Key)) {
                    return kvp.Key;
                }
                if (input.Contains(kvp.Value)) {
                    return kvp.Value;
                }
            }
            return null;
        }
    }
}
