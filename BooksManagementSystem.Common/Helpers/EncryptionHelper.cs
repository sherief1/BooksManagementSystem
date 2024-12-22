using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.Common.Helpers
{
    public class EncryptionHelper
    {
        // The AES encryption key (32 bytes for AES-256)
        private readonly string key = "12345678901234567890123456789012"; // AES key (should be exactly 32 bytes for AES-256)

        // The AES initialization vector (IV) (16 bytes for AES block size)
        private readonly string iv = "1234567890123456"; // AES IV (should be exactly 16 bytes)

        // Method to encrypt a plain text string
        public string Encrypt(string plainText)
        {
            // Creating an AES algorithm instance.
            using (var aesAlg = Aes.Create())
            {
                // Setting the key (converting string to bytes using UTF8 encoding).
                aesAlg.Key = Encoding.UTF8.GetBytes(key);

                // Setting the IV (converting string to bytes using UTF8 encoding).
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                // Create an encryptor to encrypt the data using the provided key and IV.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Use a MemoryStream to hold the encrypted data.
                using (var msEncrypt = new MemoryStream())
                {
                    // Create a CryptoStream that will handle the encryption while writing to the MemoryStream.
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))

                    // Use StreamWriter to write the plain text to the CryptoStream, which will encrypt it.
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        // Write the plain text into the CryptoStream, which performs encryption on the fly.
                        swEncrypt.Write(plainText);
                    }

                    // After encryption, convert the encrypted byte array to a Base64 string and return it.
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        // Method to decrypt a cipher text string
        public string Decrypt(string cipherText)
        {
            // Creating an AES algorithm instance.
            using (var aesAlg = Aes.Create())
            {
                // Setting the key (converting string to bytes using UTF8 encoding).
                aesAlg.Key = Encoding.UTF8.GetBytes(key);

                // Setting the IV (converting string to bytes using UTF8 encoding).
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                // Create a decryptor to decrypt the data using the provided key and IV.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create a MemoryStream to hold the encrypted data that will be decrypted.
                using (var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))

                // Create a CryptoStream that will handle the decryption while reading from the MemoryStream.
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))

                // Use StreamReader to read the decrypted data from the CryptoStream.
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                    // Read and return the decrypted text (plain text).
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}