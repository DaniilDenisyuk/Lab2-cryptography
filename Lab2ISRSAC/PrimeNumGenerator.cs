using System;
using Lab1Pseudo_random_sequences;

namespace Lab2ISRSAC
{
    public class PrimeNumGenerator
    {
        private TableGenerator _generator = new TableGenerator(6, 8);

        public ulong Next(int bitSize)
        {
            return ProbablePrime(PotentialPrimalNum(bitSize));
        }

        private ulong PotentialPrimalNum(int bitSize)
        {
            ulong primalNum = 0;
            for (int i = 0; i < bitSize; i++)
            {
                primalNum |= (ulong)((_generator.Next() ? 1 : 0) << i);
            }

            primalNum |= (ulong)((1 << (bitSize - 1)) | 1);
            return primalNum;
        }

        private ulong ProbablePrime(ulong num)
        {
            if (!(WheelSievesTest(num, 2000) & RabinMillerTest(num, 5)))
            {
                num = ProbablePrime(num + 2);
            }

            return num;
        }

        private bool WheelSievesTest(ulong num, ulong range)
        {
            if (range > num)
            {
                range = num/2;
            }
            int[] arr = {7, 11, 13, 17, 19, 23, 29, 31};
            foreach (ulong c in arr)
            {
                if (num == c)
                {
                    return true;
                }
            }
            if (num < 2 || num % 2 == 0 || num % 3 == 0 || num % 5 == 0)
            {
                return false;
            }
            
            for (ulong i = 0; i < range; i += 30)
            {
                foreach (ulong c in arr)
                {
                    if (num % (c + i) == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool RabinMillerTest(ulong num, ulong k)
        {
            ulong d = num - 1;
            while (d % 2 == 0)
                d /= 2;
            for (ulong i = 0; i < k; i++)
            {
                if (!RabinMiller(num, d))
                {
                    return false;
                }
            }
        
            return true;

        }

        private bool RabinMiller(ulong num, ulong d)
        {
            var random = new Random();
            ulong a = (ulong)random.Next((int)num-1);

            ulong x = Utils.MontgomeryExponentiation(a, d, num);
            if (x == 1 || x == num - 1)
                return true;
            while (d != num - 1)
            {
                x = Utils.MontgomeryMultiplication(x, x, num);
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