using System;
using System.Security.Cryptography;

namespace DKT.Admin.Helpers
{
    public static class HashingHelper
    {
        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[20];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static string GeneratePasswordHash(string password, string passwordSalt)
        {
            using (var bytes = new Rfc2898DeriveBytes(password, Convert.FromBase64String(passwordSalt), 1000, HashAlgorithmName.SHA256))
            {
                var derivedRandomKey = bytes.GetBytes(32);
                return Convert.ToBase64String(derivedRandomKey);
            }
        }
        public static void CreateAccountPasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            passwordSalt = GenerateSalt();
            passwordHash = HashingHelper.GeneratePasswordHash(password, passwordSalt);            
        }
    }
}
