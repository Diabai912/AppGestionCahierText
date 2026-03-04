using System;
using System.Security.Cryptography;
using System.Text;

namespace AppGestionCahierText.Shared
{
    public static class Crypto
    {
        // Méthode pour hasher un mot de passe avec SHA256
        public static string HashPassword(string password)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Méthode pour générer un sel (salt) aléatoire
        public static string GenerateSalt(int size = 16)
        {
            var rng = new RNGCryptoServiceProvider();
            var saltBytes = new byte[size];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        // Méthode pour hasher avec sel
        public static string HashWithSalt(string password, string salt)
        {
            return HashPassword(password + salt);
        }
    }
}

