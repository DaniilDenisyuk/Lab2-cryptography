using System;
using System.Runtime.CompilerServices;

namespace Lab2ISRSAC
{
    public class ISRSAC
    {
        private PrimeNumGenerator primeNumGenerator = new PrimeNumGenerator();
        public Keys GenerateKeys(int bitSize)
        {
            ulong p = primeNumGenerator.Next(bitSize/4);
            ulong q = primeNumGenerator.Next(bitSize/4);
            while (p==q)
            {
                q = primeNumGenerator.Next(bitSize/4);
            }
            //ulong p = 59, q = 37, r = 3;
            ulong m = p * q;
            ulong n = p * q * (q - 1) * (p - 1);
            var random = new Random();
            int r = random.Next(1, bitSize/4);
            ulong twoDegreeR = (ulong) Math.Pow(2, r);
            ulong alpha = (p - 1) * (q - 1) * (p - twoDegreeR) * (q - twoDegreeR) / twoDegreeR;
            ulong E = (ulong) random.Next(2, 200);
            while (Utils.GCD(E,alpha) > 1)
            {
                E += 1;                        
            }
            ulong D = Utils.ModInverse(E, alpha);
            return new Keys(new KeyPair(E,n), new KeyPair(D,m));
        }
    }
}