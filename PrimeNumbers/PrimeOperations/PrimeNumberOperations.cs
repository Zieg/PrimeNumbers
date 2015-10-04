using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers.PrimeOperations
{
    class PrimeNumberOperations
    {
        /// <summary>
        /// Checks if the number is a prime
        /// </summary>
        /// <param name="number">The given number</param>
        /// <returns>True of False</returns>
        public static bool CheckIfPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0 && i != number)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Gets all prime numbers starting from 0
        /// </summary>
        /// <param name="maxValue">Maximum value to get all primes</param>
        /// <returns>An array of boolean values</returns>
        public static bool[] GetAllPrimes(int maxValue)
        {
            bool[] boolArray = new bool[maxValue];

            boolArray[0] = false;
            boolArray[1] = false;
            boolArray[2] = true;

            for (int i = 3; i < maxValue; i++)
            {
                boolArray[i] = true;

                for (int k = 0; k < i; k++)
                {
                    if (boolArray[k])
                    {
                        if (i % k == 0)
                        {
                            boolArray[i] = false;
                            break;
                        }
                    }
                }
            }

            return boolArray;
        }
    }
}


