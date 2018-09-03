using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Security;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace GoldenLady.Utility
{
    /// <summary>
    /// 对配置文件的读取和写入
    /// </summary>
    public static class ConfigHelper
    {
        public static bool SetConfigValue(string name, string value)
        {
            try
            {
                Configuration config = GetConfiguration();
                if (Array.Exists(config.AppSettings.Settings.AllKeys, s => s == name))
                {
                    config.AppSettings.Settings[name].Value = value;
                }
                else
                {
                    config.AppSettings.Settings.Add(name, value);
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string GetConfigValue(string name)
        {
            string value = null;
            try
            {
                Configuration config = GetConfiguration();
                if (Array.Exists(config.AppSettings.Settings.AllKeys, s => s == name))
                {
                    value = config.AppSettings.Settings[name].Value;
                }
            }
            catch { }
            return value;
        }

        private static Configuration GetConfiguration()
        {
            return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        

        public static void UpdateConfig(object config)
        {
            throw new NotImplementedException();
        }
        #region   邮箱配置文件
        /// <summary>
        ///     获取配置文件的服务器物理文件路径
        /// </summary>
        /// <typeparam name="T">配置信息类</typeparam>
        /// <returns>配置文件路径</returns>
        public static string GetConfigPath<T>()
        {

            string path = Directory.GetCurrentDirectory() + "\\";

            //如果是集合对象
            path = CheckIsList<T>(path);
            if (path == Directory.GetCurrentDirectory() + "\\")
            {
                path = path + typeof(T).Name + ".config";
            }
            return path;
        }
        public static T GetConfig<T>() where T : class, new()
        {
            var configObject = new object();
            Type configClassType = typeof(T);
            string configFilePath = GetConfigPath<T>(); //根据配置文件名读取配置文件  
            if (File.Exists(configFilePath))
            {
                using (var xmlTextReader = new XmlTextReader(configFilePath))
                {
                    var xmlSerializer = new XmlSerializer(configClassType);
                    configObject = xmlSerializer.Deserialize(xmlTextReader);
                }
            }
            var config = configObject as T;
            if (config == null)
            {
                return new T();
            }
            return config;
        }

        /// <summary>
        ///     更新配置信息，将配置信息对象序列化至相应的配置文件中，文件格式为带签名的UTF-8
        /// </summary>
        /// <typeparam name="T">配置信息类</typeparam>
        /// <param name="config">配置信息</param>
        public static void UpdateConfig<T>(T config)
        {
            Type configClassType = typeof(T);
            string configFilePath = GetConfigPath<T>(); //根据配置文件名读取配置文件  
            try
            {
                var xmlSerializer = new XmlSerializer(configClassType);
                using (var xmlTextWriter = new XmlTextWriter(configFilePath, Encoding.UTF8))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    var xmlNamespace = new XmlSerializerNamespaces();
                    xmlNamespace.Add(string.Empty, string.Empty);
                    xmlSerializer.Serialize(xmlTextWriter, config, xmlNamespace);
                }
            }
            catch (SecurityException ex)
            {
                throw new SecurityException(ex.Message, ex.DenySetInstance, ex.PermitOnlySetInstance, ex.Method,
                                            ex.Demanded, ex.FirstPermissionThatFailed);
            }
        }


        /// <summary>
        ///     获取配置信息
        /// </summary>
        /// <typeparam name="T">配置信息类</typeparam>
        /// <returns>配置信息</returns>
        


        private static string CheckIsList<T>(string path)
        {
            if (
                typeof(T).GetInterfaces()
                          .Any(
                              interfaceType =>
                              interfaceType.IsGenericType &&
                              interfaceType.GetGenericTypeDefinition() == typeof(IList<>)))
            {
                Type itemType = typeof(T).GetGenericArguments()[0];
                path = path + itemType.Name + ".config";
            }
            return path;
        }

        #endregion

    }
}
