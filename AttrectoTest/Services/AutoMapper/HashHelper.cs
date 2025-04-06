using System.Security.Cryptography;
using System.Text;

namespace AttrectoTest.Services.AutoMapper
{
    public static class HashHelper
    {
        public static byte[] HashPassword(string password)
        {
            using (var sha = SHA512.Create())
            {
                return sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
