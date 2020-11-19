using System;
using Lab1Pseudo_random_sequences;

namespace Lab2ISRSAC
{
    public class PrimeNumGenerator
    {
        private TableGenerator _generator = new TableGenerator(6, 8);

        public int Next(int bitSize)
        {
            return GeneratePrimalNum(bitSize);
        }

        private int GeneratePrimalNum(int bitSize)
        {
            return ProbablePrime(PotentialPrimalNum(bitSize));
        }

        private int PotentialPrimalNum(int bitSize)
        {
            int primalNum = 0;
            for (int i = 0; i < bitSize; i++)
            {
                primalNum |= (_generator.Next() ? 1 : 0) << i;
            }

            primalNum |= (1 << (bitSize - 1)) | 1;
            return primalNum;
        }

        private int ProbablePrime(int num)
        {
            if (!(WheelSievesTest(num, 2000) & RabinMillerTest(num, 5)))
            {
                num = ProbablePrime(num + 2);
            }

            return num;
        }

        private bool WheelSievesTest(int num, int range)
        {
            int[] arr = {7, 11, 13, 17, 19, 23, 29, 31};
            if (num < 2 || num % 2 == 0 || num % 3 == 0 || num % 5 == 0)
            {
                return false;
            }

            for (int i = 0; i < range; i += 30)
            {
                foreach (int c in arr)
                {
                    if (num % (c + i) == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool RabinMillerTest(int num, int k)
        {
            int d = num - 1;
            while (d % 2 == 0)
                d /= 2;
            for (int i = 0; i < k; i++)
            {
                if (!RabinMiller(num, d))
                {
                    return false;
                }
            }
        
            return true;

        }

        private bool RabinMiller(int num, int d)
        {
            var random = new Random();
            int a = random.Next(2, num - 2);

            int x = Utils.ModularExponentiation(a, d, num);
            if (x == 1 || x == num - 1)
                return true;
            while (d != num - 1)
            {
                x = Utils.ModularMultiplication(x, x, num);
                d *= 2;

                if (x == 1)
                {
                    return false;
                }

                if (x == num - 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}