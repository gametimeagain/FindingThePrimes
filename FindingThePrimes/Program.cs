using FindingThePrimes.Services;
using System;
using System.Collections.Generic;

namespace FindingThePrimes {
    class Program {

        static void Main(string[] args) {

            PrimeService primes = new();
            var primeList = primes.GetPrimes(150, 1000);

            SearchService searchFast = new();
            List<(string, int[])> fastResult = searchFast.FindMatchingProducts(primeList, 4);

            Console.WriteLine($"{fastResult.Count} results found in {searchFast.TimeElapsed}");
            foreach ((string product, int[] p) in fastResult) {
                Console.WriteLine($"{product} = {p[0]} *  {p[1]} *  {p[2]} *  {p[3]}");
            }

            Console.Read();

        }


    }

}
