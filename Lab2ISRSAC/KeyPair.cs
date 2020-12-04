namespace Lab2ISRSAC
{
    public struct KeyPair
    {
        public ulong Exponent;
        public ulong Module;
        public KeyPair(ulong exponent, ulong module)
        {
            Exponent = exponent;
            Module = module;
        }
    }
}