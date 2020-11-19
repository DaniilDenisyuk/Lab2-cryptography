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
}