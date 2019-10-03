using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args) {
            string s1 = "Hello World";
            string s2 = "Hello World";
            string s3 = s1;

            Console.WriteLine("\ns1 vs s2");
            Console.WriteLine($"  Equals: {s1.Equals(s2)}");
            Console.WriteLine($"  CompareTo: {s1.CompareTo(s2)}");
            Console.WriteLine($"  ReferenceEquals: {ReferenceEquals(s1, s2)}");
            
            Console.WriteLine("\ns1 vs s3");
            Console.WriteLine($"  Equals: {s1.Equals(s3)}");
            Console.WriteLine($"  CompareTo: {s1.CompareTo(s3)}");
            Console.WriteLine($"  ReferenceEquals: {ReferenceEquals(s1, s3)}");            
            
            Console.WriteLine("\ns2 vs s3");
            Console.WriteLine($"  Equals: {s2.Equals(s3)}");
            Console.WriteLine($"  CompareTo: {s2.CompareTo(s3)}");
            Console.WriteLine($"  ReferenceEquals: {ReferenceEquals(s2, s3)}");
            
            Console.WriteLine("\n=== UPDATING S3 VALUE ===");
            s3 += '!';
            
            Console.WriteLine("\ns1 vs s2");
            Console.WriteLine($"  Equals: {s1.Equals(s2)}");
            Console.WriteLine($"  CompareTo: {s1.CompareTo(s2)}");
            Console.WriteLine($"  ReferenceEquals: {ReferenceEquals(s1, s2)}");
            
            Console.WriteLine("\ns1 vs s3");
            Console.WriteLine($"  Equals: {s1.Equals(s3)}");
            Console.WriteLine($"  CompareTo: {s1.CompareTo(s3)}");
            Console.WriteLine($"  ReferenceEquals: {ReferenceEquals(s1, s3)}");            
            
            Console.WriteLine("\ns2 vs s3");
            Console.WriteLine($"  Equals: {s2.Equals(s3)}");
            Console.WriteLine($"  CompareTo: {s2.CompareTo(s3)}");
            Console.WriteLine($"  ReferenceEquals: {ReferenceEquals(s2, s3)}");
            
            
            // Equals: Comparaison de contenu.
            
            // CompareTo: Comparaison utile dans le cadre d'un tri.'
            
            // ReferenceEquals: Comparaison de références. Les résultats de la comparaison entre
            // (s1 et s2) ainsi que (s2 et s3) sont donc remarquables. Après quelques recherches,
            // ce comportement est expliqué par le fait que le CLR garde une table "intern pool"
            // qui contient une référence unique pour chaque expression litérale declarée ou générée
            // pendant l'exécution. Donc effectivement, s1, s2 et s3 ont la même référence tant qu'ils ont
            // la même valeur. Lors de l'update de la valuer de s3, s1 n'est pas affecté et démontre que
            // le mécanisme d'optimisation précédament expliqué fonctionne bien. ''
        }
    }
}