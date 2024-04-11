using System.Security.Cryptography;
using System.Text;

namespace HrisApp.Client.HelperToken
{
    public class EncryptionHelper
    {
        private static readonly string key = "YourSecretKey"; // Change this to your secret key

        public static string Encrypt(string input)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = new byte[16]; // Use zero initialization vector for simplicity, consider generating random IV in production

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            byte[] encrypted;

            // Create a MemoryStream to write the encrypted data to
            using (var msEncrypt = new System.IO.MemoryStream())
            {
                // Create a CryptoStream to perform encryption
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    // Write the data to the CryptoStream
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(input);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            // Return the encrypted bytes as a base64-encoded string
            return Convert.ToBase64String(encrypted);
        }
    }
}
