using System;
using System.IO;

namespace Lab2ISRSAC
{
    internal static class Utils
    {
        private static ulong GetBitAtPos(ulong num, int pos)
        {
            return (num >> pos) & 1 ;
        }
        public static ulong MontgomeryMultiplication(ulong A, ulong B, ulong M, int n = 0)
        {
            if (n == 0)
            {
                ulong m = M;
                while (m != 0)
                {
                    m >>= 1;
                    n++;
                }
            }
            ulong Y = 0;
            for (int j = 0; j < n; j++)
            {
                if(GetBitAtPos(B, j) != 0)
                Y +=  A;
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
        
        public static ulong MontgomeryExponentiation(ulong A, ulong E, ulong M)
        {
            ulong m = M, e = E;
            int n = 0, h = 0;
            while (m != 0)
            {
                m >>= 1;
                n++;
            }
            while (e != 0)
            {
                e >>= 1;
                h++;
            }
            ulong R = (ulong ) Math.Pow(2, n);
            ulong Q = R % M;
            ulong C = R * R % M;
            ulong B = MontgomeryMultiplication(A, C, M, n);
            for (int j = h-1; j >= 0; j--)
            {
                Q = MontgomeryMultiplication(Q, Q, M, n);
                if (GetBitAtPos(E, j) != 0)
                {
                    Q = MontgomeryMultiplication(Q, B, M, n);
                }
            }

            Q = MontgomeryMultiplication(Q, 1, M, n);
            return Q;
        }

        public static ulong ModPow(ulong A, ulong B, ulong M)
        {
            ulong b = B;
            int n = 0;
            while (b != 0)
            {
                b >>= 1;
                n++;
            }
            ulong c = 1;
            ulong a ;
            for (int e = n-1; e >= 0; e-- )
            {
                a = 1;
                if (GetBitAtPos(B, e) != 0)
                {
                    a = A;
                }
                c = (c * c * a)% M;
            }
            return c;
        }
        
        public static ulong ModInverse(ulong a, ulong m) 
        { 
            ulong m0 = m; 
            ulong y = 0, x = 1; 
  
            if (m == 1) 
                return 0; 
  
            while (a > 1) { 
                ulong q = a / m; 
  
                ulong t = m; 
  
                m = a % m; 
                a = t; 
                t = y; 
  
                // Update x and y 
                y = x - q * y; 
                x = t; 
            } 
  
            // Make x positive 
            if (x < 0) 
                x += m0; 
  
            return x; 
        }
        public static ulong GCD(ulong a, ulong b) 
        { 
            if (a == 0) 
                return b; 
            return GCD(b % a, a); 
        } 
    }
}