using System;

namespace Lab2ISRSAC
{
    public static class Encryptor
    {
        public static ulong  EncryptDecryptMessage(ulong message, KeyPair keyPair)
        {
            return Utils.ModPow(message, keyPair.Exponent, keyPair.Module);
        }
    }
}