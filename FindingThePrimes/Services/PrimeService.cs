using System.Collections.Generic;
using System.Linq;

namespace FindingThePrimes.Services {
    public class PrimeService {

        public int[] GetPrimes(int minimum, int maximum) {
            List<int> primes = new();

            while (maximum > minimum) {
                maximum--;

                int[] lowPrimes = { 1, 2, 3, 5, 7 };

                if (lowPrimes.Any(i => i == maximum))
                    primes.Add(maximum);

                else if (maximum % 2 == 0)
                    continue;

                else if (SumOfDigits(maximum) % 3 == 0)
                    continue;

                else if (maximum % 5 == 0)
                    continue;

                else
                    primes.Add(maximum);

            }
            return primes.ToArray();
        }

        private static int SumOfDigits(int number) {
            int sum = 0;
            while (number != 0) {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

    }
}
