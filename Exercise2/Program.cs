using System;
using System.Diagnostics;

namespace Exercise2
{
    class Program
    {
        /// <summary>
        /// Capture user input.
        /// </summary>
        /// <returns>User input</returns>
        static string GetInput() {
            Console.Write("Non negative real number: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Init and launch the main loop.
        /// </summary>
        /// <param name="A"></param>
        static void Driver(double A) {
            double epsilon = A * 10e-9;
            double trueValue = Math.Sqrt(A);
            double value = A;

            var start = DateTime.Now;

            while (value - trueValue > epsilon) {
                value = (value + A / value) / 2;
                Console.WriteLine($"Approximated square root of {A}: {value:0.00}");
            }

            var elapsed = DateTime.Now.Subtract(start).TotalSeconds;
            Console.WriteLine($"Elapsed time: {elapsed}s");
            Console.WriteLine($"\"True value\": {trueValue}s");
            Console.WriteLine($"Absolute Difference: {Math.Abs(trueValue - value)}");
        }
        
        static void Main(string[] args) {
            
            double A = 0;
            string input = GetInput();

            try {
                A = Double.Parse(input);
            }
            catch (Exception e) {
                Console.WriteLine($"{input} is not a valid value. Exit...");
                Environment.Exit(1);
            }
            
            Driver(A);
        }
    }
}