using Beer2Beer.Web.Utility.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Beer2Beer.Web.Utility
{
    public class CustomHasher:ICustomHasher
    {
        public const int saltSize = 24;
        public const int hashSize = 24;
        public const int iterations = 100000;

        private IConfiguration config;

        public CustomHasher(IConfiguration config) {
            this.config = config;
        }


        public byte[] CreateSalt() { 
            //ToDo - we can implement salt table lookup, now this is really just pepper :D
            //RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            //byte[] salt = new byte[saltSize];
            //provider.GetBytes(salt);
            var salt = Encoding.ASCII.GetBytes(this.config["Hasher:Salt"]);
        
            return salt;
        
        }

        public byte[] CreateHash(string input, byte[] salt) {

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, salt, iterations);

            return pbkdf2.GetBytes(hashSize);
        }

        public string HashToString(byte[] hash) {

            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }

        public string GetHash(string input) {
            return HashToString(CreateHash(input, CreateSalt()));
        }
        

    }
}
