using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise4
{
    class Program
    {
        static IEnumerable<int>[] PairImpair(int[] values) {
            return new[] {
                values.Where(i => i % 2 == 1), 
                values.Where(i => i % 2 == 0)
            };
        }

        static void Main(string[] args) {
            const int COUNT = 20;
            
            var values = new int[COUNT];
            var rnd = new Random();
            
            for (int i = 0; i < COUNT; i++) {
                values[i] = rnd.Next(1, 99);
            }

            var splitted = PairImpair(values);

            Console.Write("Valeurs à séparer: ");
            foreach (var i in values) Console.Write($"{i} ");
            Console.Write("\nPair: ");
            foreach (var i in splitted[0]) Console.Write($"{i} ");
            Console.Write("\nImpaire: ");
            foreach (var i in splitted[1]) Console.Write($"{i} ");
        }
    }
}