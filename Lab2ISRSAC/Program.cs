using System;

namespace Lab2ISRSAC
{
    class Program
    {
        static void Main(string[] args)
        {
          var isrsac = new ISRSAC();
          var keys = isrsac.GenerateKeys(16);
          ulong message = 213;
          ulong encryptedMessage = Encryptor.EncryptDecryptMessage(message, keys.PublicKeyPair);
          ulong decryptedMessage = Encryptor.EncryptDecryptMessage(encryptedMessage, keys.PrivateKeyPair);
          Console.WriteLine("The message: {0}, the encrypted message: {1}, the decrypted message: {2}.\n" +
                            " Does decrypted message = message? {3}",
              message, encryptedMessage, decryptedMessage, message == decryptedMessage);
            
          //Console.Write(Utils.MontgomeryExponentiation(2018, 43, 12155517));
        }
    }
}