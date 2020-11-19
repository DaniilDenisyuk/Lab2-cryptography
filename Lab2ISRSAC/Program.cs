using System;

namespace Lab2ISRSAC
{
    class Program
    {
        static void Main(string[] args)
        {
           var isrsac = new ISRSAC();
           var keys = isrsac.GenerateKeys(16);
           int message = 2362362;
           int encryptedMessage = Encryptor.EncryptMessage(message, keys.PrivateKeyPair);
           int decryptedMessage = Encryptor.DecryptMessage(encryptedMessage, keys.PublicKeyPair);
           Console.WriteLine("The message: {0}, the encrypted message: {1}, the decrypted message: {2}.\n" +
                             " Does decrypted message = message? {3}",
               message, encryptedMessage, decryptedMessage, message == decryptedMessage);
        }
    }
}