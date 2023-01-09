using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Helpers
{
    public class CryptologyHelper
    {
        public static string DecryptAES256(string Text)
        {

            string plaintext = null;
            byte[] cipherText = Convert.FromBase64String(Text.Replace(' ', '+'));

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = ASCIIEncoding.ASCII.GetBytes(CommonHelper.GetEncryptionKeyFromRegistery());
                aesAlg.IV = ASCIIEncoding.ASCII.GetBytes(CommonHelper.GetEncryptionIVFromRegistery()); ;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
