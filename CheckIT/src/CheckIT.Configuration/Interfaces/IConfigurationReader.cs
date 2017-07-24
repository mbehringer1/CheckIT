using Microsoft.Extensions.Configuration;

namespace CheckIT.Configuration.Interfaces
{
    public interface IConfigurationReader
    {
        IConfigurationSection AppSetting { get; }
        string FolderPath { get; }
    }
}
