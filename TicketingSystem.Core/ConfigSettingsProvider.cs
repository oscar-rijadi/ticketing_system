using System.Configuration;
using TicketingSystem.Core.Interfaces;

namespace TicketingSystem.Core
{
    public class ConfigSettingsProvider : IConfigProvider
    {
        private readonly AppSettingsReader _reader;

        public ConfigSettingsProvider()
        {
            _reader = new AppSettingsReader();

        }

        public string GetText(string key)
        {
            try
            {
                return (string)_reader.GetValue(key, typeof(string));
            }
            catch
            {
                return null;
            }
        }

        public T GetValue<T>(string key) where T : struct
        {
            return (T)_reader.GetValue(key, typeof(T));
        }

        public T GetValueOrDefault<T>(string key, T defaultValue) where T : struct
        {
            try
            {
                return GetValue<T>(key);
            }
            catch
            {
                return defaultValue;
            }
        }

        public string GetConnectionString(string key)
        {
            if (ConfigurationManager.ConnectionStrings[key] != null)
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            return string.Empty;
        }
    }
}
