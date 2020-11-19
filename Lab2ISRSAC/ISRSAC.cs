using System;
using System.Runtime.CompilerServices;

namespace Lab2ISRSAC
{
    public class ISRSAC
    {
        private PrimeNumGenerator primeNumGenerator = new PrimeNumGenerator();
        public Keys GenerateKeys(int bitSize)
        {
            int p = primeNumGenerator.Next(bitSize/2);
            int q = primeNumGenerator.Next(bitSize/2);
            int m = p * q;
            int n = p * q * (q - 1) * (p - 1);
            var random = new Random();
            int r = random.Next(2, bitSize/2 + 1);
            int twoDegreeR = (int) Math.Pow(2, r);
            int alpha = (p - 1) * (q - 1) * (p - twoDegreeR) * (q - twoDegreeR) / twoDegreeR;
            int E = random.Next(2, alpha/2);
            while (Utils.GCD(E,alpha) != 0)
            {
                E += 1;
            }
            int D = Utils.ModInverse(E, alpha);
            return new Keys(new KeyPair(E,n), new KeyPair(D,m));
        }
    }
}