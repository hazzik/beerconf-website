namespace BeerConf.Domain.Entities
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public sealed class Password
    {
        private static readonly Random random = new Random();
        private static readonly HashAlgorithm hashAlgorithm = MD5.Create();

        [Obsolete("Only for NHibernate")]
#pragma warning disable 628
        protected Password()
#pragma warning restore 628
        {
        }

        public Password(string password)
        {
            Salt = MakeSalt();
            Hash = HashPassword(password, Salt);
        }

        public string Hash { get; private set; }

        public string Salt { get; private set; }

        public bool Check(string oldPassword)
        {
            return Hash == HashPassword(oldPassword, Salt);
        }

        private static string MakeSalt()
        {
            return Enumerable.Range(0, 5)
                .Select(_ => (byte) random.Next())
                .ToBase64();
        }

        private static string HashPassword(string password, string salt)
        {
            Encoding encoding = Encoding.UTF8;
            byte[] passwordBytes = encoding.GetBytes(password)
                .Union(salt.FromBase64())
                .ToArray();
            return hashAlgorithm.ComputeHash(passwordBytes).ToBase64();
        }
    }
}