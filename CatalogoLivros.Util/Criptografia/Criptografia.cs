using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CatalogoLivros.Util.Criptografia
{
    public class Criptografia
    {

        public static string CriptografarSenhaByMD5(string senha)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return BitConverter.ToString(hash).Replace("-", "");
        }

        public static string CriptografarSenhaBySHA1(string senha)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}