using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Helpers
{
    public static class Constants
    {
        public const string ToDoRegistryPath = @"SOFTWARE\WOW6432Node\ToDo";
        public const string JWTSecretKey = "JWTSecretKey";
        public const string EncryptionKey = "EncryptionKey";
        public const string EncryptionIV = "EncryptionIV";
        public const string UseEncryptionKey = "UseEncryption";
    }
}
