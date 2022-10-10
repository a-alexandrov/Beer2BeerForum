using Beer2Beer.Web.Utility.Contracts;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Beer2Beer.Web.Utility
{
    public class CustomHasher:ICustomHasher
    {
        public const int saltSize = 24;
        public const int hashSize = 24;
        public const int iteratons = 100000;
        private const string secretSalt = "t3@dav3dga5$6ga_sga514sw4";


        public byte[] CreateSalt() { 
            //ToDo - implement salt table lookup
            //RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            //byte[] salt = new byte[saltSize];
            //provider.GetBytes(salt);
            var salt = Encoding.ASCII.GetBytes(secretSalt);
        
            return salt;
        
        }

        public byte[] CreateHash(string input, byte[] salt) {

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, salt, iteratons);

            return pbkdf2.GetBytes(hashSize);
        }

        public string HashToString(byte[] hash) {

            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }

        

    }
}
