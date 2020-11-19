namespace Lab2ISRSAC
{
    public struct Keys
    {
        public KeyPair PublicKeyPair;
        public KeyPair PrivateKeyPair;
        public Keys(KeyPair publicKeyPair, KeyPair privateKeyPair)
        {
            PrivateKeyPair = privateKeyPair;
            PublicKeyPair = publicKeyPair;
        }
    }
}