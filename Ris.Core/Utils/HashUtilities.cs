using System.Security.Cryptography;
using System.Text;

namespace Rs.Dnevnik.Ris.Core.Utils
{
    public static class HashUtilities
    {
        public static byte[] CalculateMd5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.Unicode.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            return hash;
        } 
    }
}