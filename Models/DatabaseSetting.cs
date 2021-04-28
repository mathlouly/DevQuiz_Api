namespace devquiz_api.Models
{
    public class DatabaseSetting : IDatabaseSetting
    {
        public string ConnectionString {get; set;}
    }

    public interface IDatabaseSetting
    {
        string ConnectionString {get; set;}
    }
}