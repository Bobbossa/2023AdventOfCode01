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
                //Console.WriteLine(testString);
                testString = StripLettersFromString(testString);
                //Console.WriteLine(testString);
                processedInts.Add(ConvertStringToNumber(testString));
                foreach (int i in processedInts) {
                    finalTotal += i;
                }
                Console.WriteLine(finalTotal);
            }

            Console.WriteLine("End of Test");


            /*
            try {
                
                
                // Open the text file using a stream reader.
                using (var sr = new StreamReader("C:\\VirtualStudioProjects\\2023AdventOfCode01\\2023AOC01Input.txt")) {
                    // Read the stream as a string, and write the string to the console.
                    Console.WriteLine(sr.ReadLine());
                    Console.WriteLine(sr.ReadLine());
                }
            }
            catch (IOException e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }*/
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
                //Console.WriteLine(input[x]);
                for (int y = 0; y < regularDigits.Length; y++) {
                    if (input[x] == regularDigits[y]) {
                        //output.Append<char>(input[x]);
                        output += input[x];
                        //Console.WriteLine(output);
                    }
                }
            }
            //Console.WriteLine(output);
            return output;
        }

        static string StripMiddleCharactersFromString(string input) {
            string output = "";
            
            
            return output;
        }

        static int ConvertStringToNumber(string input) {
            int output;
            output = int.Parse(input);
            return output;
        }

        
    }
}
