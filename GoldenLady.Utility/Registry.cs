using System;

namespace GoldenLady.Utility
{
    // Redesign by LiuHaiyang 2016.11.23
    public class Registry
    {
        private string _keyName;
        private string _userRoot;

        public Registry(string pathRoot) { _keyName = _userRoot = pathRoot; }

        public string Root
        {
            get { return _userRoot; }
            set { _keyName = _userRoot = value; }
        }

        public string[] GetRegistry(string valueName)
        {
            try
            {
                return Microsoft.Win32.Registry.GetValue(_keyName, valueName, null) as string[];
            }
            catch(Exception)
            {
                return null;
            }
        }

        public bool SetRegistry(string valueName, object value)
        {
            try
            {
                Microsoft.Win32.Registry.SetValue(_keyName, valueName, value);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}