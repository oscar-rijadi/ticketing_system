namespace TicketingSystem.Core.Interfaces
{
    public interface IConfigProvider
    {
        string GetText(string key);
        T GetValue<T>(string key) where T : struct;
        T GetValueOrDefault<T>(string key, T defaultValue) where T : struct;

        string GetConnectionString(string key);
    }
}
