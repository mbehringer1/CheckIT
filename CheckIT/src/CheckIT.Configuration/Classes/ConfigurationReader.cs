using CheckIT.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CheckIT.Configuration.Classes
{
    public class ConfigurationReader : IConfigurationReader
    {
        private const string _appSettings = "AppSettings";
        private const string _FolderPath = "FolderPath";
        public IConfigurationRoot Configuration { get; set; }
        public ConfigurationReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfigurationSection AppSetting
        {
            get
            {
                return Configuration.GetSection(_appSettings);
            }
        }
        public string FolderPath
        {
            get
            {
                return AppSetting[_FolderPath];
            }
        }
    }
}
