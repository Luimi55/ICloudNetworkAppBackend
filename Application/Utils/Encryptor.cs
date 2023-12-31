using Application.Utils.Interfaces;
using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Utils
{
    public class Encryptor : IEncryptor
    {
        public string? _key = Environment.GetEnvironmentVariable("ICNAKey");
        public string? _iv = Environment.GetEnvironmentVariable("ICNAIv");

        public Encryptor() {}

        public string Encrypt(string input)
        {
            string encrypted = EncryptProvider.AESEncrypt(input, _key, _iv);
            return encrypted;
        }

        public string Decrypt(string input)
        {
            string decrypted = EncryptProvider.AESDecrypt(input, _key, _iv);
            return decrypted;
        }
    }
}
