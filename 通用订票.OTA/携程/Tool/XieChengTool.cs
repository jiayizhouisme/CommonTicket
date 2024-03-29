using Furion.DataEncryption;
using Furion.DataEncryption.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace 通用订票.OTA.携程.Tool
{
    public class XieChengTool
    {
        public static byte[] AESEncrypt(string str, string key, string iv)
        {
            if (string.IsNullOrEmpty(str)) return null;
            using (AesCryptoServiceProvider provider = new AesCryptoServiceProvider())
            {
                Byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);
                provider.Key = Encoding.UTF8.GetBytes(key);
                provider.IV = Encoding.UTF8.GetBytes(iv);
                provider.Mode = CipherMode.CBC;
                provider.Padding = PaddingMode.PKCS7;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, provider.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(toEncryptArray, 0, toEncryptArray.Length);
                        cs.FlushFinalBlock();
                        byte[] cipherBytes = ms.ToArray();
                        cs.Close();
                        ms.Close();
                        return cipherBytes;
                    }
                }
            }
        }

        public static string AESDecrypt(string str, string key, string iv)
        {
            byte[] content = DecodeBytes(str);
            if (content == null || content.Length == 0) return null;
            using (AesCryptoServiceProvider provider = new AesCryptoServiceProvider())
            {
                provider.Key = Encoding.UTF8.GetBytes(key);
                provider.IV = Encoding.UTF8.GetBytes(iv);
                provider.Mode = CipherMode.CBC;
                provider.Padding = PaddingMode.PKCS7;
                using (ICryptoTransform cryptoTransform = provider.CreateDecryptor())
                {
                    byte[] results = cryptoTransform.TransformFinalBlock(content, 0, content.Length);
                    provider.Clear();
                    return Encoding.UTF8.GetString(results);
                }
            }
        }

        public static bool SignVerify(string accountId,string serviceName,string requestTime,string body,string version,string apikey,string sign)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(accountId);
            sb.Append(serviceName);
            sb.Append(requestTime);
            sb.Append(body);
            sb.Append(version);
            sb.Append(apikey);
            var encrpted = MD5Encryption.Encrypt(sb.ToString());
            if (encrpted == sign)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string EncodeBytes(byte[] source)
        {
            StringBuilder strBuf = new StringBuilder();
            foreach (byte t in source)
            {
                strBuf.Append((char)(((t >> 4) & 0xF) + ((int)'a')));
                strBuf.Append((char)(((t) & 0xF) + ((int)'a')));
            }
            return strBuf.ToString();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] DecodeBytes(string data)
        {
            byte[] bytes = new byte[data.Length / 2];
            for (int i = 0; i < data.Length; i += 2)
            {
                char c = data[i];
                bytes[i / 2] = (byte)((c - 'a') << 4);
                c = data[i + 1];
                bytes[i / 2] += (byte)(c - 'a');
            }
            return bytes;
        }

    }
}
