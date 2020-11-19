using System;
using System.Runtime.CompilerServices;

namespace Lab2ISRSAC
{
    public struct KeyPair
    {
        public int Exponent;
        public int Module;
        public KeyPair(int exponent, int module)
        {
            Exponent = exponent;
            Module = module;
        }
    }
    public struct ISRSACKeys
    {
        public KeyPair PublicKeyPair;
        public KeyPair PrivateKeyPair;
        public ISRSACKeys(KeyPair publicKeyPair, KeyPair privateKeyPair)
        {
            PrivateKeyPair = privateKeyPair;
            PublicKeyPair = publicKeyPair;
        }
    }
    
    public class ISRSAC
    {
        public ISRSACKeys GenerateKeys(int bitSize)
        {
            var primeNumGenerator = new PrimeNumGenerator();
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
            return new ISRSACKeys(new KeyPair(E,n), new KeyPair(D,m));
        }
    }
}