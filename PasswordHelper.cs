using System;
using System.Security.Cryptography;

namespace FlavorFlowIT13
{
    public static class PasswordHelper
    {
        // Hash password using PBKDF2 (secure)
        public static string HashPassword(string password)
        {
            // Generate salt
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(salt);

            // Derive hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combine salt + hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Return Base64 string
            return Convert.ToBase64String(hashBytes);
        }

        // Verify a password
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Extract salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Compute new hash with same salt
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20);

            // Compare hashes
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;

            return true;
        }
    }
}
