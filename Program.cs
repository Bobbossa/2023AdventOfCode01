using System;
using System.Linq;
using System.Reflection.Metadata;

namespace _2023AdventOfCode01 {

    internal class Program {
        //static char[] regularDigits = ["0","1","2","3","4","5","6","7","8","9"];
        static char[] regularDigits = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
        static List<int> processedInts = new List<int>();
        static int finalTotal = 0;

        static void Main() {
            string testString;
            using (var sr = new StreamReader("C:\\VirtualStudioProjects\\2023AdventOfCode01\\2023AOC01Input.txt"))
            testString = sr.ReadLine();
            if (CheckTextLineForNumbers(testString)) {
                testString = StripLettersFromString(testString);
                testString = StripMiddleCharactersFromString(testString);
                processedInts.Add(ConvertStringToNumber(testString));
                foreach (int i in processedInts) {
                    finalTotal += i;
                }
                Console.WriteLine(finalTotal);
            }

            Console.WriteLine("End of Test");
        }

        static bool CheckTextLineForNumbers(string input) {
            foreach (char digit in regularDigits) {
                if (input.Contains(digit)) {
                    return true;
                }
            }
            return false;
        }

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

        static int ConvertStringToNumber(string input) {
            int output;
            output = int.Parse(input);
            return output;
        }

        
    }
}
