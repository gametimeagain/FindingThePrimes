using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FindingThePrimes.Services {
    public class SearchService {
        private List<(string, int[])> _result;

        private int[] _listOfPrimes;
        private int _depth;

        private Stopwatch _stopWatch;
        public string TimeElapsed => _stopWatch.Elapsed.ToString();

        public List<(string, int[])> FindMatchingProducts(int[] listOfPrimes, int depth) {
            _stopWatch = new();
            _result = new();

            _listOfPrimes = listOfPrimes;
            _depth = depth;

            _stopWatch.Start();
            SearchAllPrimes(_listOfPrimes.Length, 0, _depth, 0);
            _stopWatch.Stop();

            return _result;
        }

        private void SearchAllPrimes(int numberOfPrimes, int position, int depth, int start) {
            if (position == depth) {
                string product = ((Int64)(_listOfPrimes[0] * _listOfPrimes[1]) * (Int64)(_listOfPrimes[2] * _listOfPrimes[3])).ToString();
                if (product.Length != 12)
                    return;

                if (!IsProductInOrder(product))
                    return;

                int[] numbersOfProduct = new int[] { _listOfPrimes[0], _listOfPrimes[1], _listOfPrimes[2], _listOfPrimes[3] };
                _result.Add((product, numbersOfProduct));
                return;
            }

            for (int i = start; i < numberOfPrimes; i++) {
                if (depth - position + i > numberOfPrimes)
                    return;

                (_listOfPrimes[position], _listOfPrimes[i]) = (_listOfPrimes[i], _listOfPrimes[position]);

                SearchAllPrimes(numberOfPrimes, position + 1, depth, i + 1);

                (_listOfPrimes[position], _listOfPrimes[i]) = (_listOfPrimes[i], _listOfPrimes[position]);

            }
        }

        private bool IsProductInOrder(string product) {
            char[] digits = product.ToCharArray();
            char[] sortedDigits = (char[])digits.Clone();
            Array.Sort(sortedDigits);
            for (int i = 0; i < digits.Length; i++) {
                if (digits[i] != sortedDigits[i])
                    return false;
            }
            return true;
        }

    }
}
