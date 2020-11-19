using System;
using System.IO;

namespace Lab2ISRSAC
{
    public static class Utils
    {
        private static int GetBitAtPos(int num, int pos)
        {
            return (num >> pos) & 1 ;
        }
        private static int ModularMultiplication(int A, int B, int M, int n)
        {
            int Y = 0;
            for (int j = 0; j < n; j++)
            {
                Y += GetBitAtPos(B, j) * A;
                if (GetBitAtPos(Y, 0) != 0)
                {
                    Y += M;
                }
                Y >>= 1;
            }

            if (Y > M)
            {
                Y -= M;
            }
            return Y;
        }

        public static int ModularExponentiation(int A, int E, int M, int n, int h)
        {
            int R = (int) Math.Pow(2, n);
            int Q = R % M;
            int C = R * R % M;
            int B = ModularMultiplication(A, C, M, n);
            for (int j = h; j > 0; j--)
            {
                Q = ModularMultiplication(Q, Q, M, n);
                if (GetBitAtPos(E, j-1) != 0)
                {
                    Q = ModularMultiplication(Q, B, M, n);
                }
            }

            Q = ModularMultiplication(Q, 1, M, n);
            return Q;
        }
        
        public static int ModInverse(int a, int m) 
        { 
            int g = GCD(a, m);
            if (g != 1)
            {
                Console.Write("Inverse doesn't exist");
                return -1;
            }
            else { 
                return  ModularPower(a,m-2, m); 
            } 
        }
        static int ModularPower(int x, int y, int m) 
        { 
            if (y == 0) 
                return 1; 
        
            int p = ModularPower(x, y / 2, m) % m; 
            p = (p * p) % m; 
        
            if (y % 2 == 0) 
                return p; 
            else
                return (x * p) % m; 
        }
        public static int GCD(int a, int b) 
        { 
            if (a == 0) 
                return b; 
            return GCD(b % a, a); 
        } 
    }
}