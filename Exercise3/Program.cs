using System;
using System.IO;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args) {

            const string fileName = "Mesures.txt";
            int counter = 1;

            using (StreamReader file = new StreamReader(fileName)) {
                string line;
                while ((line = file.ReadLine()) != null) {
                    string sep = counter++ % 10 != 0 ? ", " : "\n";
                    Console.Write($"{line}{sep}");
                }
            }
        }
    }
}