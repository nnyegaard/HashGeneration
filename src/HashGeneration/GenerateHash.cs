namespace HashGeneration
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class HashGeneration
    {
        public static string Generate(HashAlgorithm algorithm = null)
        {
            if (algorithm == null)
            {
                algorithm = SHA512.Create();
            }

            using (algorithm)
            {
                string hash = $"{Guid.NewGuid()} {DateTime.UtcNow}";
                byte[] byteHash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(hash));
                string computedHash = Convert.ToBase64String(byteHash);

                return computedHash;
            }
        }
    }
}