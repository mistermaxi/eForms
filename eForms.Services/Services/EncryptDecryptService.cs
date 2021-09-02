using eForms.Domain.Context;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eForms.Services.Interfaces
{
    public class EncryptDecryptService : IEncryptDecryptService
    {
        //private IeFormsContext context;
        //private IHttpContextAccessor httpContextAccessor;

        //public EncryptDecryptService(IeFormsContext _context, IHttpContextAccessor _httpContextAccessor)
        //{
        //    context = _context;
        //    httpContextAccessor = _httpContextAccessor;
        //}

        //------ Each character in your string is 1 byte, or 8 bits. 32 * 8 = 256 :)
        private const string KeyValue = "!TheEmbassyBangk0kWe6App1icati0n"; 
        //private const string KeyValue = "E546C8DF278CD5931069B522E695D4F2";// Use this key for test
        

        public String EncryptData(string text)
        {

            //string strmsg = string.Empty;

            byte[] encode = new byte[text.ToString().Length];

            encode = Encoding.UTF8.GetBytes(text.ToString());

            text = Convert.ToBase64String(encode);

            return text.ToString();

        }
        public String DecryptData(string text)
        {

            //string decryptpwd = string.Empty;

            UTF8Encoding encodepwd = new UTF8Encoding();

            Decoder Decode = encodepwd.GetDecoder();

            byte[] todecode_byte = Convert.FromBase64String(text.ToString());

            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);

            char[] decoded_char = new char[charCount];

            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

            text = new String(decoded_char);

            return text.ToString();

        }
        //public static string EncryptAES(string clearText)
        //{
        //    string EncryptionKey = "Anilkey123";
        //    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(clearBytes, 0, clearBytes.Length);
        //                cs.Close();
        //            }
        //            clearText = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }
        //    return clearText;
        //}
        //public static string DecryptAES(string cipherText)
        //{
        //    string EncryptionKey = " Anilkey123";
        //    cipherText = cipherText.Replace(" ", "+");
        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(cipherBytes, 0, cipherBytes.Length);
        //                cs.Close();
        //            }
        //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //        }
        //    }
        //    return cipherText;
        //}

        public string EncryptString(string text)
        {
            var key = Encoding.UTF8.GetBytes(KeyValue);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public string DecryptString(string cipherText)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[fullCipher.Length - iv.Length]; //changes here

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            // Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, fullCipher.Length - iv.Length); // changes here
            var key = Encoding.UTF8.GetBytes(KeyValue);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }
        
        public string Encrypt(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            try
            {
                var key = Encoding.UTF8.GetBytes(KeyValue);

                using (var aesAlg = Aes.Create())
                {
                    using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                    {
                        using (var msEncrypt = new MemoryStream())
                        {
                            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(text);
                            }

                            var iv = aesAlg.IV;

                            var decryptedContent = msEncrypt.ToArray();

                            var result = new byte[iv.Length + decryptedContent.Length];

                            Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                            Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                            var str = Convert.ToBase64String(result);
                            var fullCipher = Convert.FromBase64String(str);
                            return str;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public string Decrypt(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            try
            {
                text = text.Replace(" ", "+");
                var fullCipher = Convert.FromBase64String(text);

                var iv = new byte[16];
                var cipher = new byte[fullCipher.Length - iv.Length];

                Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, fullCipher.Length - iv.Length);
                var key = Encoding.UTF8.GetBytes(KeyValue);

                using (var aesAlg = Aes.Create())
                {
                    using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                    {
                        string result;
                        using (var msDecrypt = new MemoryStream(cipher))
                        {
                            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (var srDecrypt = new StreamReader(csDecrypt))
                                {
                                    result = srDecrypt.ReadToEnd();
                                }
                            }
                        }

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }



    }
}
