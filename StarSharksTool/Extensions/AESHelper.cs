using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace StarSharksTool.Extensions
{
    public static class AESHelper
    {
        public static string Encrypt(string plainText)
        {
            try
            {
                Aes tdes = Aes.Create();
                tdes.Key = Encoding.UTF8.GetBytes(Global.KeyHash);
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform crypt = tdes.CreateEncryptor();
                byte[] plain = Encoding.UTF8.GetBytes(plainText);
                byte[] cipher = crypt.TransformFinalBlock(plain, 0, plain.Length);
                var encryptedText = Convert.ToBase64String(cipher);
                return encryptedText;
            }
            catch (Exception)
            {

                return plainText;
            }
        }

        public static string Decrypt(string cipherText)
        {
            Aes tdes = Aes.Create();
            tdes.Key = Encoding.UTF8.GetBytes(Global.KeyHash);
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform crypt = tdes.CreateDecryptor();
            byte[] cipher = Convert.FromBase64String(cipherText);
            byte[] painTextBytes = crypt.TransformFinalBlock(cipher, 0, cipher.Length);
            var paintText = Convert.ToBase64String(painTextBytes);
            var paintText1 = Encoding.UTF8.GetString(Convert.FromBase64String(paintText));
            return paintText1;
        }
    }
}
