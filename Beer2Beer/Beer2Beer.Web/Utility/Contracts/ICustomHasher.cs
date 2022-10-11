using System.Security.Cryptography;
using System.Text;
using System;

namespace Beer2Beer.Web.Utility.Contracts
{
    public interface ICustomHasher
    {
        public byte[] CreateSalt();

        public byte[] CreateHash(string input, byte[] salt);

        public string HashToString(byte[] hash);

        public string GetHash(string input);
    }
}
