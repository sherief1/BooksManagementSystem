using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagementSystem.Common.Helpers
{
    public class Hashing
    {
        /// <summary>
        /// Generates a hash for the given input using the specified algorithm.
        /// </summary>
        /// <param name="input">The string to hash.</param>
        /// <param name="algorithmName">The hashing algorithm (e.g., "SHA256", "SHA1", "MD5").</param>
        /// <returns>The hash as a hexadecimal string.</returns>
        public static string GenerateHash(string input, string algorithmName = "SHA256")
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            using var algorithm = HashAlgorithm.Create(algorithmName);
            if (algorithm == null)
                throw new InvalidOperationException($"Hash algorithm '{algorithmName}' is not supported.");

            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = algorithm.ComputeHash(inputBytes);

            return ConvertToHexString(hashBytes);
        }

        /// <summary>
        /// Verifies if the given input matches the provided hash.
        /// </summary>
        /// <param name="input">The string to hash and compare.</param>
        /// <param name="hash">The hash to compare against.</param>
        /// <param name="algorithmName">The hashing algorithm used to generate the hash.</param>
        /// <returns>True if the input matches the hash; otherwise, false.</returns>
        public static bool VerifyHash(string input, string hash, string algorithmName = "SHA256")
        {
            var generatedHash = GenerateHash(input, algorithmName);
            return string.Equals(generatedHash, hash, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Converts a byte array to a hexadecimal string.
        /// </summary>
        /// <param name="bytes">The byte array to convert.</param>
        /// <returns>The hexadecimal string representation of the byte array.</returns>
        private static string ConvertToHexString(byte[] bytes)
        {
            var builder = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
                builder.AppendFormat("{0:x2}", b);
            return builder.ToString();
        }
    }
}
