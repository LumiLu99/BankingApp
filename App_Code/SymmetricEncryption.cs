using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;


public class SymmetricEncryption
{
    private const string EncryptionKey = "thisisarandomstr"; //16 bytes
    public string Encrypt(string plainText)
    {
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
            aesAlg.IV = new byte[16]; // AES requires IV (Initialization Vector) of 16 bytes

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(plainTextBytes, 0, plainTextBytes.Length);
                    csEncrypt.FlushFinalBlock();
                    byte[] cipherTextBytes = msEncrypt.ToArray();
                    return Convert.ToBase64String(cipherTextBytes);
                }
            }
        }
    }

    public string Decrypt(string cipherText)
    {
        byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
            aesAlg.IV = new byte[16]; // IV should be the same for decryption

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}