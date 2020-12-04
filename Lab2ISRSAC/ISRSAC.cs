using System;
using System.Runtime.CompilerServices;

namespace Lab2ISRSAC
{
    public class ISRSAC
    {
        private PrimeNumGenerator primeNumGenerator = new PrimeNumGenerator();
        public Keys GenerateKeys(ulong bitSize)
        {
            //ulong p = primeNumGenerator.Next(bitSize/4);
            //ulong q = primeNumGenerator.Next(bitSize/4);
            ulong p = 59, q = 37, r = 3;
            ulong m = p * q;
            ulong n = p * q * (q - 1) * (p - 1);
            var random = new Random();
            //ulong r = random.Next(2, bitSize/2 + 1);
            ulong twoDegreeR = (ulong) Math.Pow(2, r);
            ulong alpha = (p - 1) * (q - 1) * (p - twoDegreeR) * (q - twoDegreeR) / twoDegreeR;
            ulong E = 43;
            //ulong E = random.Next(2, alpha/2);
            while (Utils.GCD(E,alpha) > 1)
            {
                E += 1;                        
            }
            ulong D = Utils.ModInverse(E, alpha);
            return new Keys(new KeyPair(E,n), new KeyPair(D,m));
        }
    }
}