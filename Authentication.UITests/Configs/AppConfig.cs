using Authentication.UITests.Contracts;
using System.Text.Json;

namespace Authentication.UITests.Configs
{
    public class AppConfig
    {
        public string BaseUrl { get; set; } = string.Empty;
        public long TimeoutSeconds { get; set; }
        public Request Request { get; set; } = new();

        public static AppConfig Load(string path) =>
            JsonSerializer.Deserialize<AppConfig>(
                File.ReadAllText(path)
            )!;
    }
}