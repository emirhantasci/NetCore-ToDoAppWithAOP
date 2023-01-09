using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Core.Helpers
{
    public static class CommonHelper
    {
        public static string GetEncryptionKeyFromRegistery()
        {

            string _result = "";
            RegistryKey key = null;
            string encryptionKey = "";
            key = Registry.LocalMachine.OpenSubKey(Constants.ToDoRegistryPath);

            if (key == null)
            {

            }
            encryptionKey = key.GetValue(Constants.EncryptionKey, "").ToString();
            if (encryptionKey == null || encryptionKey == "")
            {

                key.Close();
            }
            else
            {
                string _val = key.GetValue(Constants.EncryptionKey, "").ToString();
                _result = _val;
                if (_val == null || _val == "")
                {

                }
                key.Close();
            }
            return _result;
        }
        public static string GetUseEncryptionFromRegistery()
        {
            string _result = "";
            RegistryKey key = null;
            string useEncryption = "";
            key = Registry.LocalMachine.OpenSubKey(Constants.ToDoRegistryPath);
            if (key == null)
            {

            }
            useEncryption = key.GetValue(Constants.UseEncryptionKey, "").ToString();
            if (useEncryption == null || useEncryption == "")
            {

                key.Close();
            }
            else
            {
                string _val = key.GetValue(Constants.UseEncryptionKey, "").ToString();
                if (_val == null || _val == "")
                {

                }
                _result = _val;
                key.Close();
            }
            return _result;
        }
        public static string GetEncryptionIVFromRegistery()
        {
            string _result = "";
            RegistryKey key = null;
            string encryptionIV = "";

            key = Registry.LocalMachine.OpenSubKey(Constants.ToDoRegistryPath);

            if (key == null)
            {
                throw new ApplicationException($"Registry key not found. ({Constants.ToDoRegistryPath})");
            }
            encryptionIV = key.GetValue(Constants.EncryptionIV, "").ToString();
            if (String.IsNullOrEmpty(encryptionIV))
            {
                key.Close();
                throw new ApplicationException($"The registry value { Constants.EncryptionIV } not found in path {Constants.ToDoRegistryPath}");
            }
            else
            {
                string _val = key.GetValue(Constants.EncryptionIV, "").ToString();
                if (String.IsNullOrEmpty(_val))
                {
                    key.Close();
                    throw new ApplicationException($"The registry value { Constants.EncryptionIV } cannot be null");
                }
                _result = _val;
                key.Close();
            }

            return _result;
        }
    }
}
