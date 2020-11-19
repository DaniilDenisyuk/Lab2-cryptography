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
            if (!(WheelSievesTest(num, 2000) & RabinMillerTest(num)))
            {
                num = ProbablePrime(num + 2);
            }
            return num;
        }

        private bool WheelSievesTest(int num, int range)
        {
            return true;
        }

        private bool RabinMillerTest(int num)
        {
            return true;
        }
    }
}